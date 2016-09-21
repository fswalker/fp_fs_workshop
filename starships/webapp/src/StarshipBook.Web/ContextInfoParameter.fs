module ContextInfoParameter

open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props


type ContextInfoParameterProps = {
    parameter: string
    values: string list
}

let ContextInfoParameter (props) =
    
    let { parameter = parameter 
          values = values } = props

    let contextItems =
        values
        |> List.map (fun v ->
            R.li [ ClassName "movie-context-item" ] [ 
                R.span [ ClassName "value" ] [ unbox v ] ])
         
    R.div [ ClassName "parameter" ] [
        R.h4 [ ClassName "movie-context-title" ] [ unbox <| sprintf "%s: " parameter ]
        R.ul [ ClassName "movie-context-list" ] contextItems
    ]
