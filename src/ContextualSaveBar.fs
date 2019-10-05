namespace Fable.Polaris

module ContextualSaveBar =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type ContextualSaveBarDiscardAction =
        | DiscardConfirmationModal of bool
        | Content of string
        | Disabled of bool
        | Loading of bool
        | Url of string
        | OnAction of (unit -> unit)

    type ContextualSaveBarSaveAction =
        | Content of string
        | Disabled of bool
        | Loading of bool
        | Url of string
        | OnAction of (unit -> unit)

    type ContextualSaveBarProps =
        | AlignContentFlush of bool
        | Message of string
        static member SaveAction (action: ContextualSaveBarSaveAction list) =
            unbox ("saveAction", keyValueList CaseRules.LowerFirst action)

        static member DiscardAction (action: ContextualSaveBarDiscardAction list) =
            unbox ("discardAction", keyValueList CaseRules.LowerFirst action)

    let inline polarisContextualSaveBar (props : ContextualSaveBarProps list) : ReactElement =
        ofImport "ContextualSaveBar" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) []