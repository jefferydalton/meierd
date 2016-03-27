module MeiredQuotes.Tests.ExtractTests

open NUnit.Framework
open MeiredQuotes.Extract


[<Test>]
let ``Basic Test``() =
    Assert.AreEqual(1, 1)

[<Test>]
let ``parseQuotes should return 1 quote``() =
    let resultQuotes = parseQuotes.getQuotes("foo")
    Assert.AreEqual(resultQuotes.Length, 1)
