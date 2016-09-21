// Good luck! :)

// 1. add reference for FSharp.Data.dll

// 2. open namespace for FSharp.Data

// 3. add `api` binding, decorate it with Literal attribute
// What is the syntax for attributes?


// 4. Construct `peopleUrl` using `api` binding



// 5. Create `AllPeople` type
// Use `JsonProvider` type provider from FSharp.Data


// 6.a. use `GetSample` method (from `AllPeople` type provider)
// What does it do?

// 6.b. print how many people is in sample?
// hint use . and take results first



// 6.c. how many people is in Swapi DB?
// hint: use Count property


// 6.d. use `Load` method for in order to fetch page no. 3 from people endpoint
// hint "?page=3" string may be useful 

// 6.e. display people's names using `Seq.map` and Seq.iter




// 7. implement `getAllPeople` recursive function (use `rec` keyword)
// pass two arguments: `url` and `people`
let rec getAllPeople url people =
    // use pattern matching for two cases


        // use Http.RequestString method to obtain json

        // parse json using `Parse` fn from `AllPeople` type provider instance
        
        // recursive call goes here
        // hint `::` operator may prove useful



// 8. create `Paging` type for json:
// {"next": "http://swapi.co/api/people/?page=2"}
// triple " operator may be helpful


// 9. Try to make `getAllPeople` fn more abstract and reusable - name it `getAll`
// Use higher order functions concept
// Other useful functions: `List.rev`, `Array.concat`
// Three parameters: url parser and acc for accumulator











// 10. create peopleParser
// try to play with lambdas and >> operator


// Use it for comparison
let expected = getAllPeople peopleUrl []

expected |> Seq.length
expected |> Seq.head
expected |> Seq.item 1
expected |> Seq.item 25
expected |> Seq.last
expected |> Array.map (fun p -> p.Url)


// 11. get all people using brand new `getAll` function
let allPeople = 

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
