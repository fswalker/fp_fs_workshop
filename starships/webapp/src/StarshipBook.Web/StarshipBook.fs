module StarshipBook

open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props

open Types
open Utils
open StarshipsList

type StarshipBookProps = {
    url: string
}
type StarshipBookState = {
    data: Starship []
}

type StarshipBook (props) as this =
    inherit React.Component<StarshipBookProps,StarshipBookState>()
    do this.state <- { data = [||] }

    member x.loadStarships () =
        ajax (Get x.props.url)
            (fun data -> x.setState { data = data })
            (fun status ->
                Browser.console.error(x.props.url, status))

    member x.componentDidMount () =
        x.loadStarships ()
    
    member x.render () =
        R.div [ ClassName "starshipbook-app" ] [
            R.header [ ClassName "header" ] [
                R.img [ Src "img/star_wars.png"; Alt "Star Wars logo"; ClassName "starwars-logo" ] []
                R.h1 [ ClassName "title" ] [ unbox "starshipbook" ]
            ]
            R.fn StarshipsList x.state.data []
        ]
