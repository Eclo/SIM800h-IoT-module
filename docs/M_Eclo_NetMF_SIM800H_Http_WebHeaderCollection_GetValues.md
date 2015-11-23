# Http.WebHeaderCollection.GetValues Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Returns the values for the specified header name.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public string[] GetValues(
	string header
)
```


#### Parameters
&nbsp;<dl><dt>header</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the header.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>[]<br />An array of parsed string objects.

## Remarks
Takes a header name and returns a string array representing the individual values for that header. For example, if the headers contain the following line: 
```
Accept: text/plain, text/html
```
 then `GetValues("Accept")` returns an array of two strings: "text/plain" and "text/html".

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_Http_WebHeaderCollection">Http.WebHeaderCollection Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />