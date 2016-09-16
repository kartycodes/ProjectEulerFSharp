module Problem14

let numberWithLongestCollatzSequence m = 
    let mutable counts : Map<int64,int64> = Map.empty

    let rec buildChain j = match j with
        | n when n = 1L -> counts <- counts.Add(1L,1L); 1L
        | n ->
            match counts.TryFind n with
            | Some(x) -> x
            | None -> 
                let next = if n%2L = 0L then n/2L else 3L*n+1L 
                let l = buildChain (next) + 1L
                counts <- counts.Add(n,l)
                l

    for i in 1 .. m do
        buildChain (int64 i) |> ignore

    let (index,length) = counts 
                        |> Map.toList 
                        |> List.maxBy (fun (k,v) -> v)
    index
        

    
        

let solution = numberWithLongestCollatzSequence 1000000
