// Good luck! :)

// 1. add reference for FSharp.Data.dll
#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"

// 2. open namespace for FSharp.Data
open FSharp.Data

// 3. add `api` binding, decorate it with Literal attribute
// What is the syntax for attributes?
[<Literal>]
let api = "http://swapi.co/api/"
// 4. Construct `peopleUrl` using `api` binding
[<Literal>]
let peopleUrl = api + "people/"

// 5. Create `AllPeople` type
// Use `JsonProvider` type provider from FSharp.Data
type AllPeople = JsonProvider<peopleUrl>

// 6.a. use `GetSample` method (from `AllPeople` type provider)
// What does it do?
let people = AllPeople.GetSample ()
// 6.b. print how many people is in sample?
// hint use . and take results first
people.Results
|> Seq.length
|> printfn "%i" 
// 6.c. how many people is in Swapi DB?
// hint: use Count property
printfn "%i people alltogether" people.Count

// 6.d. use `Load` method for in order to fetch page no. 3 from people endpoint
// hint "?page=3" string may be useful 
let page3 = AllPeople.Load (peopleUrl + "?page=3")
// 6.e. display people's names using `Seq.map` and Seq.iter
page3.Results
|> Seq.map (fun p -> p.Name)
|> Seq.iter (printfn "%s")

// 7. implement `getAllPeople` recursive function (use `rec` keyword)
// pass two arguments: `url` and `people`
let rec getAllPeople url people =
    // use pattern matching for two cases
    match url with
    | "" -> people |> List.rev |> Array.concat
    | url ->
        // use Http.RequestString method to obtain json
        let json = Http.RequestString (url)
        // parse json using `Parse` fn from `AllPeople` type provider instance
        let current = AllPeople.Parse (json)
        // recursive call goes here
        // hint `::` operator may prove useful
        getAllPeople current.Next (current.Results :: people)



// 8. create `Paging` type for json:
// {"next": "http://swapi.co/api/people/?page=2"}
// triple " operator may be helpful
type Paging = JsonProvider<"""{"next": "http://swapi.co/api/people/?page=2"}""">

// 9. Try to make `getAllPeople` fn more abstract and reusable - name it `getAll`
// Use higher order functions concept
// Other useful functions: `List.rev`, `Array.concat`
// Three parameters: url parser and acc for accumulator
let rec getAll url parser acc =
    match url with
    | "" -> acc |> List.rev |> Array.concat
    | url ->
        let json = Http.RequestString (url, responseEncodingOverride = "UTF-8")
        let next = Paging.Parse(json).Next
        let current = parser json
        getAll next parser (current :: acc)


// 10. create peopleParser
// try to play with lambdas and >> operator
let peopleParser = AllPeople.Parse >> (fun ps -> ps.Results)

// Use it for comparison
let expected = getAllPeople peopleUrl []

expected |> Seq.length
expected |> Seq.head
expected |> Seq.item 1
expected |> Seq.item 25
expected |> Seq.last
expected |> Array.map (fun p -> p.Url)


// 11. get all people using brand new `getAll` function
let allPeople = getAll peopleUrl peopleParser []

allPeople |> Seq.length
allPeople |> Seq.head
allPeople |> Seq.item 1
allPeople |> Seq.item 25
allPeople |> Seq.last

// Bonus tasks
// *12. 
// Try to fix getAll function in order to return Utf-8 characters properly
// Hint - read Http.RequestString docs on Github
// There is one optional parameter which - when properly set - will solve the issue

// *13. Experiment with different entities - planets, starships

// May the force be with you! :)
