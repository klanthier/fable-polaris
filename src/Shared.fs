module Polaris.Shared

open Fable.Core

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


///
/// ACTIONS
type [<RequireQualifiedAccess>] Action(content, onAction, ?accessibilityLabel, ?external, ?id, ?url) =
    member __.AccessibilityLabel : string option = accessibilityLabel
    member __.External : bool option = external
    member __.Id : string option = id
    member __.Url : string option = url
    member __.OnAction : unit -> unit = onAction
    member __.Content : string = content
