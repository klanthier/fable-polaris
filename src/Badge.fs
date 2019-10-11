namespace Fable.Polaris

[<AutoOpen>]
module Badge =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<StringEnum>] [<RequireQualifiedAccess>] BadgeProgress =
        | [<CompiledName "incomplete">] Incomplete
        | [<CompiledName "partiallyComplete">] PartiallyComplete
        | [<CompiledName "complete">] Complete

    type [<StringEnum>] [<RequireQualifiedAccess>] BadgeSize =
        | [<CompiledName "small">] Small
        | [<CompiledName "medium">] Medium

    type [<StringEnum>] [<RequireQualifiedAccess>] BadgeStatus =
        | [<CompiledName "success">] Success
        | [<CompiledName "info">] Info
        | [<CompiledName "attention">] Attention
        | [<CompiledName "warning">] Warning
        | [<CompiledName "new">] New

    type [<RequireQualifiedAccess>] BadgeProps =
        | Progress of BadgeProgress
        | Size of BadgeSize
        | Status of BadgeStatus


    let inline polarisBadge (props : BadgeProps list) (elems : ReactElement list) : ReactElement =
        ofImport "Badge" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems
