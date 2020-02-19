open System

type Card(number:int) =
    let cardNumber = number
    member x.Number with get() = cardNumber
    override x.ToString() = sprintf "%d" cardNumber

type Select = High | Low

let buildCards = [| for i in 1..13 do yield Card(i) |]

let selectCard (cards:Card array) =
    cards |> Array.item (Random().Next(0, (Array.length cards)))

let duel (playerCard:Card) (enemyCard:Card) =
    if playerCard.Number > enemyCard.Number then High else Low

let main =
    printfn "*** High & Low ***"

    let cards = buildCards
    let playerCard = cards |> selectCard
    let enemyCard = cards |> selectCard
    
    printfn "your cards is %A" playerCard 

    printf "High(H) or Low(L)? -> "
    let selected = 
        match Console.ReadLine().ToLower() with
        | "high" | "h" -> High
        | "low" | "l" -> Low
        | _ -> invalidArg "selected" "Please input High or Low!"

    printfn "player:%A vs enemy:%A" playerCard enemyCard

    if (duel playerCard enemyCard) = selected then
        printfn "jackpot!"
    else
        printfn "lose..."

main
