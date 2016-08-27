module Primes

let naturalNumbers = 
    let rec numberGen n = seq { yield n; yield! numberGen (n+1L) }
    numberGen 1L

let oddNumbers = 
    let rec oddNumberGen n = seq { yield n; yield! oddNumberGen (n + 2L) }
    oddNumberGen 1L

let isPrime n = 
    if n = 1L then false
    elif n = 2L then true
    else 
        let maxFactor = int64 (ceil (sqrt (float n)))
        let rec hasFactor i = 
            match i with
            | y when y = maxFactor -> (n % y) <> 0L
            | y when (n % y)  = 0L  -> false
            | y when (n % y) <> 0L  -> hasFactor (i + 1L)

        hasFactor 2L

//let primes = 
//    let primesGreaterThan2 =
//        oddNumbers
//        |> Seq.filter isPrime
//    Seq.append [2L] primesGreaterThan2
//    |> Seq.cache

let fastPrimes = 
    let a = ResizeArray[2L]
    let grow() = 
        let p0 = a.[a.Count-1] + 1L
        let b  = Array.create (int p0) true
        for di in a do
            let rec loop i = 
                if i < b.Length then 
                    b.[i] <- false
                    loop(i+(int di))
            let i0 = p0 / di * di
            loop(if i0<p0 then (int(i0+di-p0)) else (int(i0-p0)))
        for i=0 to b.Length-1 do
            if b.[i] then a.Add((p0+(int64 i)))
    fun n ->
        while n >= a.Count do
            grow()
        a.[n]

let primes = naturalNumbers 
             |> Seq.map ((fun i -> i-1L) >> int >> fastPrimes)

let slowPrimes n = primes |> Seq.skip n |> Seq.head

// precalculate the first million prime numbers
let calculatedPrimes = primes |> Seq.take 1000000 |> Seq.toList

let longPrimeFactorsOf (n : int64) = 
    let possiblePrimeFactors = calculatedPrimes |> Seq.takeWhile (fun i -> i <= n/2L)
    let mutable remainder = n
    let mutable factors = []

    possiblePrimeFactors
    |> Seq.iter (fun f -> while (remainder % (int64 f)) = 0L do 
                            remainder <- (remainder / (int64 f)) 
                            factors <- f :: factors)
    factors

let primeFactorsOf n = longPrimeFactorsOf (int64 n) |> Seq.map int

let primeFactorsAsMap n = 
    longPrimeFactorsOf n
    |> List.fold (fun (state: Map<int64,int>) i ->
                        if (state.ContainsKey i) then 
                            let count = state.[i]
                            state.Add(i, (count + 1))
                        else state.Add(i,1)) Map.empty