# SIM800H.Configure Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Configure hardware interface with the device.

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.54.0 (1.1.54.0)

## Syntax

**C#**<br />
``` C#
public static void Configure(
	OutputPort powerKey,
	SerialPort serialPort
)
```


#### Parameters
&nbsp;<dl><dt>powerKey</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/bb285754" target="_blank">Microsoft.SPOT.Hardware.OutputPort</a><br />The I/O signal that will be used to control the device's power key</dd><dt>serialPort</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/30swa673" target="_blank">System.IO.Ports.SerialPort</a><br />The serial port that will be used to comunicate with the device</dd></dl>

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_SIM800H">SIM800H Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />