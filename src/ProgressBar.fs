namespace Fable.Polaris

[<AutoOpen>]
module ProgressBar =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<RequireQualifiedAccess>] ProgressBarProps =
        | Progress of float
        | Size of Polaris.ProgressBarSize

    let inline polarisProgressBar (props : ProgressBarProps list) : ReactElement =
        ofImport "ProgressBar" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) []

