module Tests

open System
open Xunit

type StatementInfo =
    { statement: string
      argument: int
      executedOnTurn: int }

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
              executedOnTurn = 0 })
    |> Seq.cache
    |> List.ofSeq

let rec execute (statements: StatementInfo list) (result: ExecutionResult) =
    let info = statements.[result.index]
    let isDone = info.executedOnTurn <> 0

    if isDone then
        let summary =
            { result with
                  executedStatements = statements }

        summary
    else
        let newStatements =
            statements
            |> Seq.mapi (fun i v -> if i = result.index then { v with executedOnTurn = result.order + 1 } else v)
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
let ``Part 1`` () =
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

let updateStatements (statements: StatementInfo list) order index =
    statements
    |> Seq.mapi (fun i v -> if i = index then { v with executedOnTurn = order + 1 } else v)
    |> List.ofSeq









type ExecutionResult2 =
    { Accumulator: int
      ExecutedStatements: StatementInfo list
      Order: int
      Index: int
      SwitchedIndex: int
      FailedIndices: int list }

let getNextIndex (statements: StatementInfo list) (index: int) =
    match index with
    | index when index = (statements.Length - 1) -> index - 1
    | index -> index + 1

let getJumpInstructions info result shouldSwitch =
    ({ result with
           ExecutedStatements = []
           Order = result.Order + 1
           Index = result.Index + info.argument
           SwitchedIndex = if shouldSwitch then result.Index else result.SwitchedIndex })

let getNopInstructions result shouldSwitch statements =
    ({ result with
           Order = result.Order + 1
           Index = getNextIndex statements result.Index
           SwitchedIndex = if shouldSwitch then result.Index else result.SwitchedIndex })


let rec executePart2 (statements: StatementInfo list) (result: ExecutionResult2) =
    let currentStatement =
        if result.Index < statements.Length then statements.[result.Index] else statements.[statements.Length - 1]

    let isDone = currentStatement.executedOnTurn <> 0

    let isAtFinalInstruction =
        statements.[statements.Length - 1].executedOnTurn <> 0

    if isDone then
        if not isAtFinalInstruction then
            let resetStatements =
                List.map (fun s -> ({ s with executedOnTurn = 0 }: StatementInfo)) statements

            executePart2
                resetStatements
                { result with
                      Accumulator = 0
                      FailedIndices = result.FailedIndices @ [ result.SwitchedIndex ]
                      Index = 0
                      SwitchedIndex = -1
                      Order = 0 }
        else
            let summary =
                { result with
                      ExecutedStatements = statements }

            summary
    else
        let newStatements =
            updateStatements statements result.Order result.Index

        executePart2
            newStatements
            (match currentStatement with
             | info when info.statement = "nop"
                         && not <| Seq.contains result.Index result.FailedIndices
                         && result.SwitchedIndex = -1 -> getJumpInstructions info result true
             | info when info.statement = "jmp"
                         && not <| Seq.contains result.Index result.FailedIndices
                         && result.SwitchedIndex = -1 -> getNopInstructions result true newStatements
             | info when info.statement = "acc" ->
                 { result with
                       Accumulator = result.Accumulator + info.argument
                       Order = result.Order + 1
                       Index = getNextIndex newStatements result.Index }
             | info when info.statement = "jmp" -> getJumpInstructions info result false
             | info when info.statement = "nop" -> getNopInstructions result false newStatements

             | _ -> failwith "should not be possible")

[<Fact>]
let ``Part 2`` () =
    let input = Data.input

    let statements = parseExecutions input

    let result =
        executePart2
            statements
            { Accumulator = 0
              Order = 0
              Index = 0
              SwitchedIndex = -1
              FailedIndices = []
              ExecutedStatements = [] }

    Assert.Equal(1703, result.Accumulator)
