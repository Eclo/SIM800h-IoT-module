using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using System.IO.Ports;
using Eclo.NetMF.SIM800H;

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

                // read module IMEI 
                Debug.Print("IMEI: " + SIM800H.IMEI);

                // read module firmware version
                Debug.Print("Fw: " + SIM800H.SoftwareRelease);
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
    }
}
