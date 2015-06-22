# FTC Configuration Helper
*v0.1*

#### Use
This provides a wrapper to netsh commands and a basic robot 
development system check. It provides automatically generated
variables when need be.

#### Usage
  In Command Prompt (running as a Administrator) go to where you cloned the repo (via the cd command)
  *i.e* if it is in your Downloads folder, type:
  ```Batchfile
	cd %userprofile%\Downloads\FTC-Configuration-Helper
  ```
  
  Then to start the configuration process, type:
  ```Batchfile
	configure
   ```
   
   or you can right-click on `configure.bat`, and click **Run as adminstrator**
   
   After that you can type (in Command Prompt):
	`wlan-dev setup`
	
	To start the development Wireless Network:
	`wlan-dev start`
	
	To stop the development Wireless Network:
	`wlan-dev stop`
	
#### Advanced Usage
 --skip-checks
 
	> Disables ALL checks on system configuration, and builds a WLAN status file

 -help | -h | -?
 
	> Displays help

#### License
Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org/>