# DeviceAsyncResult Class
 _**\[This is preliminary documentation and is subject to change.\]**_

An asynchronous result object


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Eclo.NetMF.SIM800H.DeviceAsyncResult<br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="#inheritance-hierarchy" />
**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public class DeviceAsyncResult : IAsyncResult
```

The DeviceAsyncResult type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_DeviceAsyncResult__ctor">DeviceAsyncResult</a></td><td>
Creates an AsyncResult</td></tr></table>&nbsp;
<a href="#deviceasyncresult-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_DeviceAsyncResult_AsyncState">AsyncState</a></td><td>
The state object stored against this AsyncResult</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_DeviceAsyncResult_AsyncWaitHandle">AsyncWaitHandle</a></td><td>
The WaitHandle for this AsyncResult</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_DeviceAsyncResult_CompletedSynchronously">CompletedSynchronously</a></td><td>
Returns `true` if this AsyncResult has been completed synchronously</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_DeviceAsyncResult_IsCompleted">IsCompleted</a></td><td>
Returns `true` if this AsyncResult has been completed</td></tr></table>&nbsp;
<a href="#deviceasyncresult-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_DeviceAsyncResult_End">End</a></td><td>
Finishes the asynchronous processing and throws an exception if one was generated 

## Remarks
Blocks until the asynchronous processing has completed</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_DeviceAsyncResult_Process">Process</a></td><td>
The method used to perform the asynchronous processing</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#deviceasyncresult-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />

## Inheritance Hierarchy<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Eclo.NetMF.SIM800H.DeviceAsyncResult<br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Eclo_NetMF_SIM800H_Gprs_ConnectGprsAsyncResult">Eclo.NetMF.SIM800H.Gprs.ConnectGprsAsyncResult</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Eclo_NetMF_SIM800H_Gprs_OpenBearerAsyncResult">Eclo.NetMF.SIM800H.Gprs.OpenBearerAsyncResult</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Eclo_NetMF_SIM800H_Http_HttpWebRequestAsyncResult">Eclo.NetMF.SIM800H.Http.HttpWebRequestAsyncResult</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Eclo_NetMF_SIM800H_PowerOnAsyncResult">Eclo.NetMF.SIM800H.PowerOnAsyncResult</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Eclo_NetMF_SIM800H_Sms_ReadMessageListAsyncResult">Eclo.NetMF.SIM800H.Sms.ReadMessageListAsyncResult</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Eclo_NetMF_SIM800H_Sms_SendMessageAsyncResult">Eclo.NetMF.SIM800H.Sms.SendMessageAsyncResult</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Eclo_NetMF_SIM800H_Sntp_SyncNetworkTimeAsyncResult">Eclo.NetMF.SIM800H.Sntp.SyncNetworkTimeAsyncResult</a><br />