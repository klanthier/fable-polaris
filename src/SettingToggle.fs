module Polaris.SettingToggle

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type SettingToggleProps =
    | Enabled of bool
    static member Action (action: Action) =
        actionUnboxHelper "action" action

let inline polarisSettingToggle (props : SettingToggleProps list) (elems: ReactElement list) : ReactElement =
    ofImport "SettingToggle" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems
