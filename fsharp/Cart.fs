module Cart

type Item = {Name: string; Price: float}
type Cart = {Items: Item list; DiscountCalculators : (Cart -> float) list}

let milk = {Name = "Milk"; Price = 15.0}

let sum = List.fold (+) 0.0

let totalWihoutDiscounts c = 
    let getPrice i = i.Price
    c.Items 
        |> List.map getPrice
        |> sum

let createEmpty () =
    {Items = []; DiscountCalculators = []}

let addItem i a c = 
    let is = List.replicate a i
    { c with Items = is @ c.Items }

let getTotal c = 
    let allDiscounts = c.DiscountCalculators 
                        |> List.map (fun cal -> cal c)
                        |> sum
    totalWihoutDiscounts c - allDiscounts 

let applyDiscount d c = { c with DiscountCalculators = d :: c.DiscountCalculators }

let nthIsFree n i c =
    i.Price * (((c.Items 
                    |> List.filter ((=) i) 
                    |> List.length) / n) |> float)
    
let thirdIsFree = nthIsFree 3

let thirdMilkIsFree = thirdIsFree milk
