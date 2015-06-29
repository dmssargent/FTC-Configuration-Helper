 
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
setlocal enabledelayedexpansion

rem Check for any help arguments passed

call %~dp0windows\scripts\includes\check_help_args.bat %1
if %errorlevel% == 0 (
	goto :help
)

if "%1" == "-no-gui" (
	goto :no_gui
)

reg query "HKLM\Software\Microsoft\NET Framework Setup\NDP\v4\Client\1033" 2>nul >nul
if not %errorlevel% == 0 (
	goto :no_gui
)

:gui
start /b /i windows\bin\Setup
goto :exit

:no_gui
echo Not Implented^^!
goto :abort:help
	more docs\README\%~n0
	goto :exit

@rem --- END SCRIPT ---
:abort
	exit /b 1
	
:exit
	exit /b