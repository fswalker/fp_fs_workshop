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
    
    // TODO_4
    // get parameter name and balues from props

    // TODO_5
    // create contextItems based on values
         
    // TODO_6
    // Create html structure for parameter
    // use contextItems as children; hint: look on other components like StarshipBox, etc.
    R.div [] [ unbox "Context info goes here" ]
