# FTC Configuration Helper
*v0.15*

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
configure.win32
```

or you can right-click on `configure.bat`, and click **Run as adminstrator**

After that you can type (in Command Prompt):

wlan-dev setup

To start the development Wireless Network:

wlan-dev start

To stop the development Wireless Network:

wlan-dev stop

For Linux:

>	Still deciding, try starting by looking for either a ./configure.unix.sh or ./configure
	
#### Advanced Usage
--skip-checks

> Disables ALL checks on system configuration, and builds a WLAN status file

-help | -h | -?

> Displays help

#### License
**Please read the LICENSE file for update**

FTC Configure Helper - this provides some system checks and setup to various operating systems.
Copyright (C) 2015  David S. - FTC 5395

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.