module AST

type operator =
    | Plus
    | Minus
    | Multiply
    | Divide
    | Equals
    | NotEquals
    | GreaterThan
    | GreaterThanOrEquals
    | LessThan
    | LessThanOrEquals

type expression =
    | IntegerLiteral of int
    | BinaryExpression of expression * operator * expression
    | Function of string * expression
    | Identifier of string
    | FunctionCall of expression * expression
    | IfExpr of expression * expression * expression