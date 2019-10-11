namespace Fable.Polaris

[<AutoOpen>]
module ChoiceList =
    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] ChoiceItemRenderChildren = U2<ReactElement, unit>


    type [<RequireQualifiedAccess>] RequiredChoiceItemProps = {
        Label: string
        Value: string
    }
    type [<RequireQualifiedAccess>] ChoiceItemProps =
        | DescribedByError of bool
        | Disabled of bool
        | HelpText of ReactElement
        | RenderChildren of (bool -> ChoiceItemRenderChildren)

    type [<RequireQualifiedAccess>] ChoiceItem = RequiredChoiceItemProps * ChoiceItemProps list

    let choiceItemConverterHelper (choiceItem: ChoiceItem) =
        let requiredProps = fst choiceItem
        let combinedProps =
            (snd choiceItem)
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?label <- requiredProps.Label
                obj?value <- requiredProps.Value
                obj
            )
        combinedProps


    type [<RequireQualifiedAccess>] RequiredChoiceListProps = {
        Choices: ChoiceItem list
        Selected: string list
        Title: string
    }

    type [<RequireQualifiedAccess>] ChoiceListProps =
        | AllowMultiple of bool
        | Disabled of bool
        | Error of ReactElement
        | Name of string
        | TitleHidden of bool
        | OnChange of (string array -> string -> unit)


    let inline polarisChoiceList (requiredProps: RequiredChoiceListProps) (props : ChoiceListProps list) : ReactElement =
        let choices = 
            List.map choiceItemConverterHelper requiredProps.Choices
            |> List.toArray

        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?selected <- 
                    requiredProps.Selected
                    |> List.toArray

                obj?choices <- choices
                obj?title <- requiredProps.Title
                obj
            )


        ofImport "ChoiceList" "@shopify/polaris" combinedProps []
