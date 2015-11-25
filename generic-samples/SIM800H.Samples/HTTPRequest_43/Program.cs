using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using System.IO.Ports;
using Eclo.NetMF.SIM800H;
using System.Text;

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
            SIM800H.AccessPointConfiguration = AccessPointConfiguration.Parse("internet.vodafone.pt|vodafone|vodafone");

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
                // launch a new thread to download weather data
                new Thread(() =>
                {
                    Thread.Sleep(1000);

                    DownloadWeatherData();
                }).Start();
            }
        }

        static void DownloadWeatherData()
        {
            // download weather data for Lisbon (Portugal) from Open Weather Data
            Debug.Print("... downloading weather data ...");


            /////////////////////////////////////////////
            // option 1: using .NETMF API like
            /////////////////////////////////////////////

            byte[] receivedBody = new byte[500];

            // create HTTTP web request with URI
            using (var webRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://api.openweathermap.org/data/2.5/weather?q=Lisbon,pt&appid=<replace-with-your-api-key>")))
            {
                // set method for the HTTP request
                webRequest.Method = "GET";

                // perform the request and get the response
                using (var res = webRequest.GetResponse() as HttpWebResponse)
                {
                    // read body data from response stream
                    using (var stream = res.GetResponseStream())
                    {
                        stream.Read(receivedBody, 0, receivedBody.Length);
                    }
                }               
            }

            // use a string builder to make body data printable
            StringBuilder sb = new StringBuilder();
            foreach (byte b in receivedBody)
            {
                sb.Append((char)b);
            }

            Debug.Print("******************************************************");
            Debug.Print(sb.ToString());
            Debug.Print("******************************************************");



            /////////////////////////////////////////////////
            // option 2: using the HTTP client of the driver 
            /////////////////////////////////////////////////

            using (var webRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://api.openweathermap.org/data/2.5/weather?q=Lisbon,pt&appid=<replace-with-your-api-key>")))
            {
                webRequest.Method = "GET";

                // perform the HTTP request asynchronously and set a callback handler to print the response
                SIM800H.HttpClient.PerformHttpWebRequestAsync(webRequest, true, false, (ar) =>
                {
                    // get the response
                    var response = ((HttpWebRequestAsyncResult)ar).HttpResponse;

                    // check if the HTTP request was successful
                    if(response.RequestSuccessful)
                    {
                        Debug.Print("******************************************************");

                        // grab body data as a string directly from the response
                        Debug.Print(response.BodyData);

                        Debug.Print("******************************************************");
                    }
                });
            }
        }
    }
}
