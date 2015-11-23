# Http.HttpWebRequest.Headers Property 
 _**\[This is preliminary documentation and is subject to change.\]**_

A collection of HTTP headers stored as name/value pairs.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public Http.WebHeaderCollection Headers { get; set; }
```


#### Property Value
Type: <a href="T_Eclo_NetMF_SIM800H_Http_WebHeaderCollection">Http.WebHeaderCollection</a><br />A <b>WebHeaderCollection</b> that contains the name/value pairs that make up the headers for the HTTP request.

## Remarks
The following header values are set through properties on the HttpWebRequest class: Accept, Connection, Content-Length, Content-Type, Expect, Range, Referer, Transfer-Encoding, and User-Agent. Trying to set these header values by using <b>WebHeaderCollection.<a href="M_Eclo_NetMF_SIM800H_Http_WebHeaderCollection_Add">Add(String, String)</a>()</b> will raise an exception. Date and Host are set internally.

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_Http_HttpWebRequest">Http.HttpWebRequest Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />