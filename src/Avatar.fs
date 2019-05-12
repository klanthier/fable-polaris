module Polaris.Avatar

open Fable.Core
open Fable.Core.JsInterop
open Fable.React

type [<StringEnum>] [<RequireQualifiedAccess>] AvatarSize =
    | [<CompiledName "small">] Small
    | [<CompiledName "medium">] Medium
    | [<CompiledName "large">] Large

type AvatarProps =
    | AccessibilityLabel of string
    | Customer of bool
    | Initials of string
    | Name of string
    | Size of AvatarSize
    | Source of string

let inline avatar (props : AvatarProps list): ReactElement =
    ofImport "Avatar" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []