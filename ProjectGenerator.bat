@echo off
setlocal

:: Path to the project file
set "projectPath=ProjectGenerator\ProjectGenerator.csproj"

:: Project exe Path
set "exePath=ProjectGenerator\bin\Release\net8.0\ProjectGenerator.exe"

:: MsBuild Path
set "msbuild=C:\Program Files\Microsoft Visual Studio\18\Professional\MSBuild\Current\Bin\MSBuild.exe"

:: Check MSBuild is available
if exist "%msbuild%" (
	echo Found MSBuild in path: %msbuild%.
) else (
	echo MSBuild is not installed or not in path.
	goto end
)

:: Check if the project file exist
if exist "%projectPath%" (
	echo Build project: %projectPath%
	"%msbuild%" "%projectPath%" /t:Restore /t:Build /p:Configuration=Release
	echo Build Completed.....
) else (
	echo project file not found: %projectPath%
)

:: Check if the exe file exist
if exist "%exePath%" (
	echo Run project: %exePath%
	%exePath%
) else (
	echo exe file not found: %exePath%
)

if exist "UISuite_SB\projectgenerator" rmdir "UISuite_SB\projectgenerator" /s /q
:end
endlocal