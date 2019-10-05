namespace Fable.Polaris

module Thumbnail =

  open Fable.React
  open Fable.Core
  open Fable.Polaris
  open Fable.Core.JsInterop

  type RequiredThumbnailProps = {
    Alt: string
    Source: string
  }
  type ThumbnailProps =
    | Size of Polaris.ThumbnailSize

  let inline polarisThumbnail (requiredProps: RequiredThumbnailProps) (props : ThumbnailProps list): ReactElement =
    let combinedProps =
      props
      |> keyValueList CaseRules.LowerFirst
      |> (fun obj ->
          obj?alt <- requiredProps.Alt
          obj?source <- requiredProps.Source
      )
    ofImport "Thumbnail" "@shopify/polaris" combinedProps []