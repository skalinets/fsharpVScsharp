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
    createEmpty () |> add milk 4 
        |> getTotal |> should equal 60.0

[<Test>]
let ``3rd milk should be free`` () =
    createEmpty () |> add milk 3 |> applyDiscount thirdMilkIsFree
        |> getTotal |> should equal 30.0

[<Test>]
let ``2 milks shoud be free if there 6 in the cart`` () =
    createEmpty () |> add milk 6 |> applyDiscount thirdMilkIsFree
        |> getTotal |> should equal (milk.Price * 4.0)