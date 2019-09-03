module Polaris.Banner


open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type [<StringEnum>] [<RequireQualifiedAccess>] BannerStatus =
    | [<CompiledName "success">] Success
    | [<CompiledName "info">] Info
    | [<CompiledName "warning">] Warning
    | [<CompiledName "critical">] Critical

type BannerAction = U2<DisableableAction, LoadableAction>

type BannerProps =
    | Icon of string
    | Status of BannerStatus
    | Title of string
    | StopAnnouncements of bool
    | OnDismiss of (unit -> unit)
    static member SecondaryAction (action: Action) =
        actionUnboxHelper "secondaryAction" action

    static member Action (action: BannerAction) =
        unbox ("action",
            match action with
                | U2.Case1 dAct ->
                    disableableActionConverterHelper dAct
                | U2.Case2 lAct ->
                    lodableActionConverterHelper lAct
        )


let inline polarisBanner (props : BannerProps list) (elems : ReactElement list) : ReactElement =
    ofImport "Banner" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems
