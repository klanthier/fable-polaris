namespace Fable.Polaris

[<AutoOpen>]
module SkeletonBodyText =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] SkeletonBodyTextProps =
        | Lines of int

    let inline polarisSkeletonBodyText (props : SkeletonBodyTextProps list) : ReactElement =
        ofImport "SkeletonBodyText" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []
