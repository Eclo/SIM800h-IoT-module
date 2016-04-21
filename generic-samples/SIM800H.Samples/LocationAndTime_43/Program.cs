using Eclo.NETMF.SIM800H;
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
                // launch a new thread to get time and location from network
                new Thread(() =>
                {
                    Thread.Sleep(1000);

                    LocationAndTime lt = SIM800H.GetTimeAndLocation();

                    if (lt.ErrorCode == 0)
                    {
                        // request successfull
                        Debug.Print("Network time " + lt.DateTime.ToString() + " GMT");
                        Debug.Print("Location http://www.bing.com/maps/?v=2&form=LMLTSN&cp=" + lt.Latitude.ToString() + "~" + lt.Longitude.ToString() + "&lvl=17&sty=r&encType=1");
                    }
                    else
                    {
                        // failed to retrieve time and location from network
                        Debug.Print("### Failed to retrieve time and location from network. Error code: " + lt.ErrorCode.ToString() + " ###");
                    }

                }).Start();
            }
        }

        private static void SIM800H_WarningConditionTriggered(WarningCondition warningCondition)
        {
            // get friendly string for this warning condition
            Debug.Print(SamplesExtensions.GetWarningDescription(warningCondition));
        }
    }
}
