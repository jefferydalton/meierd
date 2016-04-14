
#I @"C:\dev\meierd\meierd\src\fs\quoteExtract\packages\FSharp.Data.2.2.5\lib\net40\"

#r "FSharp.Data"
//
//open FSharp.Data
//
//let quoteUrl = @"http://sourcesofinsight.com/inspirational-quotes/"
//let headerSections = 
//    HtmlDocument.Load(quoteUrl).Descendants("h2") 
//
//
//headerSections |> Seq.length |> printfn "number of items %i"


#load "parseQuotes.fs"
let quoteUrl = @"http://sourcesofinsight.com/inspirational-quotes/"

let items = Miered.parseQuotes.getQuotes(quoteUrl)
