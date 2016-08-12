module Problem4
open System
//Largest palindrome product
//Problem 4
//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
//Find the largest palindrome made from the product of two 3-digit numbers.

let reverse (str: string) = 
    let reversedChars =  str.ToCharArray()
                         |> Array.rev
    new String(reversedChars)

let isPalindrome x = 
    let strx = x.ToString()
    let numToCompare = strx.Length / 2
    let firstHalf = strx.Substring(0,numToCompare)
    let secondHalfIndex = if (strx.Length % 2 = 0) then strx.Length / 2
                          else strx.Length / 2 + 1
    let secondHalf = strx.Substring(secondHalfIndex)

    secondHalf = reverse(firstHalf)

let isDivisibleByTwoThreeDigitNumbers N = 
    let threeDigitDivisors = [100 .. 999]
                             |> List.filter (fun i -> N % i = 0)
                             |> List.map    (fun i -> N / i)
                             |> List.filter (fun i -> 100 <= i && i <= 999 )
                
    match threeDigitDivisors with
    | x :: tail -> true
    | _ -> false
                       
let findLargestPalindrome max min = 
    {max .. -1 .. min}
    |> Seq.filter isPalindrome 
    |> Seq.filter isDivisibleByTwoThreeDigitNumbers
    |> Seq.head

let solution = findLargestPalindrome (999*999) (100*100)
