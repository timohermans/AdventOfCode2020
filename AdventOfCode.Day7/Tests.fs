module Tests

open System
open System.Collections
open System.Text.RegularExpressions
open Xunit

type BagContent = { name: string; amount: int }

type Bag =
    { name: string
      contents: BagContent list }

let extractRequirements input =
    Regex.Matches(input, "(\d) ([\w|\s]+) bag[s]?")
    |> Seq.map (fun g -> List.ofSeq g.Groups.Values)
    |> Seq.map (fun l ->
        { name = l.[2].Value |> string
          amount = l.[1].Value |> int })
    |> Seq.cache
    |> List.ofSeq

let extractBag bagInput =
    Regex.Match(bagInput, "(\D+) bags contain ([\w|\s]+)").Groups.Values
    |> List.ofSeq
    |> List.map (fun g -> g.Value)
    |> function
    | _ :: bagName :: _ ->
        { name = bagName |> string
          contents = extractRequirements bagInput }
    | _ -> failwith "Incorrect input"

let bagMatches =
    System.Collections.Generic.Dictionary<string, bool>()

let rec canContainBag search allBags (foundBags: Bag list) (bag: Bag) =
    if bag.name = search then
        true
    else

    if bagMatches.ContainsKey(bag.name) then // caching
        bagMatches.[bag.name]
    else
        let notYetSearchedBags =
            bag.contents |> Seq.map (fun br -> br.name)

        let bagsToSearch =
            allBags
            |> Seq.filter (fun b -> Seq.exists (fun br -> br = b.name) notYetSearchedBags)
            |> List.ofSeq

        let isFound =
            bagsToSearch
            |> Seq.exists (fun b -> canContainBag search allBags (foundBags @ [ b ]) b)

        if foundBags.Length = 0
        then bagMatches.TryAdd(bag.name, isFound) |> ignore

        isFound

[<Fact>]
let ``Part 1`` () =
    let bagInput = Data.input
    let search = "shiny gold"

    let bags =
        bagInput.Split("\r\n")
        |> Seq.map (fun s -> extractBag s)
        |> Seq.cache

    let nrOfGoldBagHolders =
        bags
        |> Seq.filter (fun b -> b.name <> search)
        |> Seq.filter (canContainBag search bags [])
        |> Seq.length

    Assert.Equal(337, nrOfGoldBagHolders)

let rec countBags (allBags: Bag list) (bag: Bag) =
    bag.contents
    |> function
    | [] -> 1
    | bags ->
        let nr =
            bags
            |> Seq.map (fun br ->
                (seq { 1 .. br.amount }
                 |> Seq.map (fun _ -> (Seq.find (fun a -> a.name = br.name) allBags))
                 |> Seq.map (countBags allBags)
                 |> Seq.sum))
            |> Seq.sum

        nr + 1

[<Fact>]
let ``Part 2`` () =
    let bagInput = Data.input
    let search = "shiny gold"

    let bags =
        bagInput.Split("\r\n")
        |> Seq.map (fun s -> extractBag s)
        |> List.ofSeq

    let nrOfBags =
        bags
        |> Seq.find (fun b -> b.name = search)
        |> fun bag -> (countBags bags bag)

    Assert.Equal(50100, nrOfBags - 1)
