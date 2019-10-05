namespace Fable.Polaris

module SettingToggle =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type SettingToggleProps =
        | Enabled of bool
        static member Action (action: Polaris.Action) =
            Polaris.actionUnboxHelper "action" action

    let inline polarisSettingToggle (props : SettingToggleProps list) (elems: ReactElement list) : ReactElement =
        ofImport "SettingToggle" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems
