module Problem2

open Fibonacci

let everyNthFibonacci n = 
    seq { use en = fibonacciSequence.GetEnumerator()
          let rec nextN n = 
             if n = 0 then true
             else en.MoveNext() && (nextN (n-1))
          while nextN n do
             yield en.Current
        }


let sumOfEvenFibsLessThanOrEqualTo n = 
    // every 3rd element will be even
    everyNthFibonacci 3
    |> Seq.takeWhile (fun i -> i <= n)
    |> Seq.sum

let solution = sumOfEvenFibsLessThanOrEqualTo 4000000 

