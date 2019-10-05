namespace Fable.Polaris

module Spinner =
    open Fable.Polaris
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    type [<RequireQualifiedAccess>] [<StringEnum>] SpinnerSize =
        | [<CompiledName "small">] Small
        | [<CompiledName "large">] Large

    type [<RequireQualifiedAccess>] SpinnerProps =
        | AccessibilityLabel of string
        | Color of Polaris.ColorOption
        | Size of SpinnerSize

    let inline polairsSpinner (props : SpinnerProps list) : ReactElement =
        ofImport "Spinner" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []