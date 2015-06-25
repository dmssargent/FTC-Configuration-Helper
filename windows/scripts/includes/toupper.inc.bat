 
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
@rem %1 argument is the string; the return value is in the %TOUPPERED% variable, unset after use!

if "%1" ==  "" (
	echo %~n0: ERROR: you must specify a string to convert
	goto :abort
)

set TOUPPERED=%1
echo %1
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