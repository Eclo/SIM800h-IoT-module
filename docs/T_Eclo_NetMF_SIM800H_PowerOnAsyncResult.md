# PowerOnAsyncResult Class
 _**\[This is preliminary documentation and is subject to change.\]**_

An asynchronous result object returning the result of a Power on sequence execution


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="T_Eclo_NetMF_SIM800H_DeviceAsyncResult">Eclo.NetMF.SIM800H.DeviceAsyncResult</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Eclo.NetMF.SIM800H.PowerOnAsyncResult<br />
**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public class PowerOnAsyncResult : DeviceAsyncResult
```

The PowerOnAsyncResult type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_PowerOnAsyncResult__ctor">PowerOnAsyncResult</a></td><td>
Initializes a new instance of the PowerOnAsyncResult class</td></tr></table>&nbsp;
<a href="#poweronasyncresult-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_DeviceAsyncResult_AsyncState">AsyncState</a></td><td>
The state object stored against this AsyncResult
 (Inherited from <a href="T_Eclo_NetMF_SIM800H_DeviceAsyncResult">DeviceAsyncResult</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_DeviceAsyncResult_AsyncWaitHandle">AsyncWaitHandle</a></td><td>
The WaitHandle for this AsyncResult
 (Inherited from <a href="T_Eclo_NetMF_SIM800H_DeviceAsyncResult">DeviceAsyncResult</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_DeviceAsyncResult_CompletedSynchronously">CompletedSynchronously</a></td><td>
Returns `true` if this AsyncResult has been completed synchronously
 (Inherited from <a href="T_Eclo_NetMF_SIM800H_DeviceAsyncResult">DeviceAsyncResult</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_DeviceAsyncResult_IsCompleted">IsCompleted</a></td><td>
Returns `true` if this AsyncResult has been completed
 (Inherited from <a href="T_Eclo_NetMF_SIM800H_DeviceAsyncResult">DeviceAsyncResult</a>.)</td></tr></table>&nbsp;
<a href="#poweronasyncresult-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_PowerOnAsyncResult_End">End</a></td><td>
Finishes the asynchronous processing and throws an exception if one was generated 

## Remarks
Blocks until the asynchronous processing has completed</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_PowerOnAsyncResult_Process">Process</a></td><td>
The method used to perform the asynchronous processing
 (Overrides <a href="M_Eclo_NetMF_SIM800H_DeviceAsyncResult_Process">DeviceAsyncResult.Process()</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#poweronasyncresult-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public field](media/pubfield.gif "Public field")</td><td><a href="F_Eclo_NetMF_SIM800H_PowerOnAsyncResult_Result">Result</a></td><td>
Result of power sequence</td></tr></table>&nbsp;
<a href="#poweronasyncresult-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />