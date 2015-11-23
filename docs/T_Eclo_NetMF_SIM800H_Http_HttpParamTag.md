# Http.HttpParamTag Enumeration
 _**\[This is preliminary documentation and is subject to change.\]**_

Parameters for HTTP call

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public enum HttpParamTag
```


## Members
&nbsp;<table><tr><th></th><th>Member name</th><th>Value</th><th>Description</th></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.CID">**CID**</td><td>0</td><td>(mandatory parameter) Bearer profile identifier</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.URL">**URL**</td><td>1</td><td>(mandatory parameter) HTTP client URL with format "http://'server'/'path':'tcpPort'" server: FQDN or IP address path: path of file or directory tcpPort: default value is 80</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.UA">**UA**</td><td>2</td><td>Refer to IETF-RFC 2616. The user agent string is usually set by the application to identify the system. Usually this parameters include information about the OS and other system capabilities and version information. Default value is SIMCOM_MODULE</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.PROPIP">**PROPIP**</td><td>3</td><td>The IP address of the HTTP proxy server</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.PROPORT">**PROPORT**</td><td>4</td><td>The port of the HTTP proxy server</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.REDIR">**REDIR**</td><td>5</td><td>This flag controls the redirection mechanics of the SIM800 when it's acting as HTTP client. If the server sends a redirect code (range 30X) the client will automatically send a new HTTP request when the flag is set to 1. Default value is 0 (no redirection)</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.BREAK">**BREAK**</td><td>6</td><td>Parameter for HTTP method GET used for resuming broken transfer</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.BREAKEND">**BREAKEND**</td><td>7</td><td>Parameter for HTTP method GET used for resuming broken transfer that is used together with BREAK. If the value of BREAKEND is bigger than BREAK the transfer scope is from BREAK to BREAKEND. If the value of BREAKEND is smaller than BREAK the transfer scope is from BREAK to the end of the file. If both BREAKEND and BREAK are 0, the resumed broken transfer function is disabled. Note that not all servers support BREAKEND and BREAK</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.TIMEOUT">**TIMEOUT**</td><td>8</td><td>HTTP session timeout, scope: 30-1000 seconds. Default value is 120 seconds.</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.CONTENT">**CONTENT**</td><td>9</td><td>Sets the Content-Type HTTP header</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Http.HttpParamTag.USERDATA">**USERDATA**</td><td>10</td><td>Sets the user data parameter (to set HTTP headers)</td></tr></table>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />