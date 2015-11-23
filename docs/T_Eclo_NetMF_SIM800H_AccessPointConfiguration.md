# AccessPointConfiguration Class
 _**\[This is preliminary documentation and is subject to change.\]**_

Configuration of GPRS access point (APN).


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Eclo.NetMF.SIM800H.AccessPointConfiguration<br />
**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public class AccessPointConfiguration
```

The AccessPointConfiguration type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_AccessPointConfiguration__ctor">AccessPointConfiguration()</a></td><td>
Empty GPRS bearer Access Point configuration.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_AccessPointConfiguration__ctor_1">AccessPointConfiguration(String)</a></td><td>
GPRS bearer Access Point configuration.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_AccessPointConfiguration__ctor_2">AccessPointConfiguration(String, String, String)</a></td><td>
GPRS bearer Access Point configuration.</td></tr></table>&nbsp;
<a href="#accesspointconfiguration-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_AccessPointConfiguration_AccessPointName">AccessPointName</a></td><td>
Access Point name. Can't be null</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_AccessPointConfiguration_Password">Password</a></td><td>
Password. Null if not used.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_AccessPointConfiguration_UserName">UserName</a></td><td>
User name. Null if not used.</td></tr></table>&nbsp;
<a href="#accesspointconfiguration-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_AccessPointConfiguration_Equals">Equals</a></td><td> (Overrides <a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Object.Equals(Object)</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_AccessPointConfiguration_GetHashCode">GetHashCode</a></td><td> (Overrides <a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">Object.GetHashCode()</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Eclo_NetMF_SIM800H_AccessPointConfiguration_Parse">Parse</a></td><td>
Parse a string with a valid Access Point configuration. Expected format is "apname|user|password". User name and password are optional.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_AccessPointConfiguration_ToString">ToString</a></td><td> (Overrides <a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">Object.ToString()</a>.)</td></tr></table>&nbsp;
<a href="#accesspointconfiguration-class">Back to Top</a>

## Operators
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public operator](media/puboperator.gif "Public operator")![Static member](media/static.gif "Static member")</td><td><a href="M_Eclo_NetMF_SIM800H_AccessPointConfiguration_op_Equality">Equality</a></td><td /></tr><tr><td>![Public operator](media/puboperator.gif "Public operator")![Static member](media/static.gif "Static member")</td><td><a href="M_Eclo_NetMF_SIM800H_AccessPointConfiguration_op_Inequality">Inequality</a></td><td /></tr></table>&nbsp;
<a href="#accesspointconfiguration-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />