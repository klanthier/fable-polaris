namespace Fable.Polaris

module Spinner =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React
    open Shared

    type [<RequireQualifiedAccess>] [<StringEnum>] SpinnerSize =
        | [<CompiledName "small">] Small
        | [<CompiledName "large">] Large

    type [<RequireQualifiedAccess>] SpinnerProps =
        | AccessibilityLabel of string
        | Color of ColorOption
        | Size of SpinnerSize

    let inline polairsSpinner (props : SpinnerProps list) : ReactElement =
        ofImport "Spinner" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []