module Program

open System
open System.Reflection
open System.IO

open Microsoft.FSharpLu.Json

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config

open WebApp


#if INTERACTIVE
let clientDir = Path.Combine(FileInfo(__SOURCE_DIRECTORY__).Directory.FullName, Path.Combine("webapp", "dist"))
#else
let clientDir =
    let exePath = Assembly.GetEntryAssembly().Location
    let exeDir = (new FileInfo(exePath)).Directory
    Path.Combine(exeDir.FullName, "webapp")
#endif

printfn "clientDir: %s" clientDir

let cfg = { defaultConfig with
                homeFolder = Some clientDir
          }

startWebServer cfg app
