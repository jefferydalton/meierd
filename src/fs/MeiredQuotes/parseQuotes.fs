module MeiredQuotes.Extract.parseQuotes

open FSharp.Data
open System
open System.IO


type Quote = {Category:string; Author:string; QuoteText:string;}
let getQuotes(url:string) =
    [{ Category="Achievement"; Author="Adam Ant"; QuoteText="Achievement results from work realizing ambition"}]


//let private pageHtml = 
//    HtmlDocument.Load(quoteUrl).Descendants("h2") |> Seq.head



