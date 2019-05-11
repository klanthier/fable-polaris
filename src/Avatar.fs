module Polaris.Avatar

open Fable.Core
open Fable.React

type [<StringEnum>] [<RequireQualifiedAccess>] AvatarSize =
    | [<CompiledName "small">] Small
    | [<CompiledName "medium">] Medium
    | [<CompiledName "large">] Large

type AvatarProps = {
    accessibilityLabel: string option
    customer: bool option
    initials: string option
    name: string option
    size: AvatarSize option
    source: string option
}

let inline avatar (props : AvatarProps): ReactElement =
    ofImport "Avatar" "@shopify/polaris" props []