namespace Fable.Polaris

module ActionList =

    open Fable.Polaris
    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type ActionListSection =
        | Title of string
        static member Items (items: Polaris.ActionListItemDescriptor list) =
            Polaris.actionListItemsDescriptorUnboxHelper "items" items

    type RequiredActionListProps = {
        Items : Polaris.ActionListItemDescriptor list
    }

    type ActionListProps =
        | ActionRole of string
        | OnActionAnyItem of (unit -> unit)
        static member Sections (sections: ActionListSection list) =
            unbox ("sections", keyValueList CaseRules.LowerFirst sections)

    let inline polarisActionList requiredProps (props : ActionListProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?items <- Array.map Polaris.actionListItemDescriptorUnboxHelper (List.toArray requiredProps.Items)
                obj
            )
        ofImport "ActionList" "@shopify/polaris" combinedProps []
