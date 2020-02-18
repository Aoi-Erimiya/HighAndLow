open System

type Card(number:int) =
    let cardNumber = number
    member x.Number with get() = cardNumber
    override x.ToString() = sprintf "%d" cardNumber

type Select = High | Low

let buildCard = seq{
        for i in 1..13 do
            yield Card(i)
    }

let selectCard (cards:Card seq) =
    cards |> Seq.item (Random().Next(0, (Seq.length cards)))

let duel (playerCard:Card) (enemyCard:Card) =
    if playerCard.Number > enemyCard.Number then High else Low

let main =
    printfn "*** High & Low ***"

    let cards = buildCard
    let playerCard = cards |> selectCard
    let enemyCard = cards |> selectCard
    
    printfn "your cards is %A" playerCard 
    printf "High(H) or Low(L)? -> "
    let selected = 
        match Console.ReadLine() with
        | "High" | "high" | "H" | "h" -> High
        | "Low" | "low" | "L" | "l" -> Low
        | _ -> invalidArg "selected" "Please input High or Low!"

    let result = duel playerCard enemyCard
    printfn "player:%A vs enemy:%A" playerCard enemyCard
    if result = selected then
        printfn "jackpot!"
    else
        printfn "lose..."

main
