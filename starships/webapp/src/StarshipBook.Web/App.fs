module App

open Fable.Core
open Fable.Import
module R = Fable.Helpers.React

open StarshipBook

Node.require.Invoke("core-js") |> ignore
Node.require.Invoke("../styles/main.sass") |> ignore

let apiUrl = "/api/starships/"

ReactDom.render(
    R.com<StarshipBook,StarshipBookProps,StarshipBookState> { url = apiUrl } [],
    Browser.document.querySelector "#app")
|> ignore
