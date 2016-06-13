namespace MeiredQuotes.Extract.FS.QuoteExtract

open FSharp.Data
open System.Text.RegularExpressions

type Quote(category, quoteText, author) =
    member this.Category = category
    member this.QuoteText = quoteText
    member this.Author = author


type Extract() =
    static let jdMeirerQuoteRx = new Regex(@"(“.+”)\s(—|–)\s(.+)") 

    static let rec mapFoldQuotes category (quotes:HtmlNode list) =
        match quotes with 
        | head:HtmlNode :: tail 
          when (head.Name() = "h2") -> mapFoldQuotes (head.InnerText()) tail
        | head:HtmlNode :: next:HtmlNode :: tail 
          when (head.Name() = "p" && next.Name() = "p") ->  
               let quoteMatch = jdMeirerQuoteRx.Match((head.InnerText()) + " " + (next.InnerText()))
               if quoteMatch.Success
               then                        
                    new Quote(category, quoteMatch.Groups.[1].Value, quoteMatch.Groups.[3].Value) :: mapFoldQuotes category tail
               else 
                    mapFoldQuotes category (next :: tail)
        | _ :: tail -> 
               mapFoldQuotes category tail
        | [] -> []
    
    static member PullQuotes(siteUrl) =
        if System.String.IsNullOrWhiteSpace siteUrl
        then raise (System.ArgumentException("siteUrl must have a value"))

        let htmlDocument = HtmlDocument.Load(siteUrl)
        
        htmlDocument.Body().Descendants(["h2";"p";]) |> Seq.toList |> mapFoldQuotes "" 