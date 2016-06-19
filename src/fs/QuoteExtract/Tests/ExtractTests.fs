module MeiredQuotes.Extract.FS.Tests


open NUnit.Framework
open MeiredQuotes.Extract.FS.QuoteExtract
open System.Linq

[<Test>]
let ``Extract should return non empty list of type quote``() =
    let result = Extract.PullQuotes(@"http://sourcesofinsight.com/inspirational-quotes/")
    Assert.AreNotEqual(result.Length, 0)

[<Test>]
let ``Extract should return non empty list of type quote from Achievement category``() =
    let result = Extract.PullQuotes(@"http://sourcesofinsight.com/inspirational-quotes/")
    Assert.AreNotEqual(result.Where(fun (x) -> x.Category = "Achievement").Count(), 0);

[<Test>]
let ``Extract should throw exception with null input``() =
    Assert.Throws<System.ArgumentException>(fun () -> Extract.PullQuotes(null)|> ignore)
    |> ignore

[<Test>]
let ``Extract should throw exception with empty input``() =
    Assert.Throws<System.ArgumentException>(fun () -> Extract.PullQuotes("")|> ignore)
    |> ignore

//[<Test>]
//let ``parseQuotes should return 1 quote with Author Adam Ant``() =
//    let resultQuotes = parseQuotes.getQuotes(@"http://sourcesofinsight.com/inspirational-quotes/")
//    Assert.AreEqual(resultQuotes.Length, 1)
//    Assert.AreEqual(resultQuotes.Head.Author, "Adam Ant")


