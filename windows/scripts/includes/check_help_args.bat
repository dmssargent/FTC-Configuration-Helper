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

call %~dp0\toupper.bat "%1"
set TEST_ARG=%TOUPPERED%
set TOUPPERED=

rem Check if nothing was returned
if "%TEST_ARG%" == "" (
	goto :no_help
)

:check_for_help
	if %TEST_ARG% == "-H" (
		goto :help
	)
	if %TEST_ARG% == "-HELP" (
		goto :help
	)
	if %TEST_ARG% == "/HELP" (
		goto :help
	)
	
	if %TEST_ARG% == "/H" (
		goto :help
	)

	if %TEST_ARG% == "/?" (
		goto :help
	)
	
	if %TEST_ARG% == "-?" (
		goto :help
	)

:no_help
	exit /b 1
	
:help
	exit /b
	
@rem --- END SCRIPT ---
