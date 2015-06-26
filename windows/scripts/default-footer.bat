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

set FILE=

call %~dp0\includes\check_help_args.bat %1
if %errorlevel% == 0 (
	goto :help
)


if "%~1"=="" (
	echo ERROR: please specify a filename
	goto :abort
) else (
	set FILE=%~f1
)

if not "%~2"=="" (	
	echo ERROR: option %2 is not recognized
	goto :abort	
)

if not exist %FILE% (
	echo ERROR: File does not exists
	goto :abort	
)

rem Begin writing
type %~dp0help.stc >> %FILE%
if not %errorlevel% == 0 (
	echo Not Sucessful^^! Please check that "%~dp0help.stc" exists
	goto :abort
)

type %~dp0defaults.post >> %FILE%
if not %errorlevel% == 0 (
	echo Not Sucessful^^! Please check that "%~dp0defaults.post" exists
	goto :abort
)
rem Done!
goto :exit


:help
	more %~dp0docs\README\%~n0
	goto :exit

@rem --- END SCRIPT ---
:abort
	exit /b 1
	
:exit
	exit /b