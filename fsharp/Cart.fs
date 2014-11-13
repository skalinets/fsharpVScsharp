module Cart

type Item = {Name: string; Price: double}
type Cart = {Items: Item list}

let milk = {Name = "milk"; Price = 15.0}

let createEmpty () =
    {Items = []}

let add i a c = 
    let is = List.replicate a i
    { c with Items = is @ c.Items }

let getTotal c = 
    c.Items 
        |> List.map (fun i -> i.Price)
        |> List.fold (+) 0.0