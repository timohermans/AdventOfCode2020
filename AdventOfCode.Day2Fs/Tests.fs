module Tests

open System
open System.Text.RegularExpressions
open Xunit

type PasswordInfo =
    { min: int
      max: int
      letter: char
      password: string }

let extractPasswordInfoFrom input =
    Regex.Match(input, "(\d+)-(\d+) ([a-z]): ([a-z]*)").Groups.Values
    |> Seq.map (fun g -> g.Value)
    |> List.ofSeq
    |> function
    | _ :: min :: max :: letter :: password ->
        { min = min |> int
          max = max |> int
          letter = letter |> char
          password = password |> string }
    | _ -> failwith "Regex doesn't work (anymore?)"

[<Fact>]
let Part1 () =
    let input = Data.input

    let isValidPassword password =
        extractPasswordInfoFrom password
        |> fun info ->
            info.password.ToCharArray()
            |> Seq.filter (fun l -> l = info.letter)
            |> Seq.length
            |> fun length -> length >= info.min && length <= info.max

    let nrOfValidPasswords =
        input.Split("\r\n")
        |> Seq.filter isValidPassword
        |> Seq.length

    Assert.Equal(477, nrOfValidPasswords)

[<Fact>]
let Part2 () =
    let input = Data.input

    let isValidPassword infoString =
       extractPasswordInfoFrom infoString
       |> fun info ->
           info.password.ToCharArray()
           |> fun letters -> [(letters |> Seq.item info.min); (letters |> Seq.item info.max)]
           |> Seq.filter (fun l -> l = info.letter)
           |> Seq.length = 1

    let nrOfValidPasswords =
        input.Split("\r\n")
        |> Seq.filter isValidPassword
        |> Seq.length

    Assert.Equal(686, nrOfValidPasswords)
