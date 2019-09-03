module Polaris.Calloutcard

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type RequiredCalloutCardProps = {
    Illustration: string
    PrimaryAction: Action
    Title: string
}

type CalloutCardProps =
    | OnDismiss of (unit -> unit)
    static member SecondaryAction (action: Action) =
        actionUnboxHelper "secondaryAction" action

let inline polarisCalloutCard (requiredProps: RequiredCalloutCardProps) (props : CalloutCardProps List) (elems : ReactElement list) : ReactElement =
    let combinedProps =
        props
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?illustration <- requiredProps.Illustration
            obj?primaryAction <- actionConverterHelper requiredProps.PrimaryAction
            obj?title <- requiredProps.Title
            obj
        )

    ofImport "CalloutCard" "@shopify/polaris" combinedProps elems