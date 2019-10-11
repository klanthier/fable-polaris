namespace Fable.Polaris

[<AutoOpen>]
module Thumbnail =

  open Fable.React
  open Fable.Core
  open Fable.Polaris
  open Fable.Core.JsInterop

  type [<RequireQualifiedAccess>] RequiredThumbnailProps = {
    Alt: string
    Source: string
  }
  type [<RequireQualifiedAccess>] ThumbnailProps =
    | Size of Polaris.ThumbnailSize

  let inline polarisThumbnail (requiredProps: RequiredThumbnailProps) (props : ThumbnailProps list): ReactElement =
    let combinedProps =
      props
      |> keyValueList CaseRules.LowerFirst
      |> (fun obj ->
          obj?alt <- requiredProps.Alt
          obj?source <- requiredProps.Source
          obj
      )
    ofImport "Thumbnail" "@shopify/polaris" combinedProps []