@echo off 

if not exist ./DB/DB.sqlite3 (
    sqlite3.exe ./DB/DB.sqlite3 < ./DB/config.sql
)

if exist ./DB/DB.sqlite3 (
    if "%1" == "--no-build" (
        dotnet run --project ./CarWPF/CarWPF.csproj --no-build
    ) else (
        dotnet run --project ./CarWPF/CarWPF.csproj 
    )
) else (
    echo ERROR: There is no DB.sqlite3 inside ./DB folder. 
)
