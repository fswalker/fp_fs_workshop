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

let starhipsApiPathWebPart = 
    let starshipsApiUrl = "/api/starships" 
    choose [
        path starshipsApiUrl 
        path (starshipsApiUrl + "/") ]
    >=> warbler (fun _ ->
        getStarships () |> JSON)

let app =
    choose [
        GET >=> choose [
            starhipsApiPathWebPart
            path "/" >=> Files.browseFileHome "index.html"
            Files.browseHome
            NOT_FOUND "This is not the site you are looking for. - FsYoda" ]
    ]
