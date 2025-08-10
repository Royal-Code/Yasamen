@echo off
setlocal enabledelayedexpansion

:: Starts the scan from the folder where the script is running
for /r %%d in (*.csproj) do (
    set "folder=%%~dpd"
    
    :: Check if the 'bin' folder exists and delete it
    if exist "!folder!bin" (
        echo Deleting the bin folder in: !folder!
        rmdir /s /q "!folder!bin"
    )
    
    :: Check if the 'obj' folder exists and delete it
    if exist "!folder!obj" (
        echo Deleting the obj folder in: !folder!
        rmdir /s /q "!folder!obj"
    )
)

echo Completed.
pause
