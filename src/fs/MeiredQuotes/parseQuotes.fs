module MeiredQuotes.Extract.parseQuotes

open FSharp.Data



type Quote = {Category:string; Author:string; QuoteText:string;}
let getQuotes(url:string) =
    let pageHtml = 
        HtmlDocument.Load(url)

    [{ Category="Achievement"; Author="Adam Ant"; QuoteText="Achievement results from work realizing ambition"}]


//let private pageHtml = 
//    HtmlDocument.Load(quoteUrl).Descendants("h2") |> Seq.head



