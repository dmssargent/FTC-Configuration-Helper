 
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

:check_for_help
	if "%1" == "-h" (
		goto :help
	)
	if "%1" == "-help" (
		goto :help
	)
	if "%1" == "/help" (
		goto :help
	)
	if "%1" == "-?" (
		goto :help
	)

:no_help
	exit /b 1
	
:help
	exit /b
	
@rem --- END SCRIPT ---
