#r "../packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "../Starships.Core/bin/Debug/Starships.Core.dll"
#load "StarshipsSample.fs"
#load "swapi.fs"
#load "Data.fs"

open DataLayer

let starships = getStarships()
