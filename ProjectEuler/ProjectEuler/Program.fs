// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Problem23
open System.Diagnostics

[<EntryPoint>]
let main argv = 
    let watch = Stopwatch.StartNew()
    printfn "Calculating Solution"
    let answer = solution
    watch.Stop()
    printfn "The answer is: %A" answer
    printfn "Found the answer in %A milliseconds" watch.ElapsedMilliseconds


    0 // return an integer exit code
