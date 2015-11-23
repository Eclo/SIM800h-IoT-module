# PINState Enumeration
 _**\[This is preliminary documentation and is subject to change.\]**_

Possible states of the SIM card

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public enum PINState
```


## Members
&nbsp;<table><tr><th></th><th>Member name</th><th>Value</th><th>Description</th></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.PINState.Error">**Error**</td><td>0</td><td>Error retrieving PIN status</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.PINState.Ready">**Ready**</td><td>1</td><td>SIM is unlocked and ready to be used.</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.PINState.PIN">**PIN**</td><td>2</td><td>SIM is locked waiting for the PIN</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.PINState.PUK">**PUK**</td><td>3</td><td>SIM is locked waiting for the PUK</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.PINState.PH_PIN">**PH_PIN**</td><td>4</td><td>SIM is waiting for phone to SIM card (antitheft)</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.PINState.PH_PUK">**PH_PUK**</td><td>5</td><td>SIM is waiting for phone to SIM PUK (antitheft)</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.PINState.PIN2">**PIN2**</td><td>6</td><td>SIM is waiting for second PIN</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.PINState.PUK2">**PUK2**</td><td>7</td><td>SIM is waiting for second PUK</td></tr><tr><td /><td target="F:Eclo.NetMF.SIM800H.PINState.NotPresent">**NotPresent**</td><td>8</td><td>SIM is not present</td></tr></table>

## See Also


#### Reference
<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />