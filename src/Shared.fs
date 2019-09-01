module Polaris.Shared

open Fable.Core
open Fable.React
open Fable.Core.JsInterop

type [<RequireQualifiedAccess>] [<StringEnum>] ColorOption =
    |  [<CompiledName "white">] White
    |  [<CompiledName "teal">] Teal
    |  [<CompiledName "inkLightest">] InkLightest

type [<RequireQualifiedAccess>] [<StringEnum>] BundledIcon =
    |  [<CompiledName "add">] Add
    |  [<CompiledName "alert">] Alert
    |  [<CompiledName "arrowDown">] ArrowDown
    |  [<CompiledName "arrowLeft">] ArrowLeft
    |  [<CompiledName "arrowRight">] ArrowRight
    |  [<CompiledName "arrowUp">] ArrowUp
    |  [<CompiledName "arrowUpDown">] ArrowUpDown
    |  [<CompiledName "calendar">] Calendar
    |  [<CompiledName "cancel">] Cancel
    |  [<CompiledName "cancelSmall">] CancelSmall
    |  [<CompiledName "caretDown">] CaretDown
    |  [<CompiledName "caretUp">] CaretUp
    |  [<CompiledName "checkmark">] Checkmark
    |  [<CompiledName "chevronDown">] ChevronDown
    |  [<CompiledName "chevronLeft">] ChevronLeft
    |  [<CompiledName "chevronRight">] ChevronRight
    |  [<CompiledName "chevronUp">] ChevronUp
    |  [<CompiledName "circleCancel">] CircleCancel
    |  [<CompiledName "circleChevronDown">] CircleChevronDown
    |  [<CompiledName "circleChevronLeft">] CircleChevronLeft
    |  [<CompiledName "circleChevronRight">] CircleChevronRight
    |  [<CompiledName "circleChevronUp">] CircleChevronUp
    |  [<CompiledName "circleInformation">] CircleInformation
    |  [<CompiledName "circlePlus">] CirclePlus
    |  [<CompiledName "circlePlusOutline">] CirclePlusOutline
    |  [<CompiledName "conversation">] Conversation
    |  [<CompiledName "delete">] Delete
    |  [<CompiledName "disable">] Disable
    |  [<CompiledName "dispute">] Dispute
    |  [<CompiledName "duplicate">] Duplicate
    |  [<CompiledName "embed">] Embed
    |  [<CompiledName "export">] Export
    |  [<CompiledName "external">] External
    |  [<CompiledName "help">] Help
    |  [<CompiledName "home">] Home
    |  [<CompiledName "horizontalDots">] HorizontalDots
    |  [<CompiledName "import">] Import
    |  [<CompiledName "logOut">] LogOut
    |  [<CompiledName "menu">] Menu
    |  [<CompiledName "notes">] Notes
    |  [<CompiledName "notification">] Notification
    |  [<CompiledName "onlineStore">] OnlineStore
    |  [<CompiledName "orders">] Orders
    |  [<CompiledName "placeholder">] Placeholder
    |  [<CompiledName "print">] Print
    |  [<CompiledName "products">] Products
    |  [<CompiledName "profile">] Profile
    |  [<CompiledName "refresh">] Refresh
    |  [<CompiledName "risk">] Risk
    |  [<CompiledName "save">] Save
    |  [<CompiledName "search">] Search
    |  [<CompiledName "subtract">] Subtract
    |  [<CompiledName "view">] View

type [<StringEnum>] [<RequireQualifiedAccess>] LinkTarget =
    |  [<CompiledName "ADMIN_PATH">] AdminPath
    |  [<CompiledName "REMOTE">] Remote
    |  [<CompiledName "APP">] App


type [<StringEnum>] [<RequireQualifiedAccess>] ItemDescriptorBadgeStatus =
    |  [<CompiledName "new">] New

////////////////////////////////////////
///              ACTION              ///
////////////////////////////////////////
type RequiredActionProps = {
    OnAction: unit -> unit
    Content: string
}

type ActionProps =
    | AccessibilityLabel of string
    | External of bool
    | Id of string
    | Url of string

type Action = RequiredActionProps * (ActionProps list)

let actionUnboxHelper (keyName: string) (action: Action) =
    let requiredProps = fst action
    let combinedProps =
        (snd action)
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?onAction <- requiredProps.OnAction
            obj?content <- requiredProps.Content
            obj
        )
    unbox (keyName, combinedProps)

////////////////////////////////////////
///     ActionListItemDescriptor     ///
////////////////////////////////////////
///
type ActionListItemDescriptorBadge =
    | Content of string
    | Status of ItemDescriptorBadgeStatus

type RequiredActionListItemDescriptorProps = {
    Content: string
    OnAction: (unit -> unit)
}

type ActionListItemDescriptorProps =
    | AccessibilityLabel of string
    | Active of bool
    | Destructive of bool
    | Disabled of bool
    | Ellipsis of bool
    | External of bool
    | HelpText of string
    | Icon of BundledIcon
    | Id of string
    | Image of string
    | Role of string
    | Target of LinkTarget
    | Url of string
    static member Badge (badge: ActionListItemDescriptorBadge list) =
        unbox ("badge", keyValueList CaseRules.LowerFirst badge)

type ActionListItemDescriptor = RequiredActionListItemDescriptorProps * (ActionListItemDescriptorProps list)

let actionListItemDescriptorUnboxHelper (action: ActionListItemDescriptor) =
    let requiredProps = fst action
    let combinedProps =
        (snd action)
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?onAction <- requiredProps.OnAction
            obj?content <- requiredProps.Content
            obj
        )
    combinedProps

let actionListItemsDescriptorUnboxHelper (keyName: string) (actions: ActionListItemDescriptor list) =
    let items = Array.map actionListItemDescriptorUnboxHelper (List.toArray actions)
    unbox (keyName, items)

////////////////////////////////////////
///          OptionDescriptor        ///
////////////////////////////////////////
type RequiredOptionDescriptorProps = {
    Label: ReactElement
    Value: string
}

type OptionDescriptorProps =
    | Active of bool
    | Disabled of bool
    | Id of string
    | Media of ReactElement

type OptionDescriptor = RequiredOptionDescriptorProps * (OptionDescriptorProps list)



let optionDescriptorPropsUnboxHelper (option: OptionDescriptor) =
    let requiredProps = fst option
    let combinedProps =
        (snd option)
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?label <- requiredProps.Label
            obj?value <- requiredProps.Value
            obj
        )
    combinedProps

let optionsDescriptorPropsUnboxHelper (keyName: string) (options: OptionDescriptor list) =
    let items = Array.map optionDescriptorPropsUnboxHelper (List.toArray options)
    unbox (keyName, items)