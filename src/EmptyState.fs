namespace Fable.Polaris

module EmptyState =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type RequiredEmptyStateProps = {
        Image: string
    }

    type EmptyStateProps =
        | FooterContent of bool
        | Heading of string
        | ImageContained of bool
        | LargeImage of string
        static member SecondaryAction (action: Polaris.Action) =
            Polaris.actionUnboxHelper "secondaryAction" action
        static member Action (action: Polaris.Action) =
            Polaris.actionUnboxHelper "action" action


    let inline polarisEmptyState (requiredProps: RequiredEmptyStateProps) (props : EmptyStateProps list) (elems : ReactElement list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?image <- requiredProps.Image
            )

        ofImport "EmptyState" "@shopify/polaris" combinedProps elems