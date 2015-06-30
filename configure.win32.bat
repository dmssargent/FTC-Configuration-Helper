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
@cmd /c
@echo off
setlocal EnableExtensions
setlocal enabledelayedexpansion

set DISPLAY_PATH=0
set CURRENT_JAVA_VERSION=jdk1.8.0_45
set DISPLAY_JAVA_HOME=0
set GIT_URL=https://github.com/msysgit/msysgit/releases/download/Git-1.9.5-preview20150319/Git-1.9.5-preview20150319.exe
rem Reset input for script
set input=
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

:check_permissions
	echo Checking for admin rights...

	net session >nul 2>&1
	if %errorlevel% == 0 (
		echo Success^^! We can continue.
	) else (
		echo Not running as an admin, please run this as a administrator.
		pause
		goto :abort
	)

:check_args
	if "%1" == "--skip-checks" (
		goto :write_post_config
	)
	
	if "%1" == "--no-gui" (
		goto :check_java
	)
	
:gui
	echo Starting GUI...
	if "%PROCESSOR_ARCHITECTURE%" == "AMD64" (
		goto :gui_64
	)
	.\windows\bin\configure.exe
	goto :exit
	
:gui_64
	.\windows\bin\x64\configure.exe
	goto :exit

:check_java
	echo Looking for java...
	
	java -version 2>nul
	
	if %errorlevel% == 0 (
		echo A java executuable was found^^!
	) else (
		echo Not found in PATH.
		goto :find_java
	)
	
	goto :check_jdk
	
:find_java
	echo Trying to find JAVA...
	
	if defined JAVA_HOME (
		%JAVA_HOME%\bin\java -version 2>nul
	) else (
		echo JAVA_HOME is not set. Please set it^^!
	)
	if %errorlevel% == 0 (
		echo Java found^^! Correcting PATH for this script.
		set PATH=%PATH%;%JAVA_HOME%\bin;
		set DISPLAY_PATH=1		
	)
	
	rem Arbitrary Finding Method. This is probably not secure
	rem TODO: Add looking in the registry
	if exist %programfiles%\Java\%CURRENT_JAVA_VERSION%\bin\java.exe (
		echo Java Found^^!
		set JAVA_HOME=%programfiles%\Java\%CURRENT_JAVA_VERSION%;
		set DISPLAY_JAVA_HOME=1
		set PATH=%PATH%;%JAVA_HOME%\bin;
		set DISPLAY_PATH=1
	) else (
		if defined %programfiles(x86)% (
			if %programfiles(x86)%\JAVA\%CURRENT_JAVA_VERSION%\bin\java.exe (
				echo Java Found^^!
				set JAVA_HOME=%programfiles(x86)%\Java\%CURRENT_JAVA_VERSION%;
				set DISPLAY_JAVA_HOME=1
				set PATH = %PATH%;%JAVA_HOME%\bin;
				set DISPLAY_PATH=1
			)
		) else (
			echo Cannot find JAVA. Where is it?
			echo Example: If Java is installed at "C:\foo\Java\jdk\", enter "C:\foo\Java\jdk\";
			echo	not "C:\foo\Java\jdk\bin\java"
			set /p TEMP_JAVA_HOME=
			if exist %TEMP_JAVA_HOME%\bin\java.exe (
				echo Yay^^! It works. I can continue.
				set JAVA_HOME=%TEMP_JAVA_HOME%
				set DISPLAY_JAVA_HOME=1
				set PATH=%PATH%;%JAVA_HOME%\bin;
				set DISPLAY_PATH = 1;
			) else (
				echo I can not continue. To resolve this:
				echo 	"1. Install Java, or reinstall it"
				echo 	"2. Set JAVA_HOME to the JDK installation value"
				echo 	"3. Add %JAVA_HOME%\bin to the user's path"
				echo 	"4. Re-run this script with the right value"
				goto :abort
			)
		)
	)
	
	rem We think we have a JAVA executable. Let's test it
	java -version >nul
	if %errorlevel% == 0 (
		echo We have working a JAVA
	) else (
		echo JAVA doesn't work^^!
		echo Please fix JAVA^^!
		goto :abort
	)	
	goto :check_jdk

