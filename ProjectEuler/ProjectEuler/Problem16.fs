module Problem16

// doubles an integer, when integer is represented as a list of its digits.
let rec double (digits: int list) (carry :int) =
    match digits with
    | x :: tail -> 
        let sum = x * 2 + carry
        let ones = sum % 10
        let c = if sum > 9 then 1 else 0
        ones :: double tail c
    | [] -> if carry = 1 then [carry] else []
    


// returns the sum of the digits (base 10) of the number 2 ^ n
let sumOfDigits n = 
    let mutable digits = [1]
    for j in 1 .. n do
        digits <- double digits 0
            
    List.sum digits

// alternate solution using bigint and loops
let sumBigint n = 
    let mutable x = bigint.Pow((bigint 2),n)
    let mutable sum = 0
    while (x > (bigint 0)) do
        sum <- (int)(x % (bigint 10)) + sum
        x <- x / (bigint 10)
    sum

// functional programming approach with bigint
let sumBigIntRec n = 
    let rec calcSum (b: bigint) (sum: int) =
        match b with
        | x when x = (bigint 0) -> sum
        | x -> calcSum (x / (bigint 10)) ((int)(x % bigint 10) + sum)
    calcSum (bigint.Pow((bigint 2), n)) 0 
    
    
        
let solution = sumOfDigits 1000