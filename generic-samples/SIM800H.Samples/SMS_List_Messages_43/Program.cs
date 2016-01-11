using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using System.IO.Ports;
using Eclo.NETMF.SIM800H;

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

            // add event handler to be aware of network registration status changes
            SIM800H.GsmNetworkRegistrationChanged += SIM800H_GsmNetworkRegistrationChanged;

            // configure SIM800H device
            SIM800H.Configure(sim800PowerKey, sim800SerialPort);

            // set event handler for SMS ready 
            SIM800H.SmsReady += SIM800H_SmsReady;

            // async call to power on module 
            // in this example we are implementing the callback in line
            SIM800H.PowerOnAsync((ar) =>
                {
                    // check result
                    if (((PowerOnAsyncResult)ar).Result == PowerStatus.On)
                    {
                        Debug.Print("... Power on sequence completed...");
                    }
                    else
                    {
                        // something went wrong...
                        Debug.Print("### Power on sequence FAILED ###");
                    }
                }
            );

            Microsoft.SPOT.Debug.Print("... Power on sequence started ...");
        }

        private static void SIM800H_SmsReady()
        {
            Debug.Print("... SIM800H SMS engine is ready ...");

            // launch a new thread to send an SMS in 2 seconds
            new Thread(() =>
            {
                Thread.Sleep(1000);

                // list all **UNREAD** SMSs available in memory
                // make this call synchronous to use the list right away
                var smsList = SIM800H.SmsProvider.ListTextMessagesAsync(MessageState.ReceivedUnread).End();

                foreach(byte index in smsList)
                {
                    // output message
                    var message = SIM800H.SmsProvider.ReadTextMessage(index, true);

                    Debug.Print("******************************************************");
                    Debug.Print("Message from " + message.TelephoneNumber);
                    Debug.Print("Received @ " + message.Timestamp);
                    Debug.Print("«" + message.Text + "»");
                    Debug.Print("******************************************************");
                }
            }).Start();
        }

        private static void SIM800H_GsmNetworkRegistrationChanged(NetworkRegistrationState networkState)
        {
            Debug.Print(networkState.GetDescription("GSM"));
        }
    }
}
