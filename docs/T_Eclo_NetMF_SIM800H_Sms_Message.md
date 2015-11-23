# Sms.Message Class
 _**\[This is preliminary documentation and is subject to change.\]**_

Text Message (SMS)


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Eclo.NetMF.SIM800H.Sms.Message<br />
**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public class Message
```

The Sms.Message type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_Sms_Message__ctor">Sms.Message()</a></td><td>
Instantiates a new SMS with empty number, and content, marks it as unsent and with the current time as the timestamp.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_Sms_Message__ctor_1">Sms.Message(String, String, Sms.MessageState, DateTime)</a></td><td>
Instantiates a new SMS message with the given parameters.</td></tr></table>&nbsp;
<a href="#sms.message-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_Sms_Message_Index">Index</a></td><td>
Index of the message in the SIM card's memory</td></tr></table>&nbsp;
<a href="#sms.message-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#sms.message-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public field](media/pubfield.gif "Public field")</td><td><a href="F_Eclo_NetMF_SIM800H_Sms_Message_Status">Status</a></td><td>
Status of the message</td></tr><tr><td>![Public field](media/pubfield.gif "Public field")</td><td><a href="F_Eclo_NetMF_SIM800H_Sms_Message_TelephoneNumber">TelephoneNumber</a></td><td>
Number</td></tr><tr><td>![Public field](media/pubfield.gif "Public field")</td><td><a href="F_Eclo_NetMF_SIM800H_Sms_Message_TextMessage">TextMessage</a></td><td>
Message content</td></tr><tr><td>![Public field](media/pubfield.gif "Public field")</td><td><a href="F_Eclo_NetMF_SIM800H_Sms_Message_Timestamp">Timestamp</a></td><td>
Date and time when the message was sent or received</td></tr></table>&nbsp;
<a href="#sms.message-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />