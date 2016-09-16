module Seq

    let takeUntilFirst f s = seq {
        for i in Seq.takeWhile (fun x -> not (f x)) s do
            yield i

        yield Seq.takeWhile (fun x -> f x) s |> Seq.head
    }
        
      
        
        
        

    //take all the elements that meet the condition + the next one.
        

