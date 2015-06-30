Set oWS = CreateObject("WScript.Shell")
sLinkFile = WScript.Arguments.item(0)
WScript.echo sLinkFile
Set oLink = oWs.CreateShortcut(sLinkFile)
oLink.TargetPath = WScript.Arguments.item(1)
'oLink.IconLocation = WScript.Arguments.item(2)
oLink.Save
