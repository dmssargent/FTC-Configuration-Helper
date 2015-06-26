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
set REPLACE_FILE=0


if "%~1"=="" (
	echo ERROR: please specify a filename
	goto :abort
)

if not "%~2"=="" (
	if "%~1" == "-f" (
		set FILE=%~f2
		set REPLACE_FILE=1
	) else (
		echo ERROR: option %1 is not recognized
		goto :abort
	)
) else (
	set FILE=%~f1
)

if not exist %~dp1 (
	echo ERROR: cannot find "%~f0". Please check that the directory exists.
	goto :abort
)

if exist %FILE% (
	if %REPLACE_FILE% == 1 (
		rem Delete the file
		echo. > %FILE%
	) else (
		echo ERROR: File exists
		goto :abort
	)
) else (
	echo. > %FILE%
)

rem Begin writing
type %~dp0license.stc >> %FILE%
if not %errorlevel% == 0 (
	echo Not Sucessful^^! Please check that "%~dp0license.stc" exists
	goto :abort
)

type %~dp0defaults.pre >> %FILE%
if not %errorlevel% == 0 (
	echo Not Sucessful^^! Please check that "%~dp0defaults.pre" exists
	goto :abort
)
rem Done!
goto :exit

:abort
	exit /b 1
	
:exit
	