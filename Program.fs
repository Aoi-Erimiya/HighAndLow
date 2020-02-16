open System

type Card(number:int) =
    let cardNumber = number
    member x.Number with get() = cardNumber
    override x.ToString() = sprintf "%d" cardNumber

let buildCardList = [
    for i in 1..13 do
        yield Card(i)
  ]

let selectCard (cards:Card list) =
    cards |> List.item (Random().Next(0, cards.Length))
    
let duel (playerCard:Card) (enemyCard:Card) =
    playerCard.Number > enemyCard.Number

let main =
    printfn "*** High & Low ***"

    let cards = buildCardList
    let playerCard = cards |> selectCard
    let enemyCard = cards |> selectCard
    
    printfn "your cards is %A" playerCard 

    printf "High(H) or Low(L)? -> "
    let isExpectHigh = 
        match Console.ReadLine() with
        | "High" | "high" | "H" | "h" -> true
        | "Low" | "low" | "L" | "l" -> false
        | _ -> failwithf "Please input High or Low!"

    let result = duel playerCard enemyCard
    printfn "player:%A vs enemy:%A" playerCard enemyCard
    if result = isExpectHigh then
        printfn "jackpot!"
    else
        printfn "lose..."

main