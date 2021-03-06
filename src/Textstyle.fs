namespace Fable.Polaris

[<AutoOpen>]
module TextStyle =

  open Fable.React
  open Fable.Core

  type [<StringEnum>] [<RequireQualifiedAccess>] Variation =
      | [<CompiledName "positive">] Positive
      | [<CompiledName "negative">] Negative
      | [<CompiledName "strong">] Strong
      | [<CompiledName "subdued">] Subdued
      | [<CompiledName "code">] Code

  type [<RequireQualifiedAccess>] RequiredTextStyleProps = {
    variation: Variation
  }

  let inline polarisTextStyle (props : RequiredTextStyleProps) (elems : ReactElement list) : ReactElement =
      ofImport "TextStyle" "@shopify/polaris" props elems