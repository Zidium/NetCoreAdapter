@echo off
dotnet pack NetCoreLogger\NetCoreLogger.csproj -o %~dp0Nuget\ -c release -v normal
pause