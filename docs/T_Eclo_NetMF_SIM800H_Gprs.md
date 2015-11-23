# Gprs Class
 _**\[This is preliminary documentation and is subject to change.\]**_

Class with methods to perform GPRS related actions.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Eclo.NetMF.SIM800H.Gprs<br />
**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public class Gprs : IDisposable
```

The Gprs type exposes the following members.


## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_Gprs_CheckConnectionStatus">CheckConnectionStatus</a></td><td>
Queries current status of a specific GPRS connection</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_Gprs_CheckIpAppBearerStatus">CheckIpAppBearerStatus</a></td><td>
Queries IP apps bearer context in profile 1 to check if it's opened. On successfull execution context open status is updated in GprsIpAppsBearerIsOpen property</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_Gprs_CloseIpAppBearer">CloseIpAppBearer</a></td><td>
Closes IP apps bearer in profile 1 of GPRS context</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_Gprs_DetachGprs">DetachGprs</a></td><td>
Detach GPRS</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_Gprs_Dispose">Dispose</a></td><td>
Releases all resources used by the Gprs</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_Gprs_OpenBearerAsync">OpenBearerAsync</a></td><td>
Starts an asynchronous operation to open a GPRS bearer for IP applications. A GPRS bearer is required for HTTP client, SNTP and location requests.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_Gprs_OpenGprsConnectionAsync">OpenGprsConnectionAsync</a></td><td>
Starts an asynchronous operation to open a GPRS connection to be used in sockets. A GPRS connection is required to use GPRS sockets.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#gprs-class">Back to Top</a>

## Events
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Eclo_NetMF_SIM800H_Gprs_GprsIpAppsBearerStateChanged">GprsIpAppsBearerStateChanged</a></td><td>
Event raised when the status of the IP bearer for IP apps changes.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Eclo_NetMF_SIM800H_Gprs_GprsSocketsBearerStateChanged">GprsSocketsBearerStateChanged</a></td><td>
Event raised when the status of the sockets bearer changes.</td></tr></table>&nbsp;
<a href="#gprs-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />