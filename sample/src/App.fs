module App

open Elmish
open Elmish.React
open Fable.React
open Fable.Core.JsInterop

open Polaris
open Polaris.AppProvider
open Polaris.Stack

importAll "@shopify/polaris/styles.css"

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

// App
Program.mkSimple init update view
|> Program.withReactBatched "fable-polaris-app"
|> Program.withConsoleTrace
|> Program.run