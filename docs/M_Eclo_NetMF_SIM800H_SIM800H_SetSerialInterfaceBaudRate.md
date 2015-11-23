# SIM800H.SetSerialInterfaceBaudRate Method 
 _**\[This is preliminary documentation and is subject to change.\]**_

Set baud rate for serial interface

**Namespace:**&nbsp;<a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H</a><br />**Assembly:**&nbsp;Eclo.NetMF.SIM800H (in Eclo.NetMF.SIM800H.dll) Version: 1.1.57.0 (1.1.57.0)

## Syntax

**C#**<br />
``` C#
public ATCommandResult SetSerialInterfaceBaudRate(
	int newBaudRate
)
```


#### Parameters
&nbsp;<dl><dt>newBaudRate</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />New baud rate. Valid values are 1200, 2400, 4800, 9600, 19200, 38400, 57600 and 115200. Set to 0 for auto baud rate. The new baud rate is stored to flash after command is issued. When setting to auto baud rate a reset is required/recommended.</dd></dl>

#### Return Value
Type: <a href="T_Eclo_NetMF_SIM800H_ATCommandResult">ATCommandResult</a><br />ATCommandResult

## See Also


#### Reference
<a href="T_Eclo_NetMF_SIM800H_SIM800H">SIM800H Class</a><br /><a href="N_Eclo_NetMF_SIM800H">Eclo.NetMF.SIM800H Namespace</a><br />