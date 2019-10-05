namespace Fable.Polaris

module SkeletonBodyText =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type SkeletonBodyTextProps =
        | Lines of int

    let inline polarisSkeletonBodyText (props : SkeletonBodyTextProps list) : ReactElement =
        ofImport "SkeletonBodyText" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []
