module Types

open System

type TechnicalParameter =
    | MGLT of string
    | CargoCapacity of string
    | Consumables of string
    | CostinCredits of string
    | Crew of string
    | HyperdriveRating of string
    | Length of string
    | Manufacturer of string
    | MaxAtmospheringSpeed of string
    | Model of string
    | Name of string
    | Passengers of string
    | StarshipClass of string

    with 

    static member Unbox = function
        | MGLT x -> unbox x
        | CargoCapacity x -> unbox x
        | Consumables x -> unbox x
        | CostinCredits x -> unbox x
        | Crew x -> unbox x
        | HyperdriveRating x -> unbox x
        | Length x -> unbox x
        | Manufacturer x -> unbox x
        | MaxAtmospheringSpeed x -> unbox x
        | Model x -> unbox x
        | Name x -> unbox x
        | Passengers x -> unbox x
        | StarshipClass x -> unbox x

    static member GetName = function
        | MGLT _ -> "MGLT"
        | CargoCapacity _ -> "Cargo Capacity"
        | Consumables _ -> "Consumables"
        | CostinCredits _ -> "Cost in Credits"
        | Crew _ -> "Crew"
        | HyperdriveRating _ -> "Hyperdrive Rating"
        | Length _ -> "Length"
        | Manufacturer _ -> "Manufacturer"
        | MaxAtmospheringSpeed _ -> "Max Atmosphering Speed"
        | Model _ -> "Model"
        | Name _ -> "Name"
        | Passengers _ -> "Passengers"
        | StarshipClass _ -> "Starship Class"

type TechnicalInfo = {
    MGLT: string
    CargoCapacity: string
    Consumables: string
    CostinCredits: string
    Crew: string
    HyperdriveRating: string
    Length: string
    Manufacturer: string
    MaxAtmospheringSpeed: string
    Model: string
    Passengers: string
    StarshipClass: string
}

type Starship = 
    {
        Name: string
        Image: string
        TechnicalInfo: TechnicalInfo
        Films: string list
        Pilots: string list
        Url: string
    }

let getTechnicalParametersList starship =
    let { TechnicalInfo = x } = starship
    [
        MGLT x.MGLT
        CargoCapacity x.CargoCapacity
        Consumables x.Consumables
        CostinCredits x.CostinCredits
        Crew x.Crew
        HyperdriveRating x.HyperdriveRating
        Length x.Length
        Manufacturer x.Manufacturer
        MaxAtmospheringSpeed x.MaxAtmospheringSpeed
        Model x.Model
        Passengers x.Passengers
        StarshipClass x.StarshipClass
    ]
