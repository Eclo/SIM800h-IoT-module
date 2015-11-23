# WebHeaderCollection Class
 _**\[This is preliminary documentation and is subject to change.\]**_

Contains protocol headers associated with a request or response. Manages name-value pairs for HTTP headers.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Eclo.NetMF.SIM800H.WebHeaderCollection<br />
**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public class WebHeaderCollection
```

The WebHeaderCollection type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_WebHeaderCollection__ctor">WebHeaderCollection</a></td><td>
Creates an empty collection of WEB headers.</td></tr></table>&nbsp;
<a href="#webheadercollection-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_WebHeaderCollection_AllKeys">AllKeys</a></td><td>
Gets all header names (keys) in the collection.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_WebHeaderCollection_Count">Count</a></td><td>
Gets the number of headers in the collection.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Eclo_NetMF_SIM800H_WebHeaderCollection_Item">Item</a></td><td>
Returns the string value for the header.</td></tr></table>&nbsp;
<a href="#webheadercollection-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_WebHeaderCollection_Add">Add</a></td><td>
Inserts a header with the specified name and value into the collection.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_WebHeaderCollection_GetValues">GetValues</a></td><td>
Returns the values for the specified header name.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Eclo_NetMF_SIM800H_WebHeaderCollection_Remove">Remove</a></td><td>
Removes the specified header from the collection.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td> (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#webheadercollection-class">Back to Top</a>

## Remarks
This class includes additional methods, including HTTP parsing of a collection into a buffer that can be sent. 
Headers are validated when attempting to add them.


## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />