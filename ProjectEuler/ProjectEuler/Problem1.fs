module Problem1

open Primes

let sumOfMultiples n = naturalNumbers
                       |> Seq.filter    (fun i -> (i % 3 = 0) || (i % 5 = 0))
                       |> Seq.takeWhile (fun i -> i < n)
                       |> Seq.sum

let solution = sumOfMultiples 1000