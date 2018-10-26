using Eclo.nF.SIM800H;
using System;
using System.Threading;
using Windows.Devices.Gpio;
using Windows.Devices.SerialCommunication;

namespace SIM800HSamples
{
    public class Program
    {
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

            // add event handler to be aware of network registration status changes
            SIM800H.GsmNetworkRegistrationChanged += SIM800H_GsmNetworkRegistrationChanged;

            // it's wise to set this event handler to get the warning conditions from the module in case of under-voltage, over temperature, etc.
            SIM800H.WarningConditionTriggered += SIM800H_WarningConditionTriggered;

            // configure SIM800H device
            SIM800H.Configure(sim800PowerKey, ref sim800SerialDevice);

            // set event handler for SMS ready 
            SIM800H.SmsReady += SIM800H_SmsReady;

            // async call to power on module 
            // in this example we are implementing the callback in line
            SIM800H.PowerOnAsync((ar) =>
            {
                // check result
                if (((PowerOnAsyncResult)ar).Result == PowerStatus.On)
                {
                    Console.WriteLine("... Power on sequence completed...");
                }
                else
                {
                    // something went wrong...
                    Console.WriteLine("### Power on sequence FAILED ###");
                }
            }
            );

            Console.WriteLine("... Power on sequence started ...");
        }

        private static void SIM800H_SmsReady()
        {
            Console.WriteLine("... SIM800H SMS engine is ready ...");

            // launch a new thread to send an SMS in 2 seconds
            new Thread(() =>
            {
                Thread.Sleep(1000);

                // list all **UNREAD** SMSs available in memory
                // make this call synchronous to use the list right away
                var smsList = SIM800H.SmsProvider.ListTextMessagesAsync(MessageState.ReceivedUnread).End();

                foreach (byte index in smsList)
                {
                    // output message
                    var message = SIM800H.SmsProvider.ReadTextMessage(index, true);

                    Console.WriteLine("******************************************************");
                    Console.WriteLine("Message from " + message.TelephoneNumber);
                    Console.WriteLine("Received @ " + message.Timestamp);
                    Console.WriteLine("�" + message.Text + "�");
                    Console.WriteLine("******************************************************");
                }
            }).Start();
        }

        private static void SIM800H_GsmNetworkRegistrationChanged(NetworkRegistrationState networkState)
        {
            Console.WriteLine(networkState.GetDescription("GSM"));
        }

        private static void SIM800H_WarningConditionTriggered(WarningCondition warningCondition)
        {
            // get friendly string for this warning condition
            Console.WriteLine(SamplesExtensions.GetWarningDescription(warningCondition));
        }
    }
}
