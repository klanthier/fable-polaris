namespace Fable.Polaris

[<AutoOpen>]
module Collapsible =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] RequiredCollapsibleProps = {
        Id: string
        Open: bool
    }

    type CollapsibleTransition = {
        duration: obj //The API is still not well defined in Polaris
        timingFunction: obj //The API is still not well defined in Polaris
    }

    type CollapsibleProps =
        | Transition of CollapsibleTransition

    let inline polarisCollapsible (requiredProps : RequiredCollapsibleProps) (props: CollapsibleProps list) (elems : ReactElement list): ReactElement =
        let finalProps =
            props
                |> keyValueList CaseRules.LowerFirst
                |> (fun obj ->
                    obj?id <- requiredProps.Id
                    obj?``open`` <- requiredProps.Open
                    obj
                )

        ofImport "Collapsible" "@shopify/polaris" finalProps elems