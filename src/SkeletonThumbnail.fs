module Polaris.SkeletonThumbnail

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type SkeletonThumbnailProps =
    | Size of ThumbnailSize

let inline polarisSkeletonThumbnail (props : SkeletonThumbnailProps list) : ReactElement =
    ofImport "SkeletonThumbnail" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []