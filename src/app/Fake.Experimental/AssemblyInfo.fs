﻿namespace System
open System.Reflection
open System.Runtime.InteropServices

[<assembly: AssemblyTitleAttribute("FAKE - F# Make Experimental Lib")>]
[<assembly: GuidAttribute("5AA28AED-B9D8-4158-A594-32FE5ABC5713")>]
[<assembly: AssemblyProductAttribute("FAKE - F# Make")>]
[<assembly: AssemblyVersionAttribute("4.41.8")>]
[<assembly: AssemblyInformationalVersionAttribute("4.41.8")>]
[<assembly: AssemblyFileVersionAttribute("4.41.8")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "4.41.8"
    let [<Literal>] InformationalVersion = "4.41.8"
