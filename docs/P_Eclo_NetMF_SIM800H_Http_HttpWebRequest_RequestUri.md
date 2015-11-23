# Http.HttpWebRequest.RequestUri Property 
 _**\[This is preliminary documentation and is subject to change.\]**_

Gets the original Uniform Resource Identifier (URI) of the request.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public Uri RequestUri { get; }
```


#### Property Value
Type: <a href="T_Eclo_NetMF_SIM800H_Uri">Uri</a><br />A Uri that contains the URI of the Internet resource passed to the WebRequest.<a href="M_Eclo_NetMF_SIM800H_Http_WebRequest_Create">Create(Uri)</a> method.

## Remarks
The URI object was created by the constructor and is always non-null. The URI object will always be the base URI, because automatic re-directs aren't supported.

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_Http_HttpWebRequest">Http.HttpWebRequest Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />