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

// TODO_1
let addFilmsTitles filmsDict starship =
    // Get films urls from starship
    // find title in films dictionary
    // handle None; hint: use defaultArg
    // return updated starship
    starship

// TODO_2
let addPilotsNames starship =
    // get Pilots urls from starship
    // switch to Array
    // use Array.Parallel module to load person from swapi and get name
    // update starship with pilots names
    starship

// TODO_3
let getStarships () =

    // create filmsDict based on all star wars films


    // get all starships
    // use raw2Starship mapping function
    // add films titles to starships using filmsDict
    // use Array.Parallel module to add pilots names
    // return list
    getAllStarships ()
    |> Array.map raw2Starship
    |> Array.toList
