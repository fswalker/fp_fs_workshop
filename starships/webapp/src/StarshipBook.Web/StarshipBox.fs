module Starship

open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props

open Types
open ContextInfoParameter
open TechnicalInfoParameter


type StarshipProps = Starship

let StarshipBox (props: StarshipProps) =

    let starship = props

    let technicalInfoParameters =
        starship
        |> getTechnicalParametersList
        |> List.map TechnicalInfoParameter

    let alt = sprintf "%s image"
        
    R.div [ ClassName "starship-box" ] [
        R.h3 [ ClassName "characteristic-title" ] [ unbox starship.Name ]
        R.div [ ClassName "characteristics-box" ] [
            R.img [ Src starship.Image; Alt <| alt starship.Name; ClassName "starship-img" ] []
            R.div [ ClassName "technical-info" ] [
                R.ul [] technicalInfoParameters
            ]
        ]
        R.div [ ClassName "movie-context-info" ] [
            ContextInfoParameter { parameter = "Films"; values = starship.Films }
            ContextInfoParameter { parameter = "Pilots"; values = starship.Pilots }
        ]
    ]
