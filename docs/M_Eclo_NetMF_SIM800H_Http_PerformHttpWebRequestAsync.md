# Http.PerformHttpWebRequestAsync Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Performs an asynchronous HttpWebrequest

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public HttpWebRequestAsyncResult PerformHttpWebRequestAsync(
	HttpWebRequest request,
	bool readResponseData = false,
	bool readHeaders = false,
	AsyncCallback asyncCallback = null,
	Object asyncState = null
)
```


#### Parameters
&nbsp;<dl><dt>request</dt><dd>Type: <a href="T_Eclo_NetMF_SIM800H_HttpWebRequest">Eclo.NetMF.SIM800H.HttpWebRequest</a><br />The `HttpWebRequest` request to be performed</dd><dt>readResponseData (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />Option to read the response data if any, optional with false as default</dd><dt>readHeaders (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />Option to read the response headers, if any, optional with false as default</dd><dt>asyncCallback (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/ckbe7yh5" target="_blank">System.AsyncCallback</a><br />The callback to be invoked upon completion, optional</dd><dt>asyncState (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />The state object to be stored against the ReadSMSAsyncResult, optional</dd></dl>

#### Return Value
Type: <a href="T_Eclo_NetMF_SIM800H_HttpWebRequestAsyncResult">HttpWebRequestAsyncResult</a><br />The IMEIAsyncResult

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_Http">Http Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />