module Polaris.ActionList

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type ActionListSection =
    | Title of string
    static member Items (items: ActionListItemDescriptor list) =
        actionListItemsDescriptorUnboxHelper "items" items

type RequiredActionListProps = {
    Items : ActionListItemDescriptor list
}

type ActionListProps =
    | ActionRole of string
    | OnActionAnyItem of (unit -> unit)
    static member Sections (sections: ActionListSection list) =
        unbox ("sections", keyValueList CaseRules.LowerFirst sections)

let inline actionList requiredProps (props : ActionListProps list) : ReactElement =
    let combinedProps =
        props
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?items <- Array.map actionListItemDescriptorUnboxHelper (List.toArray requiredProps.Items)
            obj
        )
    ofImport "ActionList" "@shopify/polaris" combinedProps []
