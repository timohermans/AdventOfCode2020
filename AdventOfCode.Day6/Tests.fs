module Tests

open Data
open System
open Xunit

let splitIntoGroupsFor (group: string) = group.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
let removeNewlinesFrom (group: string) = group.Replace("\r\n", "")
let countUniqueAnswersInGroup group = 
    group 
    |> Seq.filter (fun c -> Char.IsLetter(c))
    |> Seq.distinct 
    |> Seq.length

let countUnanymousVotes (group: string) =
    group.Split("\r\n")
    |> Seq.map (fun v -> v.ToCharArray())
    |> Seq.map Set.ofSeq
    |> Set.intersectMany
    |> Set.count


[<Fact>]
let ``Part1`` () =
    let answers = Data.input
    let nrOfAnswers = 
        splitIntoGroupsFor answers 
        |> Seq.map removeNewlinesFrom 
        |> Seq.map countUniqueAnswersInGroup 
        |> Seq.sum
    
    Assert.Equal(6297, nrOfAnswers)

[<Fact>]
let ``Part2`` () =
    let answers = Data.input
    let nrOfAnswers = 
        splitIntoGroupsFor answers 
        |> Seq.map countUnanymousVotes
        |> Seq.sum

    Assert.Equal(3158, nrOfAnswers)

