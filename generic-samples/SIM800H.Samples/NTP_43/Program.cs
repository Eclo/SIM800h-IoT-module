using Eclo.NetMF.SIM800H;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System;
using System.IO.Ports;
using System.Threading;

namespace SIM800HSamples
{
    public class Program
    {
        private const string APNConfigString = "<replace-with-apn-name>|<replace-with-apn-user>|<replace-with-apn-password>";

        public static void Main()
        {
            InitializeSIM800H();

            // loop forever and output available RAM each 5 seconds
            while (true)
            {
                Microsoft.SPOT.Debug.EnableGCMessages(false);
                Microsoft.SPOT.Debug.Print("Free RAM: " + Microsoft.SPOT.Debug.GC(false).ToString());

                Thread.Sleep(5000);
            };
        }

        static void InitializeSIM800H()
        {
            // initialization of the module is very simple 
            // we just need to pass a serial port and an output signal to control the "power key" signal

            // SIM800H serial port
            SerialPort sim800SerialPort = new SerialPort("COM2");

            // SIM800H signal for "power key"
            OutputPort sim800PowerKey = new OutputPort(Cpu.Pin.GPIO_Pin6, false);

            Microsoft.SPOT.Debug.Print("... Configuring SIM800H ...");
            
            // configure SIM800H device
            SIM800H.Configure(sim800PowerKey, sim800SerialPort);

            // add event handler to be aware of network registration status changes
            SIM800H.GsmNetworkRegistrationChanged += SIM800H_GsmNetworkRegistrationChanged;

            // add event handler to be aware of GPRS network registration status changes
            SIM800H.GprsNetworkRegistrationChanged += SIM800H_GprsNetworkRegistrationChanged;

            // because we need Internet connection the access point configuration (APN) is mandatory
            // the configuration depends on what your network operator requires
            // it may be just the access point name or it may require an user and password too
            // AccessPointConfiguration class provides a number of convenient options to create a new APN configuration
            SIM800H.AccessPointConfiguration = AccessPointConfiguration.Parse(APNConfigString);

            // async call to power on module 
            // in this example we are setting up a callback on a separate method
            SIM800H.PowerOnAsync(PowerOnCompleted);
            Microsoft.SPOT.Debug.Print("... Power on sequence started ...");
        }

        private static void PowerOnCompleted(IAsyncResult result)
        {
            // check result
            if (((PowerOnAsyncResult)result).Result == PowerStatus.On)
            {
                Debug.Print("... Power on sequence completed...");
            }
            else
            {
                // something went wrong...
                Debug.Print("### Power on sequence FAILED ###");
            }
        }

        private static void SIM800H_GsmNetworkRegistrationChanged(NetworkRegistrationState networkState)
        {
            Debug.Print(networkState.GetDescription("GSM"));
        }

        private static void SIM800H_GprsNetworkRegistrationChanged(NetworkRegistrationState networkState)
        {
            Debug.Print(networkState.GetDescription("GPRS"));

            if (networkState == NetworkRegistrationState.Registered)
            {
                // SIM800H is registered with GPRS network so we can request an Internet connection now

                // add event handler to know when we have an active Internet connection 
                // remove it first so we don't have duplicate calls in case a new successful registration occurs 
                SIM800H.GprsProvider.GprsIpAppsBearerStateChanged -= GprsProvider_GprsIpAppsBearerStateChanged;
                SIM800H.GprsProvider.GprsIpAppsBearerStateChanged += GprsProvider_GprsIpAppsBearerStateChanged;

                // async call to GPRS provider to open the GPRS bearer
                // we can set a callback here to get the result of that request and act accordingly
                // or we can manage this in the GprsIpAppsBearerStateChanged event handler that we've already setup during the configuration
                SIM800H.GprsProvider.OpenBearerAsync();
            }
        }
    
        private static void GprsProvider_GprsIpAppsBearerStateChanged(bool isOpen)
        {
            if(isOpen)
            {
                // launch a new thread to update the RTC from the NTP server
                new Thread(() =>
                {
                    Thread.Sleep(1000);

                    UpdateRTCFromNetwork();
                }).Start();
            }
        }

        static void UpdateRTCFromNetwork()
        {
            Debug.Print("... requesting time from NTP server ...");

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // the following code block uses an async call to SNTP client which should be OK for most of the use scenarios
            // check an alternative in the code block commented bellow 

            SIM800H.SntpClient.SyncNetworkTimeAsync("time.nist.gov", TimeSpan.Zero, (ar) =>
            {
                // update RTC only if update was successful
                if (((SyncNetworkTimeAsyncResult)ar).Result == SyncResult.SyncSuccessful)
                {
                    // get current date time and update RTC
                    DateTime rtcValue = SIM800H.GetDateTime();
                    // set framework date time
                    Utility.SetLocalTime(rtcValue);

                    Debug.Print("!!! new time from NTP server: " + rtcValue.ToString());

                    // done here, dispose SNTP client to free up memory
                    SIM800H.SntpClient.Dispose();
                    SIM800H.SntpClient = null;
                }
                else
                {
                    Debug.Print("### failed to get time from NTP server ###");
                }
            });

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // if your network connection is not that good and you definitely need a valid RTC better do this inside a try/catch AND using a retry strategy
            // the implementation bellow uses a synchronous call to SNTP client
            // for the simplest async call see the 

            //byte retryCounter = 0;

            //while (retryCounter <= 3)
            //{
            //    try
            //    {
            //        var result = SIM800H.SntpClient.SyncNetworkTimeAsync("time.nist.gov", TimeSpan.Zero).End();

            //        // check result
            //        if (result == Eclo.NetMF.SIM800H.SyncResult.SyncSuccessful)
            //        {
            //            // get current date time and update RTC
            //            DateTime rtcValue = SIM800H.GetDateTime();
            //            // set framework date time
            //            Utility.SetLocalTime(rtcValue);

            //            Debug.Print("!!! new time from NTP server: " + rtcValue.ToString());

            //            // done here, dispose SNTP client to free up memory
            //            SIM800H.SntpClient.Dispose();
            //            SIM800H.SntpClient = null;

            //            return;
            //        }
            //        else
            //        {
            //            Debug.Print("### failed to get time from NTP server ###");
            //        }
            //    }
            //    catch
            //    {
            //        // failed updating RTC
            //        // flag this
            //    }

            //    // add retry
            //    retryCounter++;

            //    // progressive wait 15*N seconds before next retry
            //    Thread.Sleep(15000 * retryCounter);
            //}
        }
    }
}
