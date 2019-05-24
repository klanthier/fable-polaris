module Navigation
open Fable.React

open Polaris
open Polaris.AppProvider
open Polaris.Stack

type Model = int

type Msg =
| Increment
| Decrement

let init() : Model = 0

let update (msg:Msg) (model:Model) =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

let view (model:Model) dispatch =

    appProvider [] [
      stack [ StackProps.Vertical true ]
        [ 
          Button.button { OnClick = (fun _ -> dispatch Increment) } [] [ str "+" ]
          div [] [ str (string model) ]
          Button.button { OnClick = (fun _ -> dispatch Decrement) } [] [ str "-" ]
        ]
    ]

