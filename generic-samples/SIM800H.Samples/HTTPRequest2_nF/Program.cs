using Eclo.nF.SIM800H;
using System;
using System.Text;
using System.Threading;
using Windows.Devices.Gpio;
using Windows.Devices.SerialCommunication;

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
                // launch a new thread to download weather data
                new Thread(() =>
                {
                    Thread.Sleep(1000);

                    UploadDataToChannel();
                }).Start();
            }
        }

        private static void SIM800H_WarningConditionTriggered(WarningCondition warningCondition)
        {
            // get friendly string for this warning condition
            Console.WriteLine(SamplesExtensions.GetWarningDescription(warningCondition));
        }

        static void UploadDataToChannel()
        {
            // download weather data for Lisbon (Portugal) from Open Weather Data
            Console.WriteLine("... uploading data to channel ...");


            /////////////////////////////////////////////////////
            // option 1: using .NETMF API like and data on URL //
            /////////////////////////////////////////////////////

            byte[] receivedBody = new byte[500];

            // data to upload to channel
            double newData1 = 15.16;
            double newData2 = 11.12;
/*
            // create HTTTP web request with URI
            using (var webRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://api.thingspeak.com/update?key=" + thingsSpeakApiKey + "&headers=false&field1=" + newData1.ToString("N2") + "&field2 = " + newData2.ToString("N2"))))
            {
                // set HTTP method for the request
                webRequest.Method = "POST";

                // perform the request and get the response
                using (var res = webRequest.GetResponse() as HttpWebResponse)
                {
                    Console.WriteLine("******************************************************");
                    Console.WriteLine(res.BodyData);
                    Console.WriteLine("******************************************************");
                }
            }

            // need to wait 15 seconds to send new data to the same channel (ThingSpeak usage policy)
            Thread.Sleep(15000);
*/

            ///////////////////////////////////////////////////////////////////
            // option 2: using the HTTP client of the driver and data on URL //
            ///////////////////////////////////////////////////////////////////
/*
            newData1 = 18.19;
            newData2 = 17.18;

            using (var webRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://api.thingspeak.com/update?key=" + thingsSpeakApiKey + "&headers=false&field1=" + newData1.ToString("N2") + "&field2 = " + newData2.ToString("N2"))))
            {
                // set HTTP method for the request
                webRequest.Method = "POST";

                // perform the HTTP request asynchronously and set a callback handler to print the response
                SIM800H.HttpClient.PerformHttpWebRequestAsync(webRequest, true, false, true, 5000, (ar) =>
                {
                    // get the response
                    var response = ((HttpWebRequestAsyncResult)ar).HttpResponse;

                    // check if the HTTP request was successful
                    if (response.RequestSuccessful)
                    {
                        Console.WriteLine("******************************************************");

                        // grab body data as a string directly from the response
                        Console.WriteLine(response.BodyData);

                        Console.WriteLine("******************************************************");
                    }
                });
            }


            // need to wait 15 seconds to send new data to the same channel (ThingSpeak usage policy)
            Thread.Sleep(15000);
*/

            //////////////////////////////////////////////////////////////////////////////////////////////
            // option 3: using the HTTP client of the driver, data in body and authentication in header //
            //////////////////////////////////////////////////////////////////////////////////////////////

            newData1 = 28.29;
            newData2 = 18.19;

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
                webRequest.Data += "\r\n" + "&field2=" + newData2.ToString("N2");

                // perform the HTTP request asynchronously and set a callback handler to print the response
                SIM800H.HttpClient.PerformHttpWebRequestAsync(webRequest, true, false, true, 5000, (ar) =>
                {
                    // get the response
                    var response = ((HttpWebRequestAsyncResult)ar).HttpResponse;

                    // check if the HTTP request was successful
                    if (response.RequestSuccessful)
                    {
                        Console.WriteLine("******************************************************");

                        // grab body data as a string directly from the response
                        Console.WriteLine(response.BodyData);

                        Console.WriteLine("******************************************************");
                    }
                });
            }

        }
    }
}
