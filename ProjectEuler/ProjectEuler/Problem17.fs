module Problem17

let wordCounts = 
    [190, ["one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine"];
     100, ["twenty"; "thirty"; "forty"; "fifty"; "sixty"; "seventy"; "eighty"; "nintey"];
      10, ["ten"; "eleven"; "twelve"; "thirteen"; "fourteen"; "fifteen"; "sixteen";"seventeen"; "eighteen"; "nineteen"];
     900, ["hundred"];
     891, ["and"];
       1, ["one"; "thousand"]]
    |> Map.ofList



let solution =
    wordCounts
    |> Map.fold (fun acc k v -> acc + (List.fold (fun a (s:string) -> a + s.Length) 0 v)*k) 0

    
     
    
 
