namespace Fable.Polaris

[<AutoOpen>]
module SkeletonThumbnail =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<RequireQualifiedAccess>] SkeletonThumbnailProps =
        | Size of Polaris.ThumbnailSize

    let inline polarisSkeletonThumbnail (props : SkeletonThumbnailProps list) : ReactElement =
        ofImport "SkeletonThumbnail" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []