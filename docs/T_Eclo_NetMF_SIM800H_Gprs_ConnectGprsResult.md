# Gprs.ConnectGprsResult Enumeration
 _**\[This is preliminary documentation and is subject to change.\]**_

Outcome of request to open GPRS connection

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public enum ConnectGprsResult
```


## Members
&nbsp;<table><tr><th></th><th>Member name</th><th>Value</th><th>Description</th></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Gprs.ConnectGprsResult.Open">**Open**</td><td>0</td><td>GPRS connection open</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Gprs.ConnectGprsResult.AlreadyOpen">**AlreadyOpen**</td><td>1</td><td>GPRS connection already open</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Gprs.ConnectGprsResult.Error">**Error**</td><td>2</td><td>Unspecified error when trying to open GPRS connection</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Gprs.ConnectGprsResult.DeviceIsOff">**DeviceIsOff**</td><td>3</td><td>Device is off</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Gprs.ConnectGprsResult.NotRegisteredAtGsmNetwork">**NotRegisteredAtGsmNetwork**</td><td>4</td><td>Device is not registered at GSM network</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Gprs.ConnectGprsResult.NotRegisteredAtGprsNetwork">**NotRegisteredAtGprsNetwork**</td><td>5</td><td>Device is not registered at GPRS network</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.Gprs.ConnectGprsResult.Failed">**Failed**</td><td>6</td><td>Failed to open bearer context after all attempts</td></tr></table>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />