module App

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props

open Polaris.Avatar
open Polaris.AppProvider

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
    let props = {
        accessibilityLabel = None
        customer = Some true
        initials = None
        name = Some "ABCD"
        size = None
        source = None
    }

    appProvider appProviderProps [
      div []
        [ 
          avatar props
          button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
          div [] [ str (string model) ]
          button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ] ]
    ]

// App
Program.mkSimple init update view
|> Program.withReactBatched "fable-polaris-app"
|> Program.withConsoleTrace
|> Program.run