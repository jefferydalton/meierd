module MeiredQuotes.Extract.parseQuotes

open FSharp.Data
open System.Text.RegularExpressions

type Quote = {Category:string; Author:string; QuoteText:string;}

let private getPageHeadersAndParagraphs(url:string) =
    Seq.toList(HtmlDocument.Load(url).Descendants(["h2"; "p"]))

let (|Category|Quote|Author|Other|) (item:HtmlNode) =
    let it = item.InnerText()
    //let quoteAndName = Regex.Match(item.InnerText(), "^(“.+”)\s[–—]\s(.+)")
    let quote = Regex.Match(item.InnerText(), "^(“.+”)")
    let name = Regex.Match(item.InnerText(), "^[–—]\s(.+)")
    if item.Name() = "h2" then
        if item.InnerText() = "You Might Also Like" then
            Category null
        else
            Category (item.InnerText())
    elif quote.Success then
        Quote (quote.Groups.Item(1).Value)
    elif name.Success && item.HasAttribute("align", "right") then
        Author (name.Groups.Item(1).Value)    
//    elif quoteAndName.Success then
//        QuoteAndAuthor (quoteAndName.Groups.Item(0).Value, quoteAndName.Groups.Item(1).Value)
    else Other



let getQuotes(url:string) =
    let rec processItems (quoteAcc:Quote list) category quote (items:HtmlNode list) =
        match items with
        | head::tail ->
            match head with 
            | Category name ->
                processItems quoteAcc name null tail
            | Quote quote ->
                if category = null then
                    //write an exception
                    processItems quoteAcc category null tail
                else
                    processItems quoteAcc category quote tail
            | Author name ->
                if quote = null || category = null then
                    //write an exception
                    processItems quoteAcc category null tail
                else
                    processItems ({ Category=category; Author=name; QuoteText=quote} :: quoteAcc) category null tail
//            | QuoteAndAuthor (quote, name) ->
//                processItems ({ Category=category; Author=name; QuoteText=quote} :: quoteAcc) category null tail
            | Other ->
                processItems quoteAcc category quote tail
        | [] -> quoteAcc
    let x = 
        getPageHeadersAndParagraphs(url) |> processItems [] null null  
      
    [{ Category="Achievement"; Author="Adam Ant"; QuoteText="Achievement results from work realizing ambition"}]