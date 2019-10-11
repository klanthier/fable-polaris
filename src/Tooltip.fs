namespace Fable.Polaris

[<AutoOpen>]
module ToolTip =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<StringEnum>] [<RequireQualifiedAccess>] PreferedPosition =
        | [<CompiledName "above">] Above
        | [<CompiledName "below">] Below
        | [<CompiledName "mostSpace">] MostSpace

    type [<RequireQualifiedAccess>] TooltipProps =
      | ActivatorWrapper of string
      | Active of bool
      | Light of bool
      | PreferredPosition of PreferedPosition

    type [<RequireQualifiedAccess>] RequiredTooltipProps = {
        Content: string
    }

    let inline polarisTooltip (requiredProps: RequiredTooltipProps) (props : TooltipProps list) (elems : ReactElement list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?content <- requiredProps.Content
                obj
            )
        ofImport "Tooltip" "@shopify/polaris" combinedProps elems
