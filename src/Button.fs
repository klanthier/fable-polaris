module Polaris.Button

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Fable.React

type [<StringEnum>] [<RequireQualifiedAccess>] ButtonSize =
    | [<CompiledName "slim">] Slim
    | [<CompiledName "medium">] Medium
    | [<CompiledName "large">] Large

[<RequireQualifiedAccess>]
type ButtonProps =
    | AccessibilityLabel of string
    | AriaControls of string
    | AriaExpanded of bool
    | AriaPressed of bool
    | Destructive of bool
    | Disabled of bool
    | Disclosure of bool
    | Download of U2<string, bool>
    | External of bool
    | FullWidth of bool
    | Icon of string
    | Id of string
    | Loading of bool
    | Monochrome of bool
    | Outline of bool
    | Plain of bool
    | Primary of bool
    | Size of ButtonSize
    | Submit of bool
    | Url of string
    | OnBlur of (Event -> unit)
    | OnFocus of (Event -> unit)

type RequiredButtonProps = {
    OnClick : (Event -> unit)
}


let inline button requiredProps (props : ButtonProps list) (elems : ReactElement list) : ReactElement =
    let combinedProps =
        props
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?onClick <- requiredProps.OnClick
            obj
        )
    ofImport "Button" "@shopify/polaris" combinedProps elems
