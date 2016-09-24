module Problem21

let properDivisorsOf n = seq {
     for i in 1 .. (int (sqrt (double n))) do
        if n % i = 0 then
          yield i
          if i <> 1 then
            yield n / i 
    } 

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
        | 1 -> sum
        | n -> 
            match amicablePairFor n with
            | Some(a) -> amicablePairs (x-1) (a+sum)
            | None    -> amicablePairs (x-1) sum
    amicablePairs n 0

let solution = sumOfAmicablePairs 10000



    

