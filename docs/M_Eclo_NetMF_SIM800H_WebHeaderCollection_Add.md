# WebHeaderCollection.Add Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Inserts a header with the specified name and value into the collection.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public void Add(
	string name,
	string value
)
```


#### Parameters
&nbsp;<dl><dt>name</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the header that is being added to the collection.</dd><dt>value</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The content of the header that is being added (its header-value). If a header with the specified name already exists, this value is concatenated onto the existing header.</dd></dl>

## Remarks
If a header with the specified name already exists, the header that is being added is concatenated onto the existing header. 
Throws an exception if the specified header name is the name of a special header.


## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_WebHeaderCollection">WebHeaderCollection Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />