module Polaris.ProgressBar

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type ProgressBarProps =
    | Progress of float
    | Size of ProgressBarSize

let inline polarisProgressBar (props : ProgressBarProps list) : ReactElement =
    ofImport "ProgressBar" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) []

