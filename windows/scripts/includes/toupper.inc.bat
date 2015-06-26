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
@rem %1 argument is the string; the return value is in the %TOUPPERED% variable, unset after use!

if "%1" ==  "" (
	echo %~n0: ERROR: you must specify a string to convert
	goto :abort
)

if '%1' == '""' (
	echo.
	goto :exit
)

set TOUPPERED=%1
CALL :convert TOUPPERED
echo %TOUPPERED%


:convert
	SET %~1=!%1:a=A!
	SET %~1=!%1:b=B!
	SET %~1=!%1:c=C!
	SET %~1=!%1:d=D!
	SET %~1=!%1:e=E!
	SET %~1=!%1:f=F!
	SET %~1=!%1:g=G!
	SET %~1=!%1:h=H!
	SET %~1=!%1:i=I!
	SET %~1=!%1:j=J!
	SET %~1=!%1:k=K!
	SET %~1=!%1:l=L!
	SET %~1=!%1:m=M!
	SET %~1=!%1:n=N!
	SET %~1=!%1:o=O!
	SET %~1=!%1:p=P!
	SET %~1=!%1:q=Q!
	SET %~1=!%1:r=R!
	SET %~1=!%1:s=S!
	SET %~1=!%1:t=T!
	SET %~1=!%1:u=U!
	SET %~1=!%1:v=V!
	SET %~1=!%1:w=W!
	SET %~1=!%1:x=X!
	SET %~1=!%1:y=Y!
	SET %~1=!%1:z=Z!
	GOTO :EOF
	
:help
	more doc\README\%~x0
	goto :EOF

@rem --- END SCRIPT ---
:abort
	exit /b 1
	
:exit
	exit /b