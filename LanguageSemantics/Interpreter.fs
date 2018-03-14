module Interpreter

module Eval =

    type eval_result =
        | Success of Value.value
        | RuntimeError

    let bind f x =
        match x with
        | Success v -> f v
        | RuntimeError -> RuntimeError
        
    let bind2 f x y =
        match x, y with
        | Success v1, Success v2 -> f v1 v2
        | _ -> RuntimeError

    let bind2Integer f x y =
        match x, y with
        | Success (Value.Integer n1), Success (Value.Integer n2) -> f n1 n2
        | _ -> RuntimeError

    let returnInteger n = Success(Value.Integer n)

open AST


let operationOfOperator operator =
    match operator with
    | Plus -> fun x y -> Eval.returnInteger (x + y)
    | Minus -> fun x y -> Eval.returnInteger (x - y)
    | Multiply -> fun x y -> Eval.returnInteger (x * y)
    | Divide -> fun x y -> if y = 0 then Eval.RuntimeError else Eval.Success(Value.Integer (x / y))
    |> Eval.bind2Integer

let rec eval expression =
    match expression with
    | IntegerLiteral n -> Eval.returnInteger n
    | BinaryExpression(leftExpression, operator, rightExpression) ->
        let leftValue = eval leftExpression
        let rightValue = eval rightExpression
        let operation = operationOfOperator operator
        operation leftValue rightValue
