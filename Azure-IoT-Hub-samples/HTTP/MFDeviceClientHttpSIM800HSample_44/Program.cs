using Eclo.NetMF.SIM800H;
using Microsoft.Azure.Devices.Client;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace MFTestApplication
{
    public class Program
    {
        private const string DeviceConnectionString = "<replace>";
        private static int MESSAGE_COUNT = 5;

        public static void Main()
        {
            try
            {
                InitializeSIM800H();
            }
            catch { };

            while (true)
            {
                Microsoft.SPOT.Debug.EnableGCMessages(false);
                Microsoft.SPOT.Debug.Print("Free RAM: " + Microsoft.SPOT.Debug.GC(false).ToString());

                Thread.Sleep(5000);
            };
        }

        static void SendEvent(DeviceClient deviceClient)
        {
            string dataBuffer;

            Debug.Print("Device sending " + MESSAGE_COUNT + " messages to IoTHub...");

            for (int count = 0; count < MESSAGE_COUNT; count++)
            {
                dataBuffer = Guid.NewGuid().ToString();
                Message eventMessage = new Message(Encoding.UTF8.GetBytes(dataBuffer));
                Debug.Print(DateTime.Now.ToLocalTime() + "> Sending message: " + count + ", Data: [" + dataBuffer + "]");

                deviceClient.SendEvent(eventMessage);
            }
        }

        static void ReceiveCommands(DeviceClient deviceClient)
        {
            Debug.Print("Device waiting for commands from IoTHub...");
            Message receivedMessage;
            string messageData;

            while (true)
            {
                receivedMessage = deviceClient.Receive();

                if (receivedMessage != null)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (byte b in receivedMessage.GetBytes())
                    {
                        sb.Append((char)b);
                    }

                    messageData = sb.ToString();

                    // dispose string builder
                    sb = null;

                    Debug.Print(DateTime.Now.ToLocalTime() + "> Received message: " + messageData);

                    deviceClient.Complete(receivedMessage);
                }

                Thread.Sleep(10000);
            }
        }

        static void InitializeSIM800H()
        {
            // SIM800H power key
            OutputPort sim800PowerKey = new OutputPort(Cpu.Pin.GPIO_Pin6, false);
            // SIM800H serial port
            SerialPort sim800SerialPort = new SerialPort("COM2");

            // configure SIM800H device
            SIM800H.Configure(sim800PowerKey, sim800SerialPort);

            // set max GPRS sockets to 2
            SIM800H.MaxSockets = 2;

            // register eventhandlers for network
            SIM800H.GsmNetworkRegistrationChanged += SIM800H_GsmNetworkRegistrationChanged;
            SIM800H.GprsNetworkRegistrationChanged += SIM800_GprsNetworkRegistrationChanged;

            // set APN config
            // better do this inside a try/catch because value can be invalid
            try
            {
                SIM800H.AccessPointConfiguration = AccessPointConfiguration.Parse("<replace>");
            }
            catch
            {
                // something wrong with APN config
                Debug.Print("### FAILED to set APN config ###");
            };

            // power on radio
            SIM800H.PowerOnAsync((a) =>
            {
                // power on sequence completed
                // check result
                if (((PowerOnAsyncResult)a).Result == PowerStatus.On)
                {
                    Debug.Print("...Power on sequence completed...");
                }
                else
                {
                    // something went wrong...
                    Debug.Print("### Power on sequence FAILED ###");
                }
            });
        }

        private static void SIM800H_GsmNetworkRegistrationChanged(NetworkRegistrationState networkState)
        {
            if (networkState == NetworkRegistrationState.Registered)
            {
                Debug.Print("...GSM network registered...");
            }
        }

        static void SIM800_GprsNetworkRegistrationChanged(NetworkRegistrationState networkState)
        {
            if (networkState == NetworkRegistrationState.Registered)
            {
                Debug.Print("...GPRS network registered...");

                // add event handlers but remove them first so we don't have duplicate calls in case this a new registration
                SIM800H.GprsProvider.GprsIpAppsBearerStateChanged -= GprsProvider_GprsIpAppsBearerStateChanged;
                SIM800H.GprsProvider.GprsIpAppsBearerStateChanged += GprsProvider_GprsIpAppsBearerStateChanged;

                // open GPRS bearer async
                SIM800H.GprsProvider.OpenBearerAsync((a) => 
                {
                    Eclo.NetMF.SIM800H.Gprs.OpenBearerAsyncResult result = (Eclo.NetMF.SIM800H.Gprs.OpenBearerAsyncResult)a;
                    if (result.Result == Eclo.NetMF.SIM800H.Gprs.OpenBearerResult.Open)
                    {
                        // GPRS bearer open 
                        Debug.Print("...GPRS bearer open...");
                    }
                    else if (!(result.Result == Eclo.NetMF.SIM800H.Gprs.OpenBearerResult.Open ||
                            result.Result == Eclo.NetMF.SIM800H.Gprs.OpenBearerResult.AlreadyOpen))
                    {
                        // failed to open GPRS bearer
                        Debug.Print("### FAILED to open GPRS bearer ###");
                    }
                });
            }
        }

        static void GprsProvider_GprsIpAppsBearerStateChanged(bool isOpen)
        {
            if (isOpen)
            {
                // we have an open GPRS bearer for IP apps
                // start doing the thing...
                new Thread(() =>
                {
                    Thread.Sleep(1000);

                    // update RTC
                    UpdateRTCFromNetwork();

                    DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(DeviceConnectionString, TransportType.Http1);

                    SendEvent(deviceClient);
                    ReceiveCommands(deviceClient);
                }).Start();
            }
        }

        static void SetupGprsConnection()
        {
            // open GPRS sockets connection async
            SIM800H.GprsProvider.OpenGprsConnectionAsync((a) =>
            {
                Eclo.NetMF.SIM800H.Gprs.ConnectGprsAsyncResult result = (Eclo.NetMF.SIM800H.Gprs.ConnectGprsAsyncResult)a;
                if (!(result.Result == Eclo.NetMF.SIM800H.Gprs.ConnectGprsResult.Open ||
                    result.Result == Eclo.NetMF.SIM800H.Gprs.ConnectGprsResult.AlreadyOpen))
                {
                    // failed to open GPRS sockets connection
                    Debug.Print("### FAILED to open GPRS connection ###");
                }
            });
        }

        static void UpdateRTCFromNetwork()
        {
            byte retryCounter = 0;

            while (retryCounter <= 3)
            {
                try
                {
                    var request = SIM800H.SntpClient.SyncNetworkTimeAsync("time.nist.gov", TimeSpan.Zero);
                    var result = request.End();

                    // check result
                    if (result == Eclo.NetMF.SIM800H.Sntp.SyncResult.SyncSuccessful)
                    {
                        // get current date time and update RTC
                        DateTime rtcValue = SIM800H.GetDateTime();
                        // set framework date time
                        Utility.SetLocalTime(rtcValue);

                        // done here, dispose SNTP client to free up memory
                        SIM800H.SntpClient = null;

                        return;
                    }
                }
                catch
                {
                    // failed updating RTC
                    Debug.Print("### FAILED updating RTC ###");
                }

                // add retry
                retryCounter++;

                // progressive wait 15*N seconds before next retry
                Thread.Sleep(15000 * retryCounter);
            }
        }
    }
}
