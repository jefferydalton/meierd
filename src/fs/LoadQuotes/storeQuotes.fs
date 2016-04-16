module MeiredQuotes.Load.storeQuotes

open System
open Microsoft.Azure.Documents
open Microsoft.Azure.Documents.Client
open Microsoft.Azure.Documents.Linq
open Newtonsoft.Json
open FSharp.Configuration


type Settings = AppSettings<"app.config">


let storeDocument() = 
    let client = new DocumentClient(new Uri(Settings.MeiredDbUri.AbsoluteUri), Settings.MeriedDbKey)
    true



