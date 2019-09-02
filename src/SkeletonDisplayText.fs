module Polaris.SkeletonDisplayText

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type SkeletonDisplayTextProps =
    | Size of DisplayTextSize

let inline skeletonDisplayText (props : SkeletonDisplayTextProps list) : ReactElement =
    ofImport "SkeletonDisplayText" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []
