# SIM800H Class
 _**\[This is preliminary documentation and is subject to change.\]**_

Class with methods, properties and events to work with a SIM800H module.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Eclo.NetMF.SIM800H.SIM800H<br />
**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public class SIM800H : IDisposable
```

The SIM800H type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_GprsIpAppsBearerIsOpen">GprsIpAppsBearerIsOpen</a></td><td>
Status of IP apps bearer in profile 1 of GPRS context</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_GprsNetworkRegistration">GprsNetworkRegistration</a></td><td>
GPRS network registration state of module</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_GprsProvider">GprsProvider</a></td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_GprsProvider">GprsProvider</a> property with all the methods required to use the GPRS features</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_GprsSocketsBearerIsOpen">GprsSocketsBearerIsOpen</a></td><td>
Status of sockets bearer in profile 0 of GPRS context</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_GsmNetworkRegistration">GsmNetworkRegistration</a></td><td>
GSM network registration state of module</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_HttpClient">HttpClient</a></td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_HttpClient">HttpClient</a> property with all the methods required to perform HTTP requests</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_IMEI">IMEI</a></td><td>
Retrieves the device's IMEI</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_IpAddress">IpAddress</a></td><td>
IP address of module</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_MaxSockets">MaxSockets</a></td><td>
Maximum number of sockets supported. SIM800H module supports up to 6. When setting this properties, any existing socket will be closed and becomes unavailale.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_ModelIdentification">ModelIdentification</a></td><td>
Module model identification</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_PowerStatus">PowerStatus</a></td><td>
Power status of SIM800H device</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_SerialInterfaceBaudRate">SerialInterfaceBaudRate</a></td><td>
Retrieves baud rate for serial interface</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_SIMCardStatus">SIMCardStatus</a></td><td>
Get SIM card status</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_SmsProvider">SmsProvider</a></td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_SmsProvider">SmsProvider</a> property with all the methods required to send SMS (text) messages</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_SmsStatusReport">SmsStatusReport</a></td><td>
Enable Sms status report</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_SntpClient">SntpClient</a></td><td><a href="T_Eclo_NetMF_SIM800H_Sntp">Sntp</a> property with all the methods required to user the SNTP (Simple Network Time Protocol) client</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_SoftwareRelease">SoftwareRelease</a></td><td>
Module software release</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Eclo_NetMF_SIM800H_SIM800H_SupplyVoltage">SupplyVoltage</a></td><td>
Retrieves supply voltage.</td></tr></table>&nbsp;
<a href="#sim800h-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_Configure">Configure</a></td><td>
Configure hardware interface with the device.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_Dispose">Dispose</a></td><td>
Releases all resources used by the SIM800H</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_GetDateTime">GetDateTime</a></td><td>
Retrieves date time from device's clock. For correct date time the clock must be set either programatically or using SNTP service</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_GetTimeAndLocation">GetTimeAndLocation</a></td><td>
Retrieves time and optionally location of the device, as reported by the time and location service. Needs to have GPRS connection active.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_PowerOff">PowerOff</a></td><td>
Powers off the SIM800H module</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_PowerOnAsync">PowerOnAsync</a></td><td>
Starts an asynchronous operation to run the power on sequence</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_Reset">Reset</a></td><td>
Resets the device</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_RetrieveOperator">RetrieveOperator</a></td><td>
Retrieves the operator wich the device is registered to</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_RetrievePinState">RetrievePinState</a></td><td>
Retrieves the pin state of the SIM</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_RetrieveSignalStrength">RetrieveSignalStrength</a></td><td>
Get the signalstrenght of the cellular network</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_SetPhoneFuncionality">SetPhoneFuncionality</a></td><td>
Set phone funcionality</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_SIM800H_SetSerialInterfaceBaudRate">SetSerialInterfaceBaudRate</a></td><td>
Set baud rate for serial interface</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#sim800h-class">Back to Top</a>

## Events
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public event](media/pubevent.gif "Public event")![Static member](media/static.gif "Static member")</td><td><a href="E_Eclo_NetMF_SIM800H_SIM800H_CallReady">CallReady</a></td><td>
Event raised when the device reports that is ready for calls.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")![Static member](media/static.gif "Static member")</td><td><a href="E_Eclo_NetMF_SIM800H_SIM800H_GprsNetworkRegistrationChanged">GprsNetworkRegistrationChanged</a></td><td>
Event raised when the status of the GPRS registration changes.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")![Static member](media/static.gif "Static member")</td><td><a href="E_Eclo_NetMF_SIM800H_SIM800H_GsmNetworkRegistrationChanged">GsmNetworkRegistrationChanged</a></td><td>
Event raised when the status of the GSM network registration changes.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Eclo_NetMF_SIM800H_SIM800H_PowerStatusChanged">PowerStatusChanged</a></td><td>
Event raised when the power status of the device changes.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Eclo_NetMF_SIM800H_SIM800H_SimCardStatusChanged">SimCardStatusChanged</a></td><td>
Event raised when the status of the SIM card changes.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")![Static member](media/static.gif "Static member")</td><td><a href="E_Eclo_NetMF_SIM800H_SIM800H_SmsReady">SmsReady</a></td><td>
Event raised when the device reports that the SMS features are ready.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")![Static member](media/static.gif "Static member")</td><td><a href="E_Eclo_NetMF_SIM800H_SIM800H_SmsSentReferenceReceived">SmsSentReferenceReceived</a></td><td>
Event raised when the device receives a new SMS message.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Eclo_NetMF_SIM800H_SIM800H_WarningConditionTriggered">WarningConditionTriggered</a></td><td>
Event raised when there is a warning condition reported by the device.</td></tr></table>&nbsp;
<a href="#sim800h-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Eclo_NetMF_SIM800H_SIM800H_AccessPointConfiguration">AccessPointConfiguration</a></td><td>
GPRS access point configuration (APN)</td></tr></table>&nbsp;
<a href="#sim800h-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />