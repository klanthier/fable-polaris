module Polaris.DisplayText

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type [<StringEnum>] [<RequireQualifiedAccess>] Variation =
    | [<CompiledName "positive">] Positive
    | [<CompiledName "negative">] Negative
    | [<CompiledName "strong">] Strong
    | [<CompiledName "subdued">] Subdued
    | [<CompiledName "code">] Code

type DisplayTextProps =
    | Element of ElementNameSelection
    | Size of DisplayTextSize

let inline polarisDisplayText (props : DisplayTextProps list) (elems : ReactElement list) : ReactElement =
    ofImport "TextStyle" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems