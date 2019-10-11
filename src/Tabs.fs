namespace Fable.Polaris

[<AutoOpen>]
module Tabs =
    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<StringEnum>] [<RequireQualifiedAccess>] TabsSpacing =
        | [<CompiledName "extraTight">] ExtraTight
        | [<CompiledName "tight">] Tight
        | [<CompiledName "loose">] Loose
        | [<CompiledName "extraLoose">] ExtraLoose
        | [<CompiledName "none">] None

    type [<RequireQualifiedAccess>] RequiredTabDescriptorProps = {
        Content : string
        Id : string
    }

    type [<RequireQualifiedAccess>] TabDescriptorProps =
        | AccessibilityLabel of string
        | PanelID of string
        | Url of string

    type TabDescriptor = {
        required: RequiredTabDescriptorProps
        optional: TabDescriptorProps list
    }

    let TabDescriptorUnboxerHelper (tabs: TabDescriptor list) =
        List.map (
            fun (i: TabDescriptor) ->
                let reqProps = i.required

                (i.optional)
                |> keyValueList CaseRules.LowerFirst
                |> (fun obj ->
                  obj?content <- reqProps.Content
                  obj?id <- reqProps.Id
                  obj
                )
        ) tabs
        |> List.toArray

    type [<RequireQualifiedAccess>] RequiredTabsProps = {
        Selected : int
        Tabs : TabDescriptor list
    }

    type [<RequireQualifiedAccess>] TabsProps =
        | Fitted of bool
        | OnSelect of (int -> unit)

    let inline polarisTabs (requiredProps : RequiredTabsProps) (props : TabsProps List) (elems : ReactElement list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
              obj?selected <- requiredProps.Selected
              obj?tabs <- TabDescriptorUnboxerHelper <| requiredProps.Tabs
              obj
            )
        ofImport "Tabs" "@shopify/polaris" combinedProps elems
