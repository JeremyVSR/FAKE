﻿[<AutoOpen>]
module Fake.MSIHelper

open System
open System.IO

type MSIParams =
    { ToolPath: string
      WorkingDir:string
      LogFile:string
      TimeOut: TimeSpan}

/// MSI default params  
let MSIDefaults =
    { ToolPath = "msiexec "
      WorkingDir = "."
      LogFile = "InstallLog.txt"
      TimeOut = TimeSpan.FromMinutes 5. }

let Install setParams setup = 
    traceStartTask "MSI-Install" setup
    let parameters = setParams MSIDefaults
    
    if not (execProcess3 (fun info ->  
        info.FileName <- parameters.ToolPath
        info.WorkingDirectory <- parameters.WorkingDir
        info.Arguments <- sprintf "/qb /l* %s /i %s" parameters.LogFile setup) parameters.TimeOut)
    then
        failwith "MSI-Install failed."
                  
    traceEndTask "MSI-Install" setup

let Uninstall setParams setup = 
    traceStartTask "MSI-Uninstall" setup
    let parameters = setParams MSIDefaults
    
    if not (execProcess3 (fun info ->  
        info.FileName <- parameters.ToolPath
        info.WorkingDirectory <- parameters.WorkingDir
        info.Arguments <- sprintf "/qb /l* %s /x %s" parameters.LogFile setup) parameters.TimeOut)
    then
        failwith "MSI-Uninstall failed."
                  
    traceEndTask "MSI-Uninstall" setup