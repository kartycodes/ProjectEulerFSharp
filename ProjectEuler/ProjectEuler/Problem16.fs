module Problem16


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
        
let solution = sumOfDigits 1000