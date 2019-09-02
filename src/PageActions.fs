module Polaris.PageActions

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type PageAction = U2<DisableableAction, LoadableAction>

type PageActionsProps =
    static member PrimaryAction (action: PageAction) =
        unbox ("primaryAction",
            match action with
                | U2.Case1 dAct ->
                    disableableActionConverterHelper dAct
                | U2.Case2 lAct ->
                    lodableActionConverterHelper lAct
        )
    static member SecondaryActions (complexActions: ComplexAction list) =
        unbox ("secondaryActions",
            List.map complexActionConverterHelper complexActions
            |> List.toArray
        )

let inline polarisPageActions (props : PageActionsProps list): ReactElement =
    ofImport "PageActions" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) []