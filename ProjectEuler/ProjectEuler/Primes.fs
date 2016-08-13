module Primes

let naturalNumbers = 
    let rec numberGen n = seq { yield n; yield! numberGen (n+1) }
    numberGen 1

let oddNumbers = 
    let rec oddNumberGen n = seq { yield n; yield! oddNumberGen (n+2) }
    oddNumberGen 1

let isPrime n = 
    if n = 1 then false
    elif n = 2 then true
    else 
        let maxFactor = int (ceil (sqrt (float n)))
        let rec hasFactor i = 
            match i with
            | y when y = maxFactor -> (n % y) <> 0
            | y when (n % y)  = 0  -> false
            | y when (n % y) <> 0  -> hasFactor (i+1)

        hasFactor 2

let primes = 
    let primesGreaterThan2 =
        oddNumbers
        |> Seq.filter isPrime
    Seq.append [2] primesGreaterThan2

let primeFactorsOf n = 
    let possiblePrimeFactors = primes |> Seq.takeWhile (fun i -> i <= int (n/2))
    let mutable remainder = n
    let mutable factors = []

    possiblePrimeFactors
    |> Seq.iter (fun f -> while (remainder % f) = 0 do 
                            remainder <- (remainder / f) 
                            factors <- f :: factors)
    factors
