namespace Fable.Polaris

module TextContainer =


  open Fable.React
  open Fable.Core
  open Fable.Core.JsInterop

  type [<StringEnum>] [<RequireQualifiedAccess>] TextSpacing =
      | [<CompiledName "loose">] Loose
      | [<CompiledName "tight">] Tight

  type TextContainerProps =
    | Spacing of TextSpacing

  let inline polarisTextContainer (props : TextContainerProps list) (elems : ReactElement list) : ReactElement =
      ofImport "TextContainer" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems