 
@rem Anyone is free to copy, modify, publish, use, compile, sell, or
@rem distribute this software, either in source code form or as a compiled
@rem binary, for any purpose, commercial or non-commercial, and by any
@rem means.
@rem 
@rem In jurisdictions that recognize copyright laws, the author or authors
@rem of this software dedicate any and all copyright interest in the
@rem software to the public domain. We make this dedication for the benefit
@rem of the public at large and to the detriment of our heirs and
@rem successors. We intend this dedication to be an overt act of
@rem relinquishment in perpetuity of all present and future rights to this
@rem software under copyright law.
@rem 
@rem THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
@rem EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
@rem MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
@rem IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
@rem OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
@rem ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
@rem OTHER DEALINGS IN THE SOFTWARE.
@rem 
@rem For more information, please refer to <http://unlicense.org/>
@rem --- BEGIN SCRIPT ---
@echo off

set WLAN_CONF_FILE=%~dp0..\wlan.conf
rem This parses the wlan.conf file
< %WLAN_CONF_FILE% (
	set /p WARNING=
	set /p COMPUTER_IP=
	set /p ROBOT_IP=
	set /p DRIVER_IP=
	set /p WLAN_SSID=
	set /p TEAM_NUMBER=
	set /p ANDROID_HOME=
)

call :FIND_KEY %WLAN_SSID%

goto :exit
rem Based on the above this finds the WIFI key.

:FIND_KEY
set WLAN_SSID=%1
set WLAN_KEY_FILE=%~dp0..\%WLAN_SSID%.key
if not exist %WLAN_KEY_FILE% (
	echo ERROR: Cannot find the key file.
	echo 	Looking for %WLAN_KEY_FILE%
	goto :abort
)
set /p WLAN_KEY= < %WLAN_KEY_FILE%

goto :EOF

:abort
	echo Failed^^!
	exit /b 1
	
:exit
	exit /b