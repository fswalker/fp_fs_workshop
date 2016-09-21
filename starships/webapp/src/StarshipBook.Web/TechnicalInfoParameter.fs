module TechnicalInfoParameter

open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props

open Types

type TechnicalInfoParameterProps = TechnicalParameter

let TechnicalInfoParameter (props: TechnicalInfoParameterProps) =
    R.li [ ClassName "parameter" ] [
        R.p [] [
            R.span [ ClassName "label" ] [ TechnicalParameter.GetName props |> sprintf "%s: " |> unbox ]
            R.span [ ClassName "value" ] [ unbox TechnicalParameter.Unbox props ]
        ]
    ]
