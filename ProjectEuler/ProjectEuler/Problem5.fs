module Problem5

//Smallest multiple
//Problem 5
//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

//What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

// To solve this problem, we will generate a list of prime factors that result in the minimum product.
// the basis of the algorithm is to first include all prime factors less than N (for this problem, 20). 
// We will gradually add "instances" of each prime factor until we verify that 
// all composite numbers to N can be made from combinations of prime factors in the list
// At the end, we will multiply the numbers to produce the answer

open Primes

let mergeFactors (primeFactors: Map<int, int>) (factorsToMerge: int list) =
    let factorMap = 
        factorsToMerge
        |> List.fold (fun (state:Map<int,int>) i -> 
                        if (state.ContainsKey i) then 
                            let count = state.[i]
                            state.Add(i, (count+1))
                        else state.Add(i,1)) Map.empty
    factorMap
    |> Map.fold (fun (state:Map<int,int>) key value -> 
                    if state.[key] < value then state.Add(key,value)
                    else state) primeFactors
                    
let smallestNumberDivisibleByAllNumbersTo n = 
    let primesLessThanN = 
        primes
        |> Seq.takeWhile (fun i-> i <= n)
        |> Seq.toList

    let mutable primeFactors = 
        primesLessThanN
        |> List.map      (fun i -> (i,1))
        |> Map.ofList
    
    let allNumbersToLimit =
        naturalNumbers
        |> Seq.takeWhile (fun i -> i <= n)
        |> Set.ofSeq
    
    let compositeNumbersToFactorize = 
        primesLessThanN
        |> Set.ofList
        |> Set.difference allNumbersToLimit
        |> Set.toList
    
    compositeNumbersToFactorize
    |> List.iter (fun i -> primeFactors <- mergeFactors primeFactors (primeFactorsOf i))

    primeFactors
    |> Map.fold (fun (state: int64) key value -> state * (pown (int64 key) value)) 1L
    
let solution = smallestNumberDivisibleByAllNumbersTo 20