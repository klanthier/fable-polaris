module App

open Elmish
open Elmish.React
open Fable.React
open Fable.Core.JsInterop

open Polaris
open Polaris.AppProvider
open Polaris.Stack
open Polaris.Navigation
open Polaris.Shared

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

    let nav1 = createEmpty<NavigationSectionItem>
    nav1.url <- "/"
    nav1.label <- "Home"
    nav1.icon <- BundledIcon.Home
    
    let nav2 = createEmpty<NavigationSectionItem>
    nav2.url <- "/some/path"
    nav2.label <- "Somewhere"
    nav2.icon <- BundledIcon.OnlineStore

    appProvider []
        (div
            []
            [
                stack [ StackProps.Vertical true ]
                    [ 
                      Button.button { OnClick = (fun _ -> dispatch Increment) } [] [ str "+" ]
                      div [] [ str (string model) ]
                      Button.button { OnClick = (fun _ -> dispatch Decrement) } [] [ str "-" ]
                    ]
                navigation { Location = "/"}
                    []
                    [
                        navigationSection
                            [
                                [nav1; nav2] |> ResizeArray |> NavigationSectionProps.Items
                            ]
                            []
                    ]
            ])

// App
Program.mkSimple init update view
|> Program.withReactBatched "fable-polaris-app"
|> Program.withConsoleTrace
|> Program.run