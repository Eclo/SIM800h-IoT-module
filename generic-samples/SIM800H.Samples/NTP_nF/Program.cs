using Eclo.nF.SIM800H;
using nanoFramework.Runtime.Native;
using System;
using System.Threading;
using Windows.Devices.Gpio;
using Windows.Devices.SerialCommunication;

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
                Thread.Sleep(5000);

                // output signal RSSI
                Console.WriteLine("Network signal strength is " + SIM800H.RetrieveSignalStrength().GetSignalStrengthDescription());
            };
        }

        static void InitializeSIM800H()
        {
            // initialization of the module is very simple 
            // we just need to pass a serial port and an output signal to control the "power key" signal

            // SIM800H serial device
            SerialDevice sim800SerialDevice = SerialDevice.FromId("COM2");

            // SIM800H signal for "power key"
            GpioPin sim800PowerKey = GpioController.GetDefault().OpenPin(0 * 1 + 10, GpioSharingMode.Exclusive);
            sim800PowerKey.SetDriveMode(GpioPinDriveMode.Output);

            Console.WriteLine("... Configuring SIM800H ...");

            // configure SIM800H device
            SIM800H.Configure(sim800PowerKey, ref sim800SerialDevice);

            // add event handler to be aware of network registration status changes
            SIM800H.GsmNetworkRegistrationChanged += SIM800H_GsmNetworkRegistrationChanged;

            // add event handler to be aware of GPRS network registration status changes
            SIM800H.GprsNetworkRegistrationChanged += SIM800H_GprsNetworkRegistrationChanged;

            // it's wise to set this event handler to get the warning conditions from the module in case of under-voltage, over temperature, etc.
            SIM800H.WarningConditionTriggered += SIM800H_WarningConditionTriggered;

            // because we need Internet connection the access point configuration (APN) is mandatory
            // the configuration depends on what your network operator requires
            // it may be just the access point name or it may require an user and password too
            // AccessPointConfiguration class provides a number of convenient options to create a new APN configuration
            SIM800H.AccessPointConfiguration = AccessPointConfiguration.Parse(APNConfigString);

            // async call to power on module 
            // in this example we are setting up a callback on a separate method
            SIM800H.PowerOnAsync(PowerOnCompleted);
            Console.WriteLine("... Power on sequence started ...");
        }

        private static void PowerOnCompleted(IAsyncResult result)
        {
            // check result
            if (((PowerOnAsyncResult)result).Result == PowerStatus.On)
            {
                Console.WriteLine("... Power on sequence completed...");
            }
            else
            {
                // something went wrong...
                Console.WriteLine("### Power on sequence FAILED ###");
            }
        }

        private static void SIM800H_GsmNetworkRegistrationChanged(NetworkRegistrationState networkState)
        {
            Console.WriteLine(networkState.GetDescription("GSM"));
        }

        private static void SIM800H_GprsNetworkRegistrationChanged(NetworkRegistrationState networkState)
        {
            Console.WriteLine(networkState.GetDescription("GPRS"));

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
                SIM800H.GprsProvider.OpenBearerAsync(BearerProfile.IpAppsBearer);
            }
        }

        private static void GprsProvider_GprsIpAppsBearerStateChanged(bool isOpen)
        {
            if (isOpen)
            {
                // launch a new thread to update the RTC from the NTP server
                new Thread(() =>
                {
                    Thread.Sleep(1000);

                    UpdateRTCFromNetwork();
                }).Start();
            }
        }

        private static void SIM800H_WarningConditionTriggered(WarningCondition warningCondition)
        {
            // get friendly string for this warning condition
            Console.WriteLine(SamplesExtensions.GetWarningDescription(warningCondition));
        }

        static void UpdateRTCFromNetwork()
        {
            Console.WriteLine("... requesting time from NTP server ...");

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // the following code block uses an async call to SNTP client which should be OK for most of the use scenarios
            // check an alternative in the code block commented bellow 

            SIM800H.SntpClient.SyncNetworkTimeAsync("pool.ntp.org", TimeSpan.Zero, (ar) =>
            {
                // update RTC only if update was successful
                if (((SyncNetworkTimeAsyncResult)ar).Result == SyncResult.SyncSuccessful)
                {
                    // get current date time and update RTC
                    DateTime rtcValue = SIM800H.GetDateTime();
                    // set framework date time
                    Rtc.SetSystemTime(rtcValue);

                    Console.WriteLine("!!! new time from NTP server: " + rtcValue.ToString());

                    // done here, dispose SNTP client to free up memory
                    SIM800H.SntpClient.Dispose();
                    SIM800H.SntpClient = null;
                }
                else
                {
                    Console.WriteLine("### failed to get time from NTP server ###");
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
            //        if (result == SyncResult.SyncSuccessful)
            //        {
            //            // get current date time and update RTC
            //            DateTime rtcValue = SIM800H.GetDateTime();
            //            // set framework date time
            //            Rtc.SetSystemTime(rtcValue);

            //            Console.WriteLine("!!! new time from NTP server: " + rtcValue.ToString());

            //            // done here, dispose SNTP client to free up memory
            //            SIM800H.SntpClient.Dispose();
            //            SIM800H.SntpClient = null;

            //            return;
            //        }
            //        else
            //        {
            //            Console.WriteLine("### failed to get time from NTP server ###");
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
