# Sntp.SyncNetworkTimeAsync Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Starts an asynchronous operation to synchronize network time with SNTP server. Requires GPRS bearer profile 1 opened.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public SyncNetworkTimeAsyncResult SyncNetworkTimeAsync(
	string sntpServer,
	TimeSpan utcOffset,
	AsyncCallback asyncCallback = null,
	Object asyncState = null
)
```


#### Parameters
&nbsp;<dl><dt>sntpServer</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />URL or IP address of the NTP server</dd><dt>utcOffset</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/269ew577" target="_blank">System.TimeSpan</a><br />UTC offset of local time zone.</dd><dt>asyncCallback (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/ckbe7yh5" target="_blank">System.AsyncCallback</a><br />The callback to be invoked upon completion, optional</dd><dt>asyncState (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />The state object to be stored against the OpenGprsContextAsyncResult, optional</dd></dl>

#### Return Value
Type: <a href="T_Eclo_NetMF_SIM800H_SyncNetworkTimeAsyncResult">SyncNetworkTimeAsyncResult</a><br />The IMEIAsyncResult

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_Sntp">Sntp Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />