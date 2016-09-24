module Problem20

let rec factorial n =
    match n with 
    | x when x = (bigint 1) -> (bigint 1)
    | x  ->  x * (factorial (x-(bigint 1))


