## Compilation Instructions

This is the source code to a basic CRUD MemberRegistry for the console. To download and compile from the command line, do as follows:

### Install dotnet
Install dotnet depending on your operationg system, instructions [here] (https://www.microsoft.com/net/core).

### Initiate the project
1. Download the source code.
2. cd into the project directory.
3. Initiate a new project with the following command:
```
dotnet new console
```
4. Replace the code in newly created Program.cs with the code in Application.cs.

### Add dependencies
1. Run the command
```
dotnet add package Newtonsoft.Json --version 10.0.3
```
to install the Newtonsoft.Json dependency.
2. Create a "runtime identifier" for the runtime(s) you would like to compile for, choosing from the following [list] (https://docs.microsoft.com/en-us/dotnet/core/rid-catalog), like so:
```
<PropertyGroup>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
</PropertyGroup>
```
Separate different runtimes with semicolons.
3. Restore the dependencies with:
```
dotnet restore
```

### Compile the project
4. Publish the project with the name of the runtime from your runtime identifier:
```
dotnet publish -c Release -r [name-of-runtime]
```
ex: 
```
dotnet publish -c Release -r win10-x64
```

### Launch
6. Starting from your project file, find the directory at the path bin/Release/netcoreapp1.1/[your-selected-runtime]/publish
7. Launch the applicationin a console by running the file named implementation.exe, in a platform-specific way depending on the runtime you chose.
