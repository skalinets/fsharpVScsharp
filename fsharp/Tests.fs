module fsharp.Tests

open NUnit.Framework
open FsUnit
open Cart
    
[<Test>]
let ``just simple test`` () = 1 |> should equal 1

[<Test>]
let ``should create empty cart`` () = createEmpty().Items |> should be Empty

[<Test>]
let ``should calculate sum or all orders`` () =
    let cart = createEmpty () |> add milk 2
    let t = getTotal cart
    t |> should equal 30.0