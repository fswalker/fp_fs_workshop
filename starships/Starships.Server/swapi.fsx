#r "../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#load "StarshipsSample.fs"
#load "swapi.fs"
open FSharp.Data
open StarWars.API

let starships = getAllStarships ()
printfn "Number of starships: %d" starships.Length

let starship = starships |> Seq.head
starship.CostInCredits.JsonValue.AsInteger64()
starship.CostInCredits.Number
starship.CostInCredits.String
let x = { (starship.CostInCredits :> Runtime.BaseTypes.IJsonDocument) with JsonValue = "123km" }

starship.CostInCredits.JsonValue.AsInteger()
starship.CostInCredits.JsonValue.AsString()
starship.CostInCredits.JsonValue.AsBoolean()

let costInCredits =
    starships
    |> Array.map (fun s -> s.CostInCredits)

let mas =
    starships
    |> Array.map (fun s -> s.MaxAtmospheringSpeed)

let cc =
    starships
    |> Array.map (fun s -> s.CargoCapacity)

let l =
    starships
    |> Array.map (fun s -> s.Length)

let x = AllStarships.Int64OrString ("unknown")
x.Number
x.String

let r =
    match x with
    | a when a.Number.IsSome -> a.Number
    | _ -> None

//starships |> Array.find (fun s -> match s.Pilots with | [p] -> true | _ -> false) |> addPilotsNames
