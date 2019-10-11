namespace Fable.Polaris

[<AutoOpen>]
module Avatar =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    type [<StringEnum>] [<RequireQualifiedAccess>] AvatarSize =
        | [<CompiledName "small">] Small
        | [<CompiledName "medium">] Medium
        | [<CompiledName "large">] Large

    type [<RequireQualifiedAccess>] AvatarProps =
        | AccessibilityLabel of string
        | Customer of bool
        | Initials of string
        | Name of string
        | Size of AvatarSize
        | Source of string

    let inline polarisAvatar (props : AvatarProps list): ReactElement =
        ofImport "Avatar" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []