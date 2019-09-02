module Polaris.TextField


open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type [<StringEnum>] [<RequireQualifiedAccess>] TextFieldAlignment =
    | [<CompiledName "left">] Left
    | [<CompiledName "center">] Center
    | [<CompiledName "right">] Right

type TextFieldProps =
  | Align of TextFieldAlignment
  | AriaActiveDescendant of string
  | AriaAutocomplete of string
  | AriaControls of string
  | AriaOwns of string
  | AutoComplete of bool
  | AutoFocus of bool
  | ClearButton of bool
  | ConnectedLeft of ReactElement
  | ConnectedRight of ReactElement
  | Disabled of bool
  | Error of ReactElement
  | Focused of bool
  | HelpText of ReactElement
  | Id of string
  | LabelHidden of bool
  | Max of int
  | MaxLength of int
  | Min of int
  | MinLength of int
  | Multiline of bool
  | Name of string
  | Pattern of string
  | Placeholder of string
  | Prefix of ReactElement
  | ReadOnly of bool
  | Role of string
  | ShowCharacterCount of bool
  | SpellCheck of bool
  | Step of float
  | Suffix of ReactElement
  | Type of TextFieldType
  | OnBlur of (unit -> unit)
  | OnChange of (string -> string -> unit)
  | OnClearButtonClick of (string -> unit)
  | OnFocus of (unit -> unit)
  static member LabelAction (action: Action) =
    actionUnboxHelper "labelAction" action

type RequiredTextFieldProps = {
  Value: string
  Label: string
}

let inline polarisTextField requiredProps (props : TextFieldProps list) : ReactElement =
    let combinedProps =
        props
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?label <- requiredProps.Label
            obj?value <- requiredProps.Value
            obj
        )
    ofImport "TextField" "@shopify/polaris" combinedProps []