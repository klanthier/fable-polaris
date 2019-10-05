namespace Fable.Polaris

module PageActions =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type PageAction = U2<Polaris.DisableableAction, Polaris.LoadableAction>

    type PageActionsProps =
        static member PrimaryAction (action: PageAction) =
            unbox ("primaryAction",
                match action with
                    | U2.Case1 dAct ->
                        Polaris.disableableActionConverterHelper dAct
                    | U2.Case2 lAct ->
                        Polaris.lodableActionConverterHelper lAct
            )
        static member SecondaryActions (complexActions: Polaris.ComplexAction list) =
            unbox ("secondaryActions",
                List.map Polaris.complexActionConverterHelper complexActions
                |> List.toArray
            )

    let inline polarisPageActions (props : PageActionsProps list): ReactElement =
        ofImport "PageActions" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) []