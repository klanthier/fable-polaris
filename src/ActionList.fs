module Polaris.ActionList

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type [<StringEnum>] [<RequireQualifiedAccess>] ItemDescriptorBadgeStatus =
    |  [<CompiledName "new">] New

type [<RequireQualifiedAccess>] ActionListItemDescriptorBadge(content, ?status) =
    member __.Content : string = content
    member __.Status : ItemDescriptorBadgeStatus option = status

type [<RequireQualifiedAccess>] ActionListItemDescriptor(content, ?accessibilityLabel, ?active, ?badge, ?destructive, ?disabled, ?ellipsis, ?external, ?helpText, ?icon, ?id, ?image, ?role, ?target, ?url, ?onAction) =
    member __.AccessibilityLabel : string option = accessibilityLabel
    member __.Active : bool option = active
    member __.Badge : ActionListItemDescriptorBadge option = badge
    member __.Content : string = content
    member __.Destructive : bool option = destructive
    member __.Disabled : bool option = disabled
    member __.Ellipsis : bool option = ellipsis
    member __.External : bool option = external
    member __.HelpText : string option = helpText
    member __.Icon : BundledIcon option = icon
    member __.Id : string option = id
    member __.Image : string option = image
    member __.Role : string option = role
    member __.Target : LinkTarget option = target
    member __.Url : string option = url
    member __.OnAction : (unit -> unit) option = onAction

type [<RequireQualifiedAccess>] ActionListSection(items, title) =
    member __.Items : ActionListItemDescriptor array = items
    member __.Title : string = title

type RequiredActionListProps = {
    Items : ActionListItemDescriptor array
 }

type ActionListProps =
    | ActionRole of string
    | OnActionAnyItem of (unit -> unit)
    | Sections of ActionListSection array

let inline actionList requiredProps (props : ActionListProps list) : ReactElement =
    let combinedProps =
        props
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?items <- requiredProps.Items
            obj
        )
    ofImport "ActionList" "@shopify/polaris" combinedProps []
