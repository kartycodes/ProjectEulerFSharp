namespace Utils

module Seq =
    let takeUntilFirst f s = seq {
        for i in Seq.takeWhile (fun x -> not (f x)) s do
            yield i

        yield Seq.takeWhile (fun x -> f x) s |> Seq.head
    }

module Utils =      
    let sumOfTheDigitsofABigInt n = 
        let rec calcSum (b: bigint) (sum: int) =
            match b with
            | x when x = (bigint 0) -> sum
            | x -> calcSum (x / (bigint 10)) ((int)(x % bigint 10) + sum)
        calcSum n 0   

        
        

    //take all the elements that meet the condition + the next one.
        

