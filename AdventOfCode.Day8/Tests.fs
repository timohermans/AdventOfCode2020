module Tests

open System
open Xunit

type StatementInfo =
    { statement: string
      argument: int
      order: int }

type ExecutionResult =
    { accumulator: int
      executedStatements: StatementInfo list
      order: int
      index: int }

let parseExecutions (inputStrings: string) =
    inputStrings.Split("\r\n")
    |> Seq.map (fun s ->
        s.Split(" ")
        |> fun splits ->
            { statement = splits.[0] |> string
              argument = splits.[1] |> int
              order = 0 })
    |> Seq.cache
    |> List.ofSeq

let rec execute (statements: StatementInfo list) (result: ExecutionResult) =
        let info = statements.[result.index]
        let isDone = info.order <> 0

        if isDone then
            let summary =
                { result with
                      executedStatements = statements }

            summary
        else
            let newStatements =
                statements
                |> Seq.mapi (fun i v ->  if i = result.index then { v with order = result.order + 1 } else v)
                |> List.ofSeq

            execute
                newStatements
                (match info with
                 | info when info.statement = "acc" ->
                     { accumulator = result.accumulator + info.argument
                       executedStatements = []
                       order = result.order + 1
                       index = result.index + 1 }
                 | info when info.statement = "jmp" ->
                     { accumulator = result.accumulator
                       executedStatements = []
                       order = result.order + 1
                       index = result.index + info.argument }
                 | info when info.statement = "nop" ->
                     { accumulator = result.accumulator
                       executedStatements = []
                       order = result.order + 1
                       index = result.index + 1 }
                 | _ -> failwith "should not be possible")

[<Fact>]
let ``Test data`` () =
    let input = Data.input

    let statements = parseExecutions input

    let result =
        execute
            statements
            { accumulator = 0
              order = 0
              index = 0
              executedStatements = [] }

    Assert.Equal(1610, result.accumulator)
        
