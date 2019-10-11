namespace Fable.Polaris

[<AutoOpen>]
module Popover =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<RequireQualifiedAccess>] RequiredPopoverProps = {
        Activator: ReactElement
        Active: bool
        OnClose: (unit -> unit) //Missing OnSourceClose Impl.
    }

    type [<RequireQualifiedAccess>] PopoverProps =
        | ActivatorWrapper of string
        | Fixed of bool
        | FullHeight of bool
        | FullWidth of bool
        | PreferredAlignment of Polaris.PopoverPreferedAlignment
        | PreferredPosition of Polaris.PopoverPreferedPosition
        | PreventAutofocus of bool
        | Sectioned of bool


    let inline polarisPopover (requiredProps: RequiredPopoverProps) (props : PopoverProps list) (elems : ReactElement list): ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?activator <- requiredProps.Activator
                obj?active <- requiredProps.Active
                obj?onClose <- requiredProps.OnClose
                obj
            )

        ofImport "Popover" "@shopify/polaris" combinedProps elems