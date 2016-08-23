module Fibonacci

let fibonacciSequence = 
    let rec fibonacciGen n m = seq {
        yield m
        yield! fibonacciGen m (m+n)
    }

    Seq.append [1] (fibonacciGen 1 1)



