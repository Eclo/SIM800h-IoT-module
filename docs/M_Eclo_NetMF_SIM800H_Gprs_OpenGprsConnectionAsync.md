# Gprs.OpenGprsConnectionAsync Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Starts an asynchronous operation to open a GPRS connection to be used in sockets. A GPRS connection is required to use GPRS sockets.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public Gprs.ConnectGprsAsyncResult OpenGprsConnectionAsync(
	AsyncCallback asyncCallback = null,
	Object asyncState = null
)
```


#### Parameters
&nbsp;<dl><dt>asyncCallback (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/ckbe7yh5" target="_blank">System.AsyncCallback</a><br />The callback to be invoked upon completion, optional</dd><dt>asyncState (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />The state object to be stored against the OpenGprsContextAsyncResult, optional</dd></dl>

#### Return Value
Type: <a href="T_Eclo_NetMF_SIM800H_Gprs_ConnectGprsAsyncResult">Gprs.ConnectGprsAsyncResult</a><br />The ConnectGprsAsyncResult

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_Gprs">Gprs Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />