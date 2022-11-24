# Merge Application
Command Line Tool to merge overlapping intervals.

`|C#|.net6|`

## Usage
### Systemrequirements
* Windows 10

### Args
* `?` - Show command line documentation
* `<interval>` - Each interval must be given as individual parameter to the program. Example: `[10,15]`

### Call Program
* Run for Windows 10 (x64) open CMD or Powershell `.\MergeApplication.exe <args>`
* Example Call: `.\MergeApplication.exe [25,30] [2,19] [14,23] [4,8]`
* Result of the program is written to console
* Example result: `.\MergeApplication.exe [2,23] [25,30]`


## Build
### Systemrequirements
* Windows 10 (x64)
* Microsoft .Net 6.0.4 - Windows Server Hosting

### Scipts
* Build for Windows 10 (x64) with runtime included CMD/Powershell `dotnet publish -c Release ./MergeApplication/MergeApplication.csproj -o "./target"`
* Build result is in target folder (MergeApplication.exe).


## Test
### Systemrequirements
* Windows 10 (x64)
* Microsoft .Net 6.0.4 - Windows Server Hosting

### Scipts
* Run unittests for Windows 10 (x64) CMD/Powershell `dotnet test -c Release ./MergeApplicationTests/MergeApplicationTests.csproj`
* Test result will be displayed in command line