module Navigation
open Fable.React

open Fable.Core.JsInterop
open Polaris.AppProvider
open Polaris.Navigation
open Fable.Polaris


let view _ _ =

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
