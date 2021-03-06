﻿[<AutoOpen>]
[<System.Obsolete("This function, type or module is obsolete. There is no alternative in FAKE 5 yet. If you need this functionality consider porting the module (https://fake.build/contributing.html#Porting-a-module-to-FAKE-5).")>]
/// Contains helper functions for [Microsoft Visual SourceSafe](http://en.wikipedia.org/wiki/Microsoft_Visual_SourceSafe)
module Fake.VSSHelper

/// Retrieves the given label of the given project from Microsoft Visual SourceSafe
[<System.Obsolete("This function, type or module is obsolete. There is no alternative in FAKE 5 yet. If you need this functionality consider porting the module (https://fake.build/contributing.html#Porting-a-module-to-FAKE-5).")>]
let getVSSProjectWithLabel toolPath srcSafeIni username password project (localSpec : string) label = 
    let args' = 
        let s = 
            localSpec
            |> FullName
            |> trimSeparator
            
        sprintf "get %s -R \"-GL%s\" -I-Y -Y%s,%s -GTM" project s username password
    
    let args = 
        if isNullOrEmpty label then args'
        else sprintf "%s -Vl%s" args' label
    
    tracefn "%s %s" toolPath args
    let result = 
        ExecProcess (fun info -> 
            [ "SSDIR", srcSafeIni ] |> setEnvironmentVariables info
            info.FileName <- toolPath
            info.WorkingDirectory <- currentDirectory
            info.Arguments <- args) System.TimeSpan.MaxValue
    if result <> 0 then failwith "Could not get sources from VSS"

/// Retrieves the given project from Microsoft Visual SourceSafe    
[<System.Obsolete("This function, type or module is obsolete. There is no alternative in FAKE 5 yet. If you need this functionality consider porting the module (https://fake.build/contributing.html#Porting-a-module-to-FAKE-5).")>]
let getVSSProject toolPath srcSafeIni username password project localSpec = 
    getVSSProjectWithLabel toolPath srcSafeIni username password project localSpec ""
