# Sms.ReadMessage Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Requests to read the text message in the specified position.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public Sms.Message ReadMessage(
	int memoryPosition,
	bool markAsRead = true
)
```


#### Parameters
&nbsp;<dl><dt>memoryPosition</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />Position in memory where the message is stored</dd><dt>markAsRead (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />Whether unread messages will be marked as read</dd></dl>

#### Return Value
Type: <a href="T_Eclo_NetMF_SIM800H_Sms_Message">Sms.Message</a><br />\[Missing <returns> documentation for "M:Eclo.NetMF.SIM800H.Sms.ReadMessage(System.Int32,System.Boolean)"\]

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_Sms">Sms Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />