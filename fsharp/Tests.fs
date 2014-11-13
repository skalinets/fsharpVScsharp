module fsharp.Tests

open NUnit.Framework
open FsUnit
open Cart

[<Test>]
let ``object equality`` () = 
    milk |> should equal {Name = "Milk"; Price = 15.0}
    
[<Test>]
let ``should create empty cart`` () = 
    createEmpty().Items |> should be Empty

[<Test>]
let ``should calculate sum or all orders`` () =
    createEmpty () |> addItem milk 4 
        |> getTotal |> should equal 60.0

[<Test>]
let ``3rd milk should be free`` () =
    createEmpty () |> addItem milk 3 |> applyDiscount thirdMilkIsFree
        |> getTotal |> should equal 30.0

[<Test>]
let ``2 milks shoud be free if there 6 in the cart`` () =
    createEmpty () |> addItem milk 6 |> applyDiscount thirdMilkIsFree
        |> getTotal |> should equal (milk.Price * 4.0)