:check_jdk
	echo JDK Location:
	echo %JAVA_HOME% | findstr jdk
	if %errorlevel% == 0 (
		set input=no
		set /p input=Does the above line have something like "%CURRENT_JAVA_VERSION%"? ^(yes or no^): 
		if  '!input!' == 'Y' (
			echo Please type "yes" to continue
			goto :check_jdk
		) else if  '!input!' == 'y' (
			echo Please type "yes" to continue
			goto :check_jdk
		) else if  '!input!' == 'YES' (
			echo Continuing JDK verification...
			goto :check_jdk_2
		) else if  '!input!' == 'yes' (
			echo Continuing JDK verification...
			goto :check_jdk_2
		)
		
		rem None of the options above were typed.
		echo JAVA_HOME does not point to a valid JDK installation
		goto :abort
		
	rem JDK wasn't found in JAVA_HOME	
	) else (
		echo JAVA_HOME does not point to a valid JDK installation
		goto :abort
	)
	
:check_jdk_2
	reg query "HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Development Kit" >nul 2>nul
	if %errorlevel% == 0 (
		echo JAVA is confirmed^^!
	) else (
		echo The JAVA JDK is not installed, or needs to be re-installed^^!
		goto :abort
	)
	
:check_for_android
	echo Checking for Android SDK...
	echo %ANDROID_HOME%
	if not defined %ANDROID_HOME% (
		if exist %ANDROID_HOME%\tools\android.bat (
			echo Found^^!
			goto :check_add_android_config_to_path
		) else (
			echo ANDROID_HOME points to an invalid Android SDK^^!
			echo Current ANDROID_HOME: "%ANDROID_HOME%"
			set /p input=Is this correct? 
			
			if  '!input!' == 'n' (
				goto :fix_android_config
			) else if  '!input!' == 'N' (
				goto :fix_android_config
			) else if  '!input!' == 'NO' (
				goto :fix_android_config
			) else if  '!input!' == 'no' (
				goto :fix_android_config
			) else (
				goto :abort
			)
		)
	) else (
		echo ERROR: ANDROID_HOME is not defined^^! It should be defined for the user.
		goto :fix_android_config
	)
	
rem Reconfigure Android SDK path
:fix_android_config
	echo Enter a value for the Android SDK path (ex. C:\Users\Public\android-sdk):
	set /p ANDROID_HOME=Path of ANDROID_HOME: 
	echo  --- Retesting Android SDK^^!
	goto :check_for_android
	
rem Add Android SDK to the PATH
:check_add_android_config_to_path
	rem Check if adb is in path
	adb version
	if %errorlevel% == 0 (
		goto :update_android
	)
	set input=no
	set /p input=Do you want to add %ANDROID_HOME%/platform-tools to the PATH (right now, it just generates a new PATH)?
	if  '!input!' == 'Y' (
		goto :add_android_config_to_path	
	) else if  '!input!' == 'y' (
		goto :add_android_config_to_path
	) else if  '!input!' == 'YES' (
		goto :add_android_config_to_path
	) else if  '!input!' == 'yes' (
		goto :add_android_config_to_path
	)

	goto :update_android

:add_android_config_to_path
	set PATH=%PATH%;%ANDROID_HOME%\platform-tools
	set DISPLAY_PATH=1
	
rem Have android.bat show updates	
:update_android
	set input=no
	set /p input=Do you want to check the Android SDK for updates? 
	if  '!input!' == 'Y' (
		echo Updating SDK...
		call %ANDROID_HOME%\tools\android.bat update sdk
		echo Done^^!
	) else if  '!input!' == 'y' (
		echo Updating SDK...
		call %ANDROID_HOME%\tools\android.bat update sdk
		echo Done^^!
	) else if  '!input!' == 'YES' (
		echo Updating SDK...
		call %ANDROID_HOME%\tools\android.bat update sdk
		echo Done^^!
	) else if  '!input!' == 'yes' (
		echo Updating SDK...
		call %ANDROID_HOME%\tools\android.bat update sdk
		echo Done^^!
	)

