module MeiredQuotes.Tests.ExtractTests

open NUnit.Framework
open MeiredQuotes.Extract


[<Test>]
let ``parseQuotes should return 1 quote with Author Adam Ant``() =
    let resultQuotes = parseQuotes.getQuotes(@"http://sourcesofinsight.com/inspirational-quotes/")
    Assert.AreEqual(resultQuotes.Length, 1)
    Assert.AreEqual(resultQuotes.Head.Author, "Adam Ant")


