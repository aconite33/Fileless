# Fileless

Proof of Concept for loading assembly from memory without touching disk.

Based on the following repositories:

* G0ldenGunSec's Assembly Loader - https://github.com/G0ldenGunSec/SharpTransactedLoad
* Rastamouse's disposal AppDomain - https://rastamouse.me/net-reflection-and-disposable-appdomains/
* CCob's MinHook.Net implementation - https://github.com/CCob/MinHook.NET

## Problem Statement

While these proof of concept works when compiled as Fileless.exe, the moment you change the filename to anything but what it is compiled/defined in the assembly, a file not found error is thrown.

```
C:\Users\User1\source\repos\Fileless\Fileless\bin\Debug>dir Fileless.exe
 Volume in drive C has no label.
 Volume Serial Number is 30E5-C898

 Directory of C:\Users\User1\source\repos\Fileless\Fileless\bin\Debug

12/21/2021  11:18 PM         1,143,296 Fileless.exe
               1 File(s)      1,143,296 bytes
               0 Dir(s)  40,792,010,752 bytes free

C:\Users\User1\source\repos\Fileless\Fileless\bin\Debug>move Fileless.exe payload.exe
        1 file(s) moved.

C:\Users\User1\source\repos\Fileless\Fileless\bin\Debug>payload.exe
Starting program...
mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Fileless, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
[*] Parsing skipped, using Fileless.exe as assembly name

[*] Kicking off assembly load process
    --Transaction created
      |-> Name: SksdFTBW
      |-> Handle: 796
    --Transacted file created
      |-> Name: C:\Users\User1\Desktop\cUKFPIzG.log
      |-> Handle: 272
    --Bytes written to transacted file: 1143296
[*] Intercepted hooked GetFileAttributes call for our assembly
[*] Intercepted hooked GetFileAttributesEx call for our assembly
[*] Intercepted hooked CreateFileW call for our assembly
[*] Intercepted hooked CreateFileW call for our assembly
[*] Intercepted hooked GetFileInformationByHandle for our assembly
[*] Intercepted hooked GetFileAttributesEx call for our assembly
[*] Cleaned up handles and hooks
[+] Successfully loaded assembly, passing object back to caller
ShadowRunner.Args[0]:Fileless.exe
Bypassing Fileless.exe
Loaded original assembly.
Creating new AppDomain

Unhandled Exception: System.IO.FileNotFoundException: Could not load file or assembly 'Fileless, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
   at System.Reflection.RuntimeAssembly._nLoad(AssemblyName fileName, String codeBase, Evidence assemblySecurity, RuntimeAssembly locationHint, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean throwOnFileNotFound, Boolean forIntrospection, Boolean suppressSecurityChecks)
   at System.Reflection.RuntimeAssembly.nLoad(AssemblyName fileName, String codeBase, Evidence assemblySecurity, RuntimeAssembly locationHint, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean throwOnFileNotFound, Boolean forIntrospection, Boolean suppressSecurityChecks)
   at System.Reflection.RuntimeAssembly.InternalLoadAssemblyName(AssemblyName assemblyRef, Evidence assemblySecurity, RuntimeAssembly reqAssembly, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean throwOnFileNotFound, Boolean forIntrospection, Boolean suppressSecurityChecks)
   at System.Activator.CreateInstance(String assemblyString, String typeName, Boolean ignoreCase, BindingFlags bindingAttr, Binder binder, Object[] args, CultureInfo culture, Object[] activationAttributes, Evidence securityInfo, StackCrawlMark& stackMark)
   at System.Activator.CreateInstance(String assemblyName, String typeName)
   at System.AppDomain.CreateInstance(String assemblyName, String typeName)
   at System.AppDomain.CreateInstanceAndUnwrap(String assemblyName, String typeName)
   at System.AppDomain.CreateInstanceAndUnwrap(String assemblyName, String typeName)
   at Fileless.Program.Main(String[] args) in C:\Users\User1\source\repos\Fileless\Fileless\Program.cs:line 34
```
