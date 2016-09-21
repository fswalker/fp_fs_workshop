module StarshipsList

open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props

open Types
open Starship


type StarshipsListProps = Starship []

let StarshipsList (props: StarshipsListProps) =

    let starships =
        props
        |> Array.map (fun starship -> R.fn StarshipBox starship [])
        |> Array.toList
    
    R.div [ ClassName "starships-list" ] starships
