module DataLayer

open Types
open StarWars.API

let raw2Starship (raw: AllStarships.Result) =
    {
        Name = raw.Name
        // TODO
        Image = "img/13.jpg"
        TechnicalInfo = { MGLT = defaultArg raw.Mglt.String ""
                          CargoCapacity = defaultArg raw.CargoCapacity.String ""
                          Consumables = raw.Consumables
                          CostinCredits = defaultArg raw.CostInCredits.String ""
                          Crew = defaultArg raw.Crew.String ""
                          HyperdriveRating = defaultArg raw.HyperdriveRating.String ""
                          Length = defaultArg raw.Length.String ""
                          Manufacturer = raw.Manufacturer
                          MaxAtmospheringSpeed = defaultArg raw.MaxAtmospheringSpeed.String ""
                          Model = raw.Model
                          Passengers = defaultArg raw.Passengers.String ""
                          StarshipClass = raw.StarshipClass }
        Films = raw.Films |> Array.toList
        Pilots = raw.Pilots |> Array.toList
        Url = raw.Url
    }

let addFilmsTitles filmsDict starship =
    let titles = 
        starship.Films
        |> List.map (fun url -> Map.tryFind url filmsDict)
        |> List.map (fun title -> defaultArg title "")
    { starship with Films = titles }

let addPilotsNames starship =
    let pilots = 
        starship.Pilots
        |> List.toArray
        |> Array.Parallel.map (Person.Load >> (fun p -> p.Name))
        |> Array.toList
    { starship with Pilots = pilots }

let getStarships () =

    let filmsDict = 
        getAllFilms ()
        |> Array.map (fun f -> f.Url, f.Title)
        |> Map.ofArray

    getAllStarships ()
    |> Array.map raw2Starship
    |> Array.map (addFilmsTitles filmsDict)
    |> Array.Parallel.map addPilotsNames
    |> Array.toList
