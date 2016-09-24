module Problem19

let daysPerMonth = [|31;28;31;30;31;30;31;31;30;31;30;31|]

let numberOfDaysInFebruary year =
    if year % 400 = 0 then 29
    elif year % 100 = 0 then 28
    elif year % 4 = 0 then 29
    else 28

let monthSequence endYear= seq {
    for i in 1900 .. endYear do
        for j in 0 .. 11 do
            if j = 1 then
                yield numberOfDaysInFebruary i
            else 
                yield daysPerMonth.[j]
    } 

let sundaysOnFirstOfMonth endYear = 
    let (count,sum) = monthSequence endYear
                      |> Seq.fold (fun (c,s) i -> 
                        if (s+i+1)%7 = 0 then (c+1,s+i) 
                        else (c,s+i)) (0,0)
    count

    

let solution = (sundaysOnFirstOfMonth 2000)-(sundaysOnFirstOfMonth 1900)
