module Value

open Microsoft.FSharp.Collections

type value =
    | Integer of int
    | String of string
    | Closure of environment * string * AST.expression

and environment = Map<string, value>
