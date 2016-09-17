module Problem15

let right = (-1, 0)
let down = ( 0,-1)

let makeMove m p =
    let (dX, dY) = m
    let (pX, pY) = p
    (pX + dX, pY + dY)

let moveRight p = makeMove right p
let moveDown p = makeMove down p

let countMovesToOrigin p = 
    let l,w = p
    let moves = Array2D.zeroCreate<int64> (l+1) (w+1)

    let rec countAndCachePath r = 
        let p1x,p1y = r
        if moves.[p1x,p1y] = 0L then
            let count = movesToOrigin r
            moves.[p1x,p1y] <- count
            count
        else
            moves.[p1x,p1y]
        
    and movesToOrigin q = 
        match q with
        | (_,0) -> 1L
        | (0,_) -> 1L
        | pos   -> countAndCachePath (moveRight pos) + countAndCachePath (moveDown pos)
            
    movesToOrigin (l,w)

let solution = countMovesToOrigin (20,20)

     



