using Eclo.NETMF.SIM800H;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace SIM800HSamples
{
    public class Program
    {
        private const string APNConfigString = "<replace-with-apn-name>|<replace-with-apn-user>|<replace-with-apn-password>";
        private const string thingsSpeakApiKey = "<replace-with-your-api-key>";

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
                // launch a new thread to download weather data
                new Thread(() =>
                {
                    Thread.Sleep(1000);

                    UploadDataToChannel();
                }).Start();
            }
        }

        static void UploadDataToChannel()
        {
            // download weather data for Lisbon (Portugal) from Open Weather Data
            Debug.Print("... uploading data to channel ...");


            /////////////////////////////////////////////////////
            // option 1: using .NETMF API like and data on URL //
            /////////////////////////////////////////////////////

            byte[] receivedBody = new byte[500];

            // data to upload to channel
            double newData1 = 15.16;
            double newData2 = 11.12;

            // create HTTTP web request with URI
            using (var webRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://api.thingspeak.com/update?key=" + thingsSpeakApiKey + "&headers=false&field1=" + newData1.ToString("N2") + "&field2 = " + newData2.ToString("N2"))))
            {
                // set HTTP method for the request
                webRequest.Method = "POST";

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


            // need to wait 15 seconds to send new data to the same channel (ThingSpeak usage policy)
            Thread.Sleep(15000);


            ///////////////////////////////////////////////////////////////////
            // option 2: using the HTTP client of the driver and data on URL //
            ///////////////////////////////////////////////////////////////////

            newData1 = 18.19;
            newData2 = 17.18;

            using (var webRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://api.thingspeak.com/update?key=" + thingsSpeakApiKey + "&headers=false&field1=" + newData1.ToString("N2") + "&field2 = " + newData2.ToString("N2"))))
            {
                // set HTTP method for the request
                webRequest.Method = "POST";

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


            // need to wait 15 seconds to send new data to the same channel (ThingSpeak usage policy)
            Thread.Sleep(15000);


            //////////////////////////////////////////////////////////////////////////////////////////////
            // option 3: using the HTTP client of the driver, data in body and authentication in header //
            //////////////////////////////////////////////////////////////////////////////////////////////

            newData1 = 28.29;
            newData1 = 18.19;

            using (var webRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://api.thingspeak.com/update?&headers=false")))
            {
                // set HTTP method for the request
                webRequest.Method = "POST";

                // send authentication in a header 
                // check ThingsSpeak API documentation
                webRequest.Headers.Add("THINGSPEAKAPIKEY", thingsSpeakApiKey);

                // request data that will be send on the request body
                // there are two options to add request data
                // 1) in a stream using webRequest.GetRequestStream() for .NETMF API like usage
                // 2) as a string by setting the webRequest.Data field
                // for this example we'll be using option 2) which is the most straightforward

                webRequest.Data = "field1=" + newData1.ToString("N2");
                webRequest.Data += "\r\n" + "field2=" + newData2.ToString("N2");

                // perform the HTTP request asynchronously and set a callback handler to print the response
                SIM800H.HttpClient.PerformHttpWebRequestAsync(webRequest, true, false, (ar) =>
                {
                    // get the response
                    var response = ((HttpWebRequestAsyncResult)ar).HttpResponse;

                    // check if the HTTP request was successful
                    if (response.RequestSuccessful)
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
