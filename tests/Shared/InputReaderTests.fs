module InputReaderTests

open Xunit
open FsCheck
open FsCheck.Xunit
open Shared.InputReader

let TextFile = "TextFile.txt"
let LinesFile = "LinesFile.txt"

let CreateText text = 
    System.IO.File.WriteAllText(TextFile, text)

let CreateLines text = 
    System.IO.File.WriteAllLines(TextFile, text)

[<Property>]
let ``ReadAllText should return the full text`` (text: NonEmptyString) =
    text |> string |> CreateText
    let input = TextFile |> ReadInputText
    input = (text |> string)


[<Property>]
let ``ReadAllLines should return all the lines`` (text: NonEmptyString[]) =
    let expectedLines = text |> Array.map (fun t -> t |> string)
    expectedLines |> CreateLines
    let input = LinesFile |> ReadInputLines
    input = expectedLines
