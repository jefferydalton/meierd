module parseQuotes

open FSharp.Data
open System
open System.IO

let quoteUrl = @"http://sourcesofinsight.com/inspirational-quotes/"

let url = "http://sourcesofinsight.com/inspirational-quotes/"
let pageHtml = 
    HtmlDocument.Load(url).Descendents("h2") |> Seq.head

