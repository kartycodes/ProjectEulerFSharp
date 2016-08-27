module Problem12

open Primes

let numDivisors n:int64  = 
    primeFactorsAsMap (int64 n)
    |> Map.fold (fun acc key value -> acc * (int64 (value + 1))) 1L

let triangleNumbers = naturalNumbers 
                      |> Seq.map (int64 >> (fun n -> n * (n + 1L) / 2L))

let firstTriangleNumberWithNDivisors x = 
    triangleNumbers
    |> Seq.filter (fun n -> (numDivisors n) >= x)
    |> Seq.head

let solution = firstTriangleNumberWithNDivisors 49L

