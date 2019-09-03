module Polaris.Button

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Polaris.Shared

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
    | TextAlign of TextAlign
    | Url of string
    | OnBlur of (Event -> unit)
    | OnFocus of (Event -> unit)
    | OnClick of (Event -> unit)
    | OnKeyDown of (KeyboardEvent -> unit)
    | OnKeyPress of (KeyboardEvent -> unit)
    | OnKeyUp of (KeyboardEvent -> unit)


let inline polarisButton (props : ButtonProps list) (children : ReactElement list) : ReactElement =
    ofImport "Button" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) children
