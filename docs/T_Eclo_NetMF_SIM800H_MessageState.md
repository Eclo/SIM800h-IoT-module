# MessageState Enumeration
 _**\[This is preliminary documentation and is subject to change.\]**_

Possible states for a text message

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public enum MessageState
```


## Members
&nbsp;<table><tr><th></th><th>Member name</th><th>Value</th><th>Description</th></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.MessageState.Error">**Error**</td><td>0</td><td>Error retrieving message</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.MessageState.ReceivedUnread">**ReceivedUnread**</td><td>1</td><td>Messages that were received and read</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.MessageState.ReceivedRead">**ReceivedRead**</td><td>2</td><td>Messages that were received but not yet read</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.MessageState.StoredUnsent">**StoredUnsent**</td><td>3</td><td>Messages that were created but not yet sent</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.MessageState.StoredSent">**StoredSent**</td><td>4</td><td>Messages that were created and sent</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.MessageState.All">**All**</td><td>5</td><td>All messages</td></tr></table>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />