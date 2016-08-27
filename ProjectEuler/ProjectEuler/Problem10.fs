module Problem10

//The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
//
//Find the sum of all the primes below two million.
open Primes

let sumOfPrimesLessThan x =
    primes 
    |> Seq.takeWhile (fun i -> i < x) 
    |> Seq.fold (fun acc i -> acc + (int64 i)) 0L

let solution = sumOfPrimesLessThan 2000000L