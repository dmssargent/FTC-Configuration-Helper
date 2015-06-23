 
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