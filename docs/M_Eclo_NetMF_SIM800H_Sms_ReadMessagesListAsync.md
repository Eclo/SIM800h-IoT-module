# Sms.ReadMessagesListAsync Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Starts an asynchronous operation to get a list with message indexes

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public ReadMessageListAsyncResult ReadMessagesListAsync(
	MessageState state,
	AsyncCallback asyncCallback = null,
	Object asyncState = null
)
```


#### Parameters
&nbsp;<dl><dt>state</dt><dd>Type: <a href="T_Eclo_NetMF_SIM800H_MessageState">Eclo.NetMF.SIM800H.MessageState</a><br />\[Missing <param name="state"/> documentation for "M:Eclo.NetMF.SIM800H.Sms.ReadMessagesListAsync(Eclo.NetMF.SIM800H.MessageState,System.AsyncCallback,System.Object)"\]</dd><dt>asyncCallback (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/ckbe7yh5" target="_blank">System.AsyncCallback</a><br />The callback to be invoked upon completion, optional</dd><dt>asyncState (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />The state object to be stored against the ReadMessageListAsyncResult, optional</dd></dl>

#### Return Value
Type: <a href="T_Eclo_NetMF_SIM800H_ReadMessageListAsyncResult">ReadMessageListAsyncResult</a><br />The IMEIAsyncResult

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_Sms">Sms Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />