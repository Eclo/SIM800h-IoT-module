# SIM800H.GetTimeAndLocation Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Retrieves time and optionally location of the device, as reported by the time and location service. Needs to have GPRS connection active.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public LocationAndTime GetTimeAndLocation(
	bool getLocation = true
)
```


#### Parameters
&nbsp;<dl><dt>getLocation (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />True to return also the location of the device.</dd></dl>

#### Return Value
Type: <a href="T_Eclo_NetMF_SIM800H_LocationAndTime">LocationAndTime</a><br />The device's time and location

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_SIM800H">SIM800H Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />