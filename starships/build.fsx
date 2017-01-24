// include Fake libs
#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.NpmHelper

let clientDir  = "./webapp/"
let buildDir  = "./build/"
let testDir  = "./tests/"
let clientBuildDir  = "./build/webapp"
let pkgDir = "./releases/"

let appName = "Starships.Server.exe"
let testAppName = "StarshipBook.WebUI.Tests.exe"

let appReferences  =
    !! "Starships.Server/Starships.Server.fsproj"
let testsReferences =
    !! "StarshipBook.WebUI.Tests/StarshipBook.WebUI.Tests.fsproj"

let version = "0.1"  // or retrieve from CI server


// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; pkgDir; clientBuildDir]
)

Target "Build App" (fun _ ->
    // compile all projects below src/app/
    MSBuildDebug buildDir "Build" appReferences
        |> Log "AppBuild-Output: "
)

Target "Build Client" (fun _ ->
    Npm <| fun p ->
            { p with
                // TODO set properly the path to npm
                NpmFilePath = @"C:\Program Files\nodejs\npm.cmd"
                Command = Run "build"
                WorkingDirectory = clientDir
            }
    CopyDir clientBuildDir (clientDir @@ "dist/") (fun _ -> true)
)

Target "Build Tests" (fun _ ->
    MSBuildDebug testDir "Build" testsReferences
        |> Log "AppBuild-Output: "
)

Target "Run Server" <| fun _ ->
    StartProcess <| fun p ->
        p.FileName <- FullName <| buildDir @@ appName
        p.WorkingDirectory <- buildDir
    Async.Sleep 3000 |> Async.RunSynchronously

Target "Run Client" <| fun _ ->
    System.Diagnostics.Process.Start ("http://127.0.0.1:8080/index.html") |> ignore

Target "Run App" <| fun _ ->
    printfn "Press enter to kill the server..."
    System.Console.ReadLine () |> ignore
    killAllCreatedProcesses ()

Target "Run Web UI Tests" <| fun _ ->
    let result =
        ExecProcess 
            <| fun pinfo ->
                pinfo.FileName <- FullName <| testDir @@ testAppName
                pinfo.WorkingDirectory <- testDir
            <| System.TimeSpan.FromMinutes 5.

    if result <> 0 then failwith "Failed result from unit tests"


Target "Package" (fun _ ->
    !! (buildDir + "/**/*.*")
        -- "*.zip"
        |> Zip buildDir (pkgDir + "StarshipBook." + version + ".zip")
)

Target "Default" DoNothing
Target "Test" DoNothing
Target "Deploy" DoNothing

// Build order
"Clean"
    ==> "Build App"
    ==> "Build Client"
    ==> "Default"

"Default" 
    ==> "Run Server"
    ==> "Run Client"
    ==> "Run App"

"Default" 
    ==> "Build Tests"
    ==> "Run Server"
    ==> "Run Client"
    ==> "Run Web UI Tests"
    ==> "Test"

"Default" 
    ==> "Package" 
    ==> "Deploy"

RunTargetOrDefault "Default"
