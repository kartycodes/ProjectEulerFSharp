module Problem21

open Utils.Divisors

let amicablePairFor n = 
    let sumOfDivisors = properDivisorsOf n |> Seq.sum
    let sumOfSum = properDivisorsOf sumOfDivisors |> Seq.sum
    if (sumOfSum = n && sumOfDivisors <> n) then
        Some(sumOfDivisors)
    else 
        None

let sumOfAmicablePairs n = 
    let rec amicablePairs x sum =
        match x with
        | 1L -> sum
        | n -> 
            match amicablePairFor n with
            | Some(a) -> amicablePairs (x-1L) (a+sum)
            | None    -> amicablePairs (x-1L) sum
    amicablePairs n 0L

let solution = sumOfAmicablePairs 10000L



    

