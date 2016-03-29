module MeiredQuotes.Extract.parseQuotes

open FSharp.Data

type Quote = {Category:string; Author:string; QuoteText:string;}

let private getPageHeadersAndParagraphs(url:string) =
    Seq.toList(HtmlDocument.Load(url).Descendants(["h2"; "p"]))


let getQuotes(url:string) =
    let rec processCategory (acc:Quote list) (items:HtmlNode list) =
        match items with
        | head::tail ->
            if head.Name() = "h2" then
                processCategory ({ Category=head.InnerText(); Author="Dummy"; QuoteText="Dummy"; } :: acc) tail
            else
                processCategory acc tail 
        | [] -> acc
    let x = 
        getPageHeadersAndParagraphs(url) |> processCategory [] 
  
     
    [{ Category="Achievement"; Author="Adam Ant"; QuoteText="Achievement results from work realizing ambition"}]