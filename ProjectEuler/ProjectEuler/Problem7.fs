module Problem7

open Primes

let solution = primes |> Seq.take 10001 |> Seq.toList |> List.item 10000
    
    
    
    
