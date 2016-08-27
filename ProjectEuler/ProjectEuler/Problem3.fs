module Problem3

open Primes

let largestPrimeFactorOf n = List.max (longPrimeFactorsOf n)
                             
let solution = largestPrimeFactorOf 600851475143L
    