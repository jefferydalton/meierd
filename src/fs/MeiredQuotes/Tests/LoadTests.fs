module MeiredQuotes.Tests.LoadTests

open NUnit.Framework
open MeiredQuotes.Load.storeQuotes

[<Test>]
let ``storeQuote should return true``() =
    let resultStore = storeDocument()
    Assert.IsTrue(resultStore)


