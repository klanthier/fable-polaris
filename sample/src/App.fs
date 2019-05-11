module App

open Elmish
open Elmish.React
open Fable.React
open Fable.Core.JsInterop

open Polaris
open Polaris.AppProvider

// importAll "@shopify/polaris/styles.css"

type Model = int

type Msg =
| Increment
| Decrement

let appProviderProps = {
  theme = Some {
    logo = None
    colors = None
  }
  linkComponent = None
}

let init() : Model = 0

let update (msg:Msg) (model:Model) =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

let view (model:Model) dispatch =

    appProvider appProviderProps [
      div []
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