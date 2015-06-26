@rem FTC Configure Helper - this provides some system checks and setup to various operating systems.
@rem Copyright (C) 2015  David S. - FTC 5395
@rem 
@rem This program is free software: you can redistribute it and/or modify
@rem it under the terms of the GNU General Public License as published by
@rem the Free Software Foundation, either version 3 of the License, or
@rem (at your option) any later version.
@rem 
@rem This program is distributed in the hope that it will be useful,
@rem but WITHOUT ANY WARRANTY; without even the implied warranty of
@rem MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
@rem GNU General Public License for more details.
@rem 
@rem You should have received a copy of the GNU General Public License
@rem along with this program.  If not, see <http://www.gnu.org/licenses/>.
@rem --- BEGIN SCRIPT ---
@echo off

rem This should find the wlan.conf file in the root of this repo
set WLAN_CONF_FILE=%~dp0..\..\wlan.conf
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
call :trim_whitespace %COMPUTER_IP% %ROBOT_IP% %DRIVER_IP% %WLAN_SSID% %TEAM_NUMBER% %ANDROID_HOME%
call :find_key

goto :exit

rem This trims the whitespace the may a have gotten added during a saving
:trim_whitespace
	set COMPUTER_IP=%1
	set ROBOT_IP=%2
	set DRIVER_IP=%3
	set WLAN_SSID=%4
	set TEAM_NUMBER=%5
	set ANDROID_HOME=%6
	goto :EOF

rem Based on the above this finds the WIFI key.
:find_key
set WLAN_KEY_FILE=%~dp0..\..\%WLAN_SSID%.key
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