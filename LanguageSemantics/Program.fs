// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open AST
open Interpreter

let expressionOnePlusSeventeen =
    BinaryExpression (IntegerLiteral 1, Plus, IntegerLiteral 17)

let expressionTwoMultipliedBySeventeen =
    BinaryExpression (IntegerLiteral 2, Multiply, IntegerLiteral 17)


(* (fun x -> x + 5) 6 *)
let six = IntegerLiteral 6
let five = IntegerLiteral 5
let x = Identifier "x"
let binaryExpr = BinaryExpression(x, Plus, five)
let f = Function("y", binaryExpr)
let expr = FunctionCall(f, six)


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    
    let value = eval Map.empty expr



    0 // return an integer exit code
