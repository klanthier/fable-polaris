namespace Fable.Polaris

[<AutoOpen>]
module ResourceItem =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<RequireQualifiedAccess>] RequiredResourceItemProps = {
        Id : string
    }

    type [<StringEnum>] [<RequireQualifiedAccess>] ResourceItemAlignment = 
        | [<CompiledName "leading">] Leading
        | [<CompiledName "trailing">] Trailing
        | [<CompiledName "center">] Center
        | [<CompiledName "fill">] Fill
        | [<CompiledName "baseline">] Baseline

    type [<RequireQualifiedAccess>] ResourceItemProps =
        | AccessibilityLabel of string
        | Name of string
        | AriaControls of string
        | AriaExpanded of bool
        | Media of ReactElement
        | PersistActions of bool
        | VerticalAlignment of ResourceItemAlignment
        | SortOrder of float
        | Url of string
        | OnClick of (string -> unit)
        static member ShortcutActions (actions: Polaris.DisableableAction list) = 
            unbox("shortcutActions", Array.map Polaris.disableableActionConverterHelper (actions |> List.toArray))

    let inline polarisResourceItem (requiredProps : RequiredResourceItemProps) (props : ResourceItemProps list) (elems: ReactElement list): ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?id <- requiredProps.Id
                obj
            )
        ofImport "ResourceItem" "@shopify/polaris" combinedProps elems



