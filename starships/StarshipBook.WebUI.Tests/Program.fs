open canopy
open runner


[<EntryPoint>]
let main argv =

    let path = "./"
    configuration.chromeDir <- path

    start chrome

    "Check for any starship present in the list" &&& fun _ ->

        url "http://127.0.0.1:8083/index.html"

        let starships = elements ".starship-box"

        starships |> List.length > 0
        |> (===) true

    "Check if context info is present" &&& fun _ ->

        url "http://127.0.0.1:8083/index.html"

        notContains "Context info goes here" <| read ".movie-context-info"

    run()

    Async.Sleep 1000 |> Async.RunSynchronously

    quit()

    canopy.runner.failedCount
