open canopy
open runner


[<EntryPoint>]
let main argv =

    let path = "./"
    configuration.chromeDir <- path

    let webAppUrl = "http://127.0.0.1:8080/index.html"

    start chrome

    "Check for any starship present in the list" &&& fun _ ->

        url webAppUrl

        let starships = elements ".starship-box"

        starships |> List.length > 0
        |> (===) true

    "Check if context info is present" &&& fun _ ->

        url webAppUrl

        notContains "Context info goes here" <| read ".movie-context-info"

    run()

    Async.Sleep 1000 |> Async.RunSynchronously

    quit()

    canopy.runner.failedCount
