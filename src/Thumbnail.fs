module Polaris.Thumbnail

open Fable.React
open Fable.Core
open Polaris.Shared
open Fable.Core.JsInterop

type ThumbnailProps =
  | Alt of string
  | Size of ThumbnailSize
  | Source of string

let inline polarisThumbnail (props : ThumbnailProps list): ReactElement =
    ofImport "Thumbnail" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []