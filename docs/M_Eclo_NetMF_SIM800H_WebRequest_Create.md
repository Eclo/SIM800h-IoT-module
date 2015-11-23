# WebRequest.Create Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Creates a WebRequest.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public static WebRequest Create(
	Uri requestUri
)
```


#### Parameters
&nbsp;<dl><dt>requestUri</dt><dd>Type: <a href="T_Eclo_NetMF_SIM800H_Uri">Eclo.NetMF.SIM800H.Uri</a><br />A [!:System.Uri] containing the URI of the requested resource.</dd></dl>

#### Return Value
Type: <a href="T_Eclo_NetMF_SIM800H_WebRequest">WebRequest</a><br />\[Missing <returns> documentation for "M:Eclo.NetMF.SIM800H.WebRequest.Create(Eclo.NetMF.SIM800H.Uri)"\]

## Remarks
This is the main creation routine. The specified Uri is looked up in the prefix match table, and the appropriate handler is invoked to create the object.

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_WebRequest">WebRequest Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />