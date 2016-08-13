module Problem6

//Sum square difference
//Problem 6
//The sum of the squares of the first ten natural numbers is,
//
//1^2 + 2^2 + ... + 10^2 = 385
//The square of the sum of the first ten natural numbers is,
//
//(1 + 2 + ... + 10)^2 = 55^2 = 3025
//Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
//
//Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

open Primes

let squares = naturalNumbers |> Seq.map (fun i -> i*i)

let sumOfSquares n = 
    squares
    |> Seq.take n
    |> Seq.toList
    |> List.fold (fun acc i -> acc + i) 0

let squareOfSum n =
    let sum = naturalNumbers
              |> Seq.take n
              |> Seq.toList
              |> List.fold (fun acc i -> acc + i) 0
    sum * sum

let solution = (squareOfSum 100) - (sumOfSquares 100)


