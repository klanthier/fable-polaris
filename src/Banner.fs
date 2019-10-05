namespace Fable.Polaris

module Banner =
    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<StringEnum>] [<RequireQualifiedAccess>] BannerStatus =
        | [<CompiledName "success">] Success
        | [<CompiledName "info">] Info
        | [<CompiledName "warning">] Warning
        | [<CompiledName "critical">] Critical

    type BannerAction = U2<Polaris.DisableableAction, Polaris.LoadableAction>

    type BannerProps =
        | Icon of string
        | Status of BannerStatus
        | Title of string
        | StopAnnouncements of bool
        | OnDismiss of (unit -> unit)
        static member SecondaryAction (action: Polaris.Action) =
            Polaris.actionUnboxHelper "secondaryAction" action

        static member Action (action: BannerAction) =
            unbox ("action",
                match action with
                    | U2.Case1 dAct ->
                        Polaris.disableableActionConverterHelper dAct
                    | U2.Case2 lAct ->
                        Polaris.lodableActionConverterHelper lAct
            )


    let inline polarisBanner (props : BannerProps list) (elems : ReactElement list) : ReactElement =
        ofImport "Banner" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems
