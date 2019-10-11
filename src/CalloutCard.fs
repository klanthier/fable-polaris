namespace Fable.Polaris

[<AutoOpen>]
module Calloutcard =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<RequireQualifiedAccess>] RequiredCalloutCardProps = {
        Illustration: string
        PrimaryAction: Polaris.Action
        Title: string
    }

    type [<RequireQualifiedAccess>] CalloutCardProps =
        | OnDismiss of (unit -> unit)
        static member SecondaryAction (action: Polaris.Action) =
            Polaris.actionUnboxHelper "secondaryAction" action

    let inline polarisCalloutCard (requiredProps: RequiredCalloutCardProps) (props : CalloutCardProps List) (elems : ReactElement list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?illustration <- requiredProps.Illustration
                obj?primaryAction <- Polaris.actionConverterHelper requiredProps.PrimaryAction
                obj?title <- requiredProps.Title
                obj
            )

        ofImport "CalloutCard" "@shopify/polaris" combinedProps elems