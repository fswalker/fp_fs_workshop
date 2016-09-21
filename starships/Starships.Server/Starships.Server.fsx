#r "../packages/Suave/lib/net40/Suave.dll"
#r "../packages/Newtonsoft.Json/lib/net45/Newtonsoft.Json.dll"
#r "../packages/Microsoft.FSharpLu.Json/lib/net452/Microsoft.FSharpLu.Json.dll"
#r "../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "../Starships.Core/bin/Debug/Starships.Core.dll"

open System
open System.Reflection
open System.IO

open Microsoft.FSharpLu.Json

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config
open Suave.Filters
open Suave.Operators
open Suave.RequestErrors

open Types

#load "StarshipsSample.fs"
#load "swapi.fs"
#load "Data.fs"
open DataLayer

#load "WebApp.fs"
open WebApp

#load "Program.fs"
open Program