:check_for_git
	echo Checking for VCS Git...
	rem Checking if git version returns 0
	git --version >nul 2>nul
	if %errorlevel% == 0 (
		echo Found^^!
		goto :write_post_config
	)
	set input=no
	set /p input=Do you want to install Git?	
	if  '!input!' == 'Y' (
		goto :download_git
	) else if  '!input!' == 'y' (
		goto :download_git
	) else if  '!input!' == 'YES' (
		goto :download_git
	) else if  '!input!' == 'yes' (
		goto :download_git
	)
	goto :write_post_config
	
:download_git
	echo checking for wget...
	if exist .\bin\wget.exe (
		echo Found^!
		.\bin\wget.exe --no-chuck %GIT_URL%
	) else (
		rem Using System wget
		wget --version 2>nul >nul
		if %errorlevel% == 0 (
			wget --no-chuck %GIT_URL%
		) else (
			rem wget was not found
			echo Not Found^!
		)
	)

:install_git
	if exist .\%GIT_SETUP% (
		echo Please wait...
		%GIT_SETUP% /silent
		echo Done^!
	)
	rem TODO: Check if git is added to the PATH

:write_post_config
	echo Writing configure.status...
	set STATUS_FILE=configure.status.bat
	
	> %STATUS_FILE%  type .\windows\scripts\LICENSE.stc  
	>> %STATUS_FILE% echo @cmd /c
	>> %STATUS_FILE% echo @echo off
	>> %STATUS_FILE% echo setlocal enabledelayedexpansion
	>> %STATUS_FILE% echo set ANDROID_HOME=%ANDROID_HOME%
	>> %STATUS_FILE% echo echo Development Setup Configuration: (DHCP means to have the IP address assigned by a server, not you) 
	>> %STATUS_FILE% echo rem Set Defaults
	>> %STATUS_FILE% echo set TEAM_NUMBER=1234
	>> %STATUS_FILE% echo set COMPUTER_IP=DHCP
	>> %STATUS_FILE% echo set DRIVER_IP=DHCP
	>> %STATUS_FILE% echo set ROBOT_IP=DHCP
	>> %STATUS_FILE% echo. 
	>> %STATUS_FILE% echo rem Start asking questions.
	>> %STATUS_FILE% echo set /p COMPUTER_IP=Enter development computer IPv4 Address for development wlan: [DHCP] 
	>> %STATUS_FILE% echo set /p DRIVER_IP=Enter development driver controller IPv4 Address: [DHCP]
	>> %STATUS_FILE% echo set /p ROBOT_IP=Enter development robot controller IPv4 Address: [DHCP]
	>> %STATUS_FILE% echo set /p TEAM_NUMBER=Enter your team number: 
	>> %STATUS_FILE% echo set WLAN_SSID=%%TEAM_NUMBER%%_DEV
	>> %STATUS_FILE% echo set /p WLAN_SSID=Enter your WLAN SSID? [%%WLAN_SSID%%]
	>> %STATUS_FILE% echo if not exist %%WLAN_SSID%%.key ^(
	>> %STATUS_FILE% echo 	set WLAN_KEY=FTC%%TEAM_NUMBER%%-%%RANDOM%%
	>> %STATUS_FILE% echo 	set /p WLAN_KEY=Enter a WLAN key: [^^!WLAN_KEY^^!]
	>> %STATUS_FILE% echo ) else (
	>> %STATUS_FILE% echo 	set /p WLAN_KEY= ^< %%WLAN_SSID%%.key
	>> %STATUS_FILE% echo )
	>> %STATUS_FILE% echo echo.
	>> %STATUS_FILE% echo echo ---- Current Configuration:
	>> %STATUS_FILE% echo echo		 WLAN SSID: %%WLAN_SSID%%
	>> %STATUS_FILE% echo echo		 WLAN KEY:  %%WLAN_KEY%%
	>> %STATUS_FILE% echo echo		 DEVELOPMENT COMPUTER IP:  %%COMPUTER_IP%%
	>> %STATUS_FILE% echo echo		 DEVELOPMENT ROBOT CNTRLR: %%ROBOT_IP%%
	>> %STATUS_FILE% echo echo		 DEVELOPMENT DRVR IP:      %%DRIVER_IP%%
	>> %STATUS_FILE% echo echo		 TEAM NUMBER: %%TEAM_NUMBER%%
	>> %STATUS_FILE% echo echo ---- End Configuration
	>> %STATUS_FILE% echo echo.
	>> %STATUS_FILE% echo echo Writing this down...
	>> %STATUS_FILE% echo echo %%WLAN_KEY%% ^> %%WLAN_SSID%%.key
	>> %STATUS_FILE% echo echo DO NOT MODIFY THIS FILE^^^^^^^^^^! IT IS AUTOGENERATED. ^> wlan.conf
	>> %STATUS_FILE% echo echo %%COMPUTER_IP%% ^>^> wlan.conf
	>> %STATUS_FILE% echo echo %%ROBOT_IP%% ^>^> wlan.conf
	>> %STATUS_FILE% echo echo %%DRIVER_IP%% ^>^> wlan.conf
	>> %STATUS_FILE% echo echo %%WLAN_SSID%% ^>^> wlan.conf
	>> %STATUS_FILE% echo echo %%TEAM_NUMBER%% ^>^> wlan.conf
	>> %STATUS_FILE% echo echo %%ANDROID_HOME%% ^>^> wlan.conf
		
	rem The amount of carets is needed, it is not a typo! It breaks up as ^^^^=^, ^^^^=^, ^^! = ! to get ^^!
	>> %STATUS_FILE% echo echo Done^^^^^^^^^^!
	>> %STATUS_FILE% echo echo Creating WLAN setup, start, and start.
	>> %STATUS_FILE% echo set WLAN_DEV_EXEC=.\wlan-dev.bat
	>> %STATUS_FILE% echo call .\windows\scripts\default-header -f %%WLAN_DEV_EXEC%%
	rem TODO: Modularize this section
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo.
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo rem Build variables
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo call .\windows\scripts\wlan-conf-parser.bat
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo :parse-args
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo 	if "%%%%1" == "start" (
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo		goto :start
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo	)
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo 	if "%%%%1" == "stop" (
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo 		goto :stop
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo	)
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo 	if "%%%%1" == "setup" (
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo		goto :setup
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo 	)
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo 	rem Invalid command, display help
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo 	goto :help
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% echo.
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% type .\windows\scripts\start-wlan.stc
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% type .\windows\scripts\stop-wlan.stc
	>> %STATUS_FILE% echo ^>^> %%WLAN_DEV_EXEC%% type .\windows\scripts\setup-wlan.stc
	>> %STATUS_FILE% echo call .\windows\scripts\default-footer %%WLAN_DEV_EXEC%%
	>> %STATUS_FILE% echo.
	>> %STATUS_FILE% echo set CONFIGURE_DEVICES=.\configure.devices.bat
	>> %STATUS_FILE% echo call .\windows\scripts\default-header -f %%CONFIGURE_DEVICES%%
	>> %STATUS_FILE% echo ^>^> %%CONFIGURE_DEVICES%% type .\windows\scripts\configure.devices.pre
	>> %STATUS_FILE% echo call .\windows\scripts\default-footer %%CONFIGURE_DEVICES%%
	>> %STATUS_FILE% echo goto :exit	
	call .\windows\scripts\default-footer.bat %STATUS_FILE%
	>> %STATUS_FILE% echo echo Done^^^^^^^^^^!
	echo Done^^!
	call %STATUS_FILE%
	goto :exit
	
:help
	more README
	goto :EOF

:abort 
	echo Aborting^^!
	exit /b 1
	

:exit

	if %DISPLAY_PATH% == 1 (
		echo Please update your user PATH variable. If use you use it, please remove surrounding quotes.  The path generated for use is:
		echo "%PATH%"
	)
	if %DISPLAY_JAVA_HOME% == 1 (
		echo Please update your user JAVA_HOME variable. If use you use it, please remove surrounding quotes. The JAVA_HOME generated is:
		echo "%JAVA_HOME%"
	)
	echo Success. Bye^^!
	exit /b