// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open AST
open Interpreter

let expressionOnePlusSeventeen =
    BinaryExpression (IntegerLiteral 1, Plus, IntegerLiteral 17)

let expressionTwoMultipliedBySeventeen =
    BinaryExpression (IntegerLiteral 2, Multiply, IntegerLiteral 17)

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    
    let value = eval expressionOnePlusSeventeen
    let value = eval expressionTwoMultipliedBySeventeen


    0 // return an integer exit code
