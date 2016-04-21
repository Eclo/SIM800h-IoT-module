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

            // it's wise to set this event handler to get the warning conditions from the module in case of under-voltage, over temperature, etc.
            SIM800H.WarningConditionTriggered += SIM800H_WarningConditionTriggered;

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

            // setup event handler to be notified when a new SMS arrives
            // because we may receive this event more than once (module wake-up, reboot, intermittent registration in network, etc.
            // it's advisable to always remove the handler before adding it this way we'll be sure that only one event handle is setup

            SIM800H.SmsProvider.SmsReceived -= SmsProvider_SmsReceived;
            SIM800H.SmsProvider.SmsReceived += SmsProvider_SmsReceived;

            // launch a new thread to send an SMS in 2 seconds
            new Thread(() =>
            {
                Thread.Sleep(1000);

                // send SMS asynchronously 
                // set a callback to check the outcome 
                // replace the White House switch board number bellow with a valid mobile number 
                // the number must ALWAYS include the country code and international prefix
                SIM800H.SmsProvider.SendTextMessageAsync("+12025551212", "Hello from SIM800H module", (ar) =>
                    {
                        if(((SendTextMessageAsyncResult)ar).Reference == -1)
                        {
                            // something went wrong...
                            Debug.Print("### FAILED sending SMS ###");
                        } 
                        else
                        {
                            Debug.Print("... SMS sent ...");
                        }
                    }
                );

            }).Start();

        }

        private static void SmsProvider_SmsReceived(byte messageIndex)
        {
            // the handler receives the index of the message received
            // now we need to actually read the message
            // as an optional argument we can delete the message from the memory after being read
            var message = SIM800H.SmsProvider.ReadTextMessage(messageIndex, true);

            Debug.Print("******************************************************");
            Debug.Print("Message from " + message.TelephoneNumber);
            Debug.Print("Received @ " + message.Timestamp);
            Debug.Print("«" + message.Text + "»");
            Debug.Print("******************************************************");
        }

        private static void SIM800H_GsmNetworkRegistrationChanged(NetworkRegistrationState networkState)
        {
            Debug.Print(networkState.GetDescription("GSM"));
        }

        private static void SIM800H_WarningConditionTriggered(WarningCondition warningCondition)
        {
            // get friendly string for this warning condition
            Debug.Print(SamplesExtensions.GetWarningDescription(warningCondition));
        }
    }
}
