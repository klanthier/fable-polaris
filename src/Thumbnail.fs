namespace Fable.Polaris

module Thumbnail =

  open Fable.React
  open Fable.Core
  open Fable.Polaris
  open Fable.Core.JsInterop

  type ThumbnailProps =
    | Alt of string
    | Size of Polaris.ThumbnailSize
    | Source of string

  let inline polarisThumbnail (props : ThumbnailProps list): ReactElement =
      ofImport "Thumbnail" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []