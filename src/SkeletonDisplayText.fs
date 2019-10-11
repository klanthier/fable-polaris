namespace Fable.Polaris

[<AutoOpen>]
module SkeletonDisplayText =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<RequireQualifiedAccess>] SkeletonDisplayTextProps = Size of Polaris.DisplayTextSize

    let inline polarisSkeletonDisplayText (props: SkeletonDisplayTextProps list): ReactElement =
        ofImport "SkeletonDisplayText" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []
