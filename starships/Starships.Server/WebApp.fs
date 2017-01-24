module WebApp

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config
open Suave.Filters
open Suave.Operators
open Suave.RequestErrors

open Microsoft.FSharpLu.Json

open DataLayer

let JSON o =
    Compact.serialize o
    |> OK >=> Writers.setMimeType "application/json; charset=utf-8"

// TODO_7
// Make starships a fn which accepts unit
// Add printfn expression which prints some message
// Run server, load /api/starships in browser, refresh a few times
// What is wrong?
// Use warbler helper fn from Suave
// How does it work?
// Again run server, load /api/starships in browser, refresh a few times
let starhipsApiPathWebPart = 
    let starshipsApiUrl = "/api/starships" 
    let starships = getStarships ()
    choose [
        path starshipsApiUrl
        path (starshipsApiUrl + "/") ]
    >=> JSON starships 

let app =
    choose [
        GET >=> choose [
            starhipsApiPathWebPart
            path "/" >=> Files.browseFileHome "index.html"
            Files.browseHome
            NOT_FOUND "This is not the site you are looking for. - FsYoda" ]
    ]
