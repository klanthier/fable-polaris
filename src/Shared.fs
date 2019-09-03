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

type [<StringEnum>] [<RequireQualifiedAccess>] TextAlign =
    |  [<CompiledName "left">] Left
    |  [<CompiledName "right">] Right
    |  [<CompiledName "center">] Center


type [<StringEnum>] [<RequireQualifiedAccess>] LinkTarget =
    |  [<CompiledName "ADMIN_PATH">] AdminPath
    |  [<CompiledName "REMOTE">] Remote
    |  [<CompiledName "APP">] App

type [<StringEnum>] [<RequireQualifiedAccess>] TextFieldType =
    | [<CompiledName "text">] Text
    | [<CompiledName "email">] Email
    | [<CompiledName "number">] Number
    | [<CompiledName "password">] Password
    | [<CompiledName "search">] Search
    | [<CompiledName "tel">] Tel
    | [<CompiledName "url">] Url
    | [<CompiledName "date">] Date
    | [<CompiledName "datetime-local">] DatetimeLocal
    | [<CompiledName "month">] Month
    | [<CompiledName "time">] Time
    | [<CompiledName "week">] Week
    | [<CompiledName "currency">] Currency

type [<StringEnum>] [<RequireQualifiedAccess>] ItemDescriptorBadgeStatus =
    |  [<CompiledName "new">] New

type [<RequireQualifiedAccess>] [<StringEnum>] ElementNameSelection =
    |  [<CompiledName "h1">] H1
    |  [<CompiledName "h2">] H2
    |  [<CompiledName "h3">] H3
    |  [<CompiledName "h4">] H4
    |  [<CompiledName "h5">] H5
    |  [<CompiledName "h6">] H6
    |  [<CompiledName "p">] P

type [<StringEnum>] [<RequireQualifiedAccess>] ThumbnailSize =
    | [<CompiledName "small">] Small
    | [<CompiledName "medium">] Medium
    | [<CompiledName "large">] Large

type [<StringEnum>] [<RequireQualifiedAccess>] DisplayTextSize =
    | [<CompiledName "small">] Small
    | [<CompiledName "medium">] Medium
    | [<CompiledName "large">] Large
    | [<CompiledName "extraLarge">] ExtraLarge

type [<StringEnum>] [<RequireQualifiedAccess>] ProgressBarSize =
    | [<CompiledName "small">] Small
    | [<CompiledName "medium">] Medium
    | [<CompiledName "large">] Large

type [<StringEnum>] [<RequireQualifiedAccess>] SelectAllItems =
    |  [<CompiledName "All">] All

type [<StringEnum>] [<RequireQualifiedAccess>] DateOptionsTypes =
    | [<CompiledName "past">] Past
    | [<CompiledName "future">] Future
    | [<CompiledName "full">] Full

type [<StringEnum>] [<RequireQualifiedAccess>] PopoverPreferedAlignment =
  | [<CompiledName "left">] Left
  | [<CompiledName "center">] Center
  | [<CompiledName "right">] Right

type [<StringEnum>] [<RequireQualifiedAccess>] PopoverPreferedPosition =
  | [<CompiledName "above">] Above
  | [<CompiledName "below">] Below
  | [<CompiledName "mostSpace">] MostSpace

type [<StringEnum>] [<RequireQualifiedAccess>] ModalSize =
    | [<CompiledName "Small">] Small
    | [<CompiledName "Medium">] Medium
    | [<CompiledName "Large">] Large
    | [<CompiledName "Full">] Full

type Key =
  | Backspace = 8
  | Tab = 9
  | Enter = 13
  | Shift = 16
  | Ctrl = 17
  | Alt = 18
  | Pause = 19
  | CapsLock = 20
  | Escape = 27
  | Space = 32
  | PageUp = 33
  | PageDown = 34
  | End = 35
  | Home = 36
  | LeftArrow = 37
  | UpArrow = 38
  | RightArrow = 39
  | DownArrow = 40
  | Insert = 45
  | Delete = 46
  | Key0 = 48
  | Key1 = 49
  | Key2 = 50
  | Key3 = 51
  | Key4 = 52
  | Key5 = 53
  | Key6 = 54
  | Key7 = 55
  | Key8 = 56
  | Key9 = 57
  | KeyA = 65
  | KeyB = 66
  | KeyC = 67
  | KeyD = 68
  | KeyE = 69
  | KeyF = 70
  | KeyG = 71
  | KeyH = 72
  | KeyI = 73
  | KeyJ = 74
  | KeyK = 75
  | KeyL = 76
  | KeyM = 77
  | KeyN = 78
  | KeyO = 79
  | KeyP = 80
  | KeyQ = 81
  | KeyR = 82
  | KeyS = 83
  | KeyT = 84
  | KeyU = 85
  | KeyV = 86
  | KeyW = 87
  | KeyX = 88
  | KeyY = 89
  | KeyZ = 90
  | LeftMeta = 91
  | RightMeta = 92
  | Select = 93
  | Numpad0 = 96
  | Numpad1 = 97
  | Numpad2 = 98
  | Numpad3 = 99
  | Numpad4 = 100
  | Numpad5 = 101
  | Numpad6 = 102
  | Numpad7 = 103
  | Numpad8 = 104
  | Numpad9 = 105
  | Multiply = 106
  | Add = 107
  | Subtract = 109
  | Decimal = 110
  | Divide = 111
  | F1 = 112
  | F2 = 113
  | F3 = 114
  | F4 = 115
  | F5 = 116
  | F6 = 117
  | F7 = 118
  | F8 = 119
  | F9 = 120
  | F10 = 121
  | F11 = 122
  | F12 = 123
  | NumLock = 144
  | ScrollLock = 145
  | Semicolon = 186
  | Equals = 187
  | Comma = 188
  | Dash = 189
  | Period = 190
  | ForwardSlash = 191
  | GraveAccent = 192
  | OpenBracket = 219
  | BackSlash = 220
  | CloseBracket = 221
  | SingleQuote = 222

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


