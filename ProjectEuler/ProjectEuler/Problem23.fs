module Problem23

open Primes
open Utils
open Utils.Divisors

let abundantNumbers = 
    naturalNumbers 
    |> Seq.filter isAbundant
    |> Seq.takeWhile (fun i -> i <= 28123L)
    |> List.ofSeq
    
let numbersWrittenAsSumOfTwoAbundants = 
    let array = Array.zeroCreate 28124
    for i in abundantNumbers do
        for j in abundantNumbers do
            let idx = i+j
            if idx < 28124L then
                array.[(int idx)] <- idx
    array

let (solution,_) = 
    numbersWrittenAsSumOfTwoAbundants
    |> Seq.foldi (fun acc i el -> acc + (if el = 0L then i else 0)) 0
