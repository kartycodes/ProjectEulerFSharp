module Problem1

open Primes

let sumOfMultiples n = naturalNumbers
                       |> Seq.filter    (fun i -> (i % 3L = 0L) || (i % 5L = 0L))
                       |> Seq.takeWhile (fun i -> i < n)
                       |> Seq.sum

let solution = sumOfMultiples 1000L