namespace Utils

module Seq =
    let takeUntilFirst f s = seq {
        for i in Seq.takeWhile (fun x -> not (f x)) s do
            yield i

        yield Seq.takeWhile (fun x -> f x) s |> Seq.head
    }

    let crossProduct s1 s2 = seq {
        for i in s1 do
            for j in s2 do
                yield i,j
    }

    let selfCrossProduct s1 = crossProduct s1 s1

    let foldi (folder: 'b->int->'c->'b) (state:'b) (sequence:'c seq) = 
        Seq.fold (fun (state,idx) n -> ((folder state idx n), idx+1)) (state,0) sequence

 module Utils =      
    let sumOfTheDigitsofABigInt n = 
        let rec calcSum (b: bigint) (sum: int) =
            match b with
            | x when x = (bigint 0) -> sum
            | x -> calcSum (x / (bigint 10)) ((int)(x % bigint 10) + sum)
        calcSum n 0   

module Divisors = 
    let properDivisorsOf (n:int64) = seq {
         for i in 1L .. (int64 (sqrt (double n))) do
            if n % i = 0L then
              yield i
              if i <> 1L && (double i) <> (sqrt (double n)) then
                yield n / i 
        }
    
    let isPerfect n = 
        n = Seq.sum (properDivisorsOf n)

    let isAbundant n = 
        n < Seq.sum (properDivisorsOf n)

    let isDeficient n = 
        n > Seq.sum (properDivisorsOf n)
        

    //take all the elements that meet the condition + the next one.
        

