namespace Fable.Polaris

module SkeletonDisplayText =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type SkeletonDisplayTextProps =
        | Size of Polaris.DisplayTextSize

    let inline skeletonDisplayText (props : SkeletonDisplayTextProps list) : ReactElement =
        ofImport "SkeletonDisplayText" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []
