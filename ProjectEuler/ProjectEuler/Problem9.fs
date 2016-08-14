module Problem9

//A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

//a^2 + b^2 = c^2

//There exists exactly one Pythagorean triplet for which a + b + c = 1000.
//Find the product abc.

// returns a sequence of all triplets whose sum = n
let triplets n = 
    seq  {
        for c in n     .. -1 .. 1 do
            for b in (c-1) .. -1 .. 1 do
                for a in (b-1) .. -1 .. 1 do
                    if (a+b+c = n) && (a*a + b*b =  c*c) then yield (a,b,c)
    }

let solution = 
    let (a,b,c) = triplets 1000
                  |> Seq.head
    a * b * c
    