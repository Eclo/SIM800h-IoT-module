[![Join the chat at https://gitter.im/Eclo/SIM800h-IoT-module](https://badges.gitter.im/Eclo/SIM800h-IoT-module.svg)](https://gitter.im/Eclo/SIM800h-IoT-module?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

# SIM800H IoT module

You've found the GitHub repository for development resources related to Eclo Solutions SIM800H IoT module.

Please navigate to the project [web page](http://eclo.github.io/SIM800h-IoT-module) for details and specs.

## .NET nanoFramework Driver

[![NuGet](https://img.shields.io/nuget/v/Eclo.nanoFramework.SIM800H.svg?style=plastic)](https://www.nuget.org/packages/Eclo.nanoFramework.SIM800H)

We actively maintain a .NET nanoFramework driver for this module. It's provided as as a [Nuget package](https://www.nuget.org/packages/Eclo.nanoFramework.SIM800H/).

Check the documentation [here](http://eclo.github.io/SIM800h-IoT-module/nf-docs/api/Eclo.nF.SIM800H.html).

## .NET Micro Framework Driver

[![NuGet](https://img.shields.io/nuget/v/Eclo.NetMF.SIM800H.svg?style=plastic)](https://www.nuget.org/packages/Eclo.NetMF.SIM800H)

We provide driver for the legacy .NET Micro Framework. For ease of use it's provided as a [Nuget package](https://www.nuget.org/packages/Eclo.NetMF.SIM800H/). 

Check the documentation [here](http://eclo.github.io/SIM800h-IoT-module/netmf-driver-help/).

## Sample projects

There are a number of sample projects organized in solutions.
(all projects are available for nanoFramework and .NETMF v4.3 and v4.4)
  
### Generic sample projects

| Sample | .NET nanoFramework | .NETMF |
|:-|:-:|:-:|
| Basic initialization | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/Initialization_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/Initialization_43) |
| Text message (SMS) send/receive | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/SMS_Send_Receive_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/SMS_Send_Receive_43) |
| Text message (SMS) management | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/SMS_List_Messages_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/SMS_List_Messages_43) |
| NTP client | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/NTP_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/NTP_43) |
| HTTP client with GET (weather data) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/HTTPRequest_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/HTTPRequest_43) |
| HTTP client with POST (send data to ThingSpeak) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/HTTPRequest2_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/HTTPRequest2_43) |
| HTTP client downloading a file | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/HTTPRequest3_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/HTTPRequest3_43) |
| Get Time and Location | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/LocationAndTime_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/LocationAndTime_43) |
| Power Mode example | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/PowerMode_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/PowerMode_43) |
| MMS message send | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/MMS_nF) | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/generic-samples/SIM800H.Samples/MMS_43) |

### Azure IoT Hub client

| Sample | .NET nanoFramework | .NETMF |
|:-|:-:|:-:|
| HTTP client | [:heavy_multiplication_x:]() | [:heavy_check_mark:](https://github.com/Eclo/SIM800h-IoT-module/tree/master/Azure-IoT-Hub-samples/HTTP) |
| AMQP client (coming soon) |  |  |

## Eagle library

Download the Eagle CAD library with the module footprint and component [here](https://github.com/Eclo/SIM800h-IoT-module/raw/Eagle_library/eclo_sim800h_module.lbr).
