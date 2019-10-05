namespace Fable.Polaris

module Modal =


    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type ModalActions = U2<Polaris.AppBridgeAction, Polaris.ComplexAction>
    let modalActionsConverter (action: ModalActions) =
        match action with
            | U2.Case1 appAction ->
                Polaris.appBridgeActionConverterHelper appAction
            | U2.Case2 complexAction ->
                Polaris.complexActionConverterHelper complexAction

    type RequiredModalProps = {
        Open: bool
        OnClose: (unit -> unit)
    }

    type ModalProps =
        | Footer of ReactElement
        | IFrameName of string
        | Instant of bool
        | Large of bool
        | LimitHeight of bool
        | Loading of bool
        | Message of string
        | Sectioned of bool
        | Size of Polaris.ModalSize
        | Src of string
        | Title of ReactElement
        | OnIFrameLoad of (unit -> unit)
        | OnScrolledToBottom of (unit -> unit)
        | OnTransitionEnd of (unit -> unit)
        static member PrimaryAction (primary: ModalActions) =
            unbox ("primaryAction", modalActionsConverter primary)
        static member SecondaryActions (secondaryActions: ModalActions list) =
            unbox ("secondaryActions",
                List.map modalActionsConverter secondaryActions
                |> List.toArray
            )


    let inline polarisModal (requiredProps: RequiredModalProps) (props : ModalProps list) (elems : ReactElement list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?onClose <- requiredProps.OnClose
                obj?``open`` <- requiredProps.Open
                obj
            )
        ofImport "Modal" "@shopify/polaris" combinedProps elems

    let inline polarisModalSection (elems: ReactElement list): ReactElement =
        ofImport "Modal.Section" "@shopify/polaris" [] elems