namespace MeiredQuotes.Extract.FS.QuoteExtract

open FSharp.Data

type Quote(category, quoteText, author) =
    member this.Category = author
    member this.QuoteText = quoteText
    member this.Author = author


type Extract() =
    static let rec mapFoldQuotes acc category quotes:HtmlNode list =
        match quotes with 
        | head:HtmlNode :: tail when (head.Name() = "p") ->  
            mapFoldQuotes acc category tail
        | head:HtmlNode :: tail when (head.Name() = "h2") -> 
             mapFoldQuotes acc (head.InnerText()) tail
        | _ :: tail -> mapFoldQuotes acc category tail
        | [] -> acc
    
    static member PullQuotes(siteUrl) =
        if System.String.IsNullOrWhiteSpace siteUrl
        then raise (System.ArgumentException("siteUrl must have a value"))

        let htmlDocument = HtmlDocument.Load(siteUrl)
        
        let play = htmlDocument.Body().Descendants(["h2";"p";]) |> Seq.toList |> mapFoldQuotes [] "" 
       
        List.empty<Quote>
