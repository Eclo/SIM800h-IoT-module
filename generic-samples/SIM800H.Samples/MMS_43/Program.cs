using Eclo.NETMF.SIM800H;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SIM800HSamples.Properties;
using System;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace SIM800HSamples
{
    public class Program
    {
        private const string MmsApnConfigString = "<replace-with-apn-name>|<replace-with-apn-user>|<replace-with-apn-password>";
        private const string mmsUrl = "<replace-with-mms-url>";
        private const string mmsProxy = "<replace-with-mms-proxy-IP>";
        private const int mmsPort = 80;// default
        // mind that the max accepted lenght is 40 chars
        private const string mmsTitle = "<replace-with-mms-title>";
        // mind that the max accepted lenght is 15360 chars
        private const string mmsText = "<replace-with-mms-text>";
        private const string mmsImageFileName = "<replace-with-mms-image-file-name>.jpg";
        private const string mmsDestination = "<replace-with-mms-destination-number-or-email>";

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

            // because we need Internet connection the access point configuration (APN) for MMS is mandatory
            // the configuration depends on what your network operator requires
            // it may be just the access point name or it may require an user and password too
            // AccessPointConfiguration class provides a number of convenient options to create a new APN configuration
            SIM800H.MmsAccessPointConfiguration = AccessPointConfiguration.Parse(MmsApnConfigString);

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
                SIM800H.GprsProvider.MmsBearerStateChanged -= GprsProvider_MmsBearerStateChanged;
                SIM800H.GprsProvider.MmsBearerStateChanged += GprsProvider_MmsBearerStateChanged; ;

                // async call to GPRS provider to open the GPRS bearer
                // we can set a callback here to get the result of that request and act accordingly
                // or we can manage this in the GprsIpAppsBearerStateChanged event handler that we've already setup during the configuration
                SIM800H.GprsProvider.OpenBearerAsync(BearerProfile.MmsBearer);
            }
        }

        private static void GprsProvider_MmsBearerStateChanged(bool isOpen)
        {
            if (isOpen)
            {
                // launch a new thread to...
                new Thread(() =>
                {
                    // set MMS configuration
                    SIM800H.MmsConfiguration = new MmsConfiguration(mmsUrl, mmsProxy, mmsPort);

                    // build and send MMS message

                    // for this example we are reading the image from the application Resources
                    // in a real world application this could be stored in memory, SD card or any other storage media that can be read as a stream (image is optional)
                    // text for message is a string (is optional)
                    // title is a string (is optional)
                    MmsMessage msg = new MmsMessage(mmsText, Resources.GetBytes(Resources.BinaryResources.mmsImg), mmsTitle);

                    // make sure the GPRS bearer is opened before sending an MMS
                    // when sending an MMS there is an optional parameter to specify if the GPRS connection is to be closed after sending the message, this maybe relevant is your app needs to be power wise
                    SIM800H.MmsClient.SendMmsMessageAsync(mmsDestination, msg, true, (r) =>
                    {
                        // check if MMS was sent successfully
                        if (((SendMmsMessageAsyncResult)r).Result)
                        {
                            Debug.Print("MMS sent successfully!");
                        }
                        else
                        {
                            Debug.Print("### Error sending MMS. Error code: " + ((SendMmsMessageAsyncResult)r).ErrorCode.ToString() + " ###");
                        }
                    });

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
