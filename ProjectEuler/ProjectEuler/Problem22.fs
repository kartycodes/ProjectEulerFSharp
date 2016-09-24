module Problem22

open System

let lines = IO.File.ReadLines @"C:\code\personal\ProjectEulerFSharp\ProjectEuler\ProjectEuler\content\p022_names.txt"

let nameString = lines |> Seq.head

let names = nameString.Split(',') |> Seq.map (fun (i:string) -> i.Trim('"'))

let score (name:string) = 
    let mutable sum = 0;
    name |> String.iter (fun c -> sum <- sum + (int c)-64)
    sum

let (solution,_) = 
    names 
    |> Seq.sort
    |> Seq.fold (fun (sum,idx) i -> (sum+idx*(score i),idx+1)) (0,1)