let actionConverterHelper (action: Action) =
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

let actionUnboxHelper (keyName: string) (action: Action) =
    unbox (keyName, actionConverterHelper action)

////////////////////////////////////////
///         DISABLEABLE-ACTION       ///
////////////////////////////////////////
type RequiredDisableableActionProps = {
    Content : string
}

type DisableableActionProps =
    | AccessibilityLabel of string
    | Disabled of bool
    | External of bool
    | Id of string
    | Url of string
    | OnAction of (unit -> unit)

type DisableableAction = RequiredDisableableActionProps * (DisableableActionProps list)

let disableableActionConverterHelper (disableableAction: DisableableAction) =
    let requiredProps = fst disableableAction
    let combinedProps =
        (snd disableableAction)
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?content <- requiredProps.Content
            obj
        )
    combinedProps


////////////////////////////////////////
///          COMPLEX-ACTION          ///
////////////////////////////////////////
type RequiredComplexActionProps = {
    Content : string
}

type ComplexActionProps =
    | AccessibilityLabel of string
    | External of bool
    | Id of string
    | Url of string
    | OnAction of (unit -> unit)
    | Destructive of bool
    | Disabled of bool
    | Target of LinkTarget
    | Icon of string
    | Loading of bool

type ComplexAction = RequiredComplexActionProps * (ComplexActionProps list)

let complexActionConverterHelper (complexAction: ComplexAction) =
    let requiredProps = fst complexAction
    let combinedProps =
        (snd complexAction)
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?content <- requiredProps.Content
            obj
        )
    combinedProps


////////////////////////////////////////
///         APP-BRIDGE-ACTION        ///
////////////////////////////////////////
type RequiredAppBridgeActionProps = {
    Content : string
}

type AppBridgeActionProps =
    | AccessibilityLabel of string
    | External of bool
    | Id of string
    | Url of string
    | OnAction of (unit -> unit)
    | Destructive of bool
    | Disabled of bool
    | Target of LinkTarget

type AppBridgeAction = RequiredAppBridgeActionProps * (AppBridgeActionProps list)

let appBridgeActionConverterHelper (appBridgeAction: AppBridgeAction) =
    let requiredProps = fst appBridgeAction
    let combinedProps =
        (snd appBridgeAction)
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?content <- requiredProps.Content
            obj
        )
    combinedProps


////////////////////////////////////////
///         LOADABLE-ACTION          ///
////////////////////////////////////////
type RequiredLoadableActionProps = {
    Content : string
}

type LoadableActionProps =
    | AccessibilityLabel of string
    | External of bool
    | Id of string
    | Url of string
    | OnAction of (unit -> unit)
    | Loading of bool

type LoadableAction = RequiredLoadableActionProps * (LoadableActionProps list)

let lodableActionConverterHelper (loadableAction: LoadableAction) =
    let requiredProps = fst loadableAction
    let combinedProps =
        (snd loadableAction)
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?content <- requiredProps.Content
            obj
        )
    combinedProps



////////////////////////////////////////
///          STRICT-OPTION           ///
////////////////////////////////////////
type RequiredStrictOptionProps = {
    Label : string
    Value : string
}

type StrictOptionProps =
    | Disabled of bool

type StrictOption = RequiredStrictOptionProps * (StrictOptionProps list)

let strictOptionConverterHelper (strictOption: StrictOption) =
    let requiredProps = fst strictOption
    let combinedProps =
        (snd strictOption)
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?label <- requiredProps.Label
            obj?value <- requiredProps.Value
            obj
        )
    combinedProps

////////////////////////////////////////
///     ActionListItemDescriptor     ///
////////////////////////////////////////
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

let optionDescriptorPropsConverterHelper (option: OptionDescriptor) =
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
    let items = Array.map optionDescriptorPropsConverterHelper (List.toArray options)
    unbox (keyName, items)


////////////////////////////////////////
///          SectionDescriptor       ///
////////////////////////////////////////

type RequiredSectionDescriptorProps = {
    Options: OptionDescriptor list
}

type SectionDescriptorProps =
    | Title of string

type SectionDescriptor = RequiredSectionDescriptorProps * SectionDescriptorProps list

let sectionDescriptorPropsConverterHelper (option: SectionDescriptor) =
    let requiredProps = fst option
    let combinedProps =
        (snd option)
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?options <-
                List.map optionDescriptorPropsConverterHelper requiredProps.Options
                |> List.toArray

            obj
        )
    combinedProps

let sectionDescriptorsPropsUnboxHelper (keyName: string) (options: SectionDescriptor list) =
    let items = Array.map sectionDescriptorPropsConverterHelper (List.toArray options)
    unbox (keyName, items)