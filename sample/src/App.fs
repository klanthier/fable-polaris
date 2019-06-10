module App

open Elmish
open Elmish.React
open Fable.Core.JsInterop
importAll "@shopify/polaris/styles.css"

Browser.Dom.window?polaris_navigation_loaded
  <-
    fun _ ->
        Program.mkSimple Navigation.init Navigation.update Navigation.view
                |> Program.withReactBatched "fable-polaris-navigation"
                |> Program.withConsoleTrace
                |> Program.run

Browser.Dom.window?polaris_avatar_loaded
  <-
    fun _ ->
        Program.mkSimple Avatar.init Avatar.update Avatar.view
                |> Program.withReactBatched "fable-polaris-avatar"
                |> Program.withConsoleTrace
                |> Program.run

Browser.Dom.window?polaris_accountConnection_loaded
  <-
    fun _ ->
        Program.mkSimple AccountConnection.init AccountConnection.update AccountConnection.view
                |> Program.withReactBatched "fable-polaris-accountConnection"
                |> Program.withConsoleTrace
                |> Program.run
