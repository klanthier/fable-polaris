module Polaris.ChoiceList


open Fable.React
open Fable.Core
open Fable.Core.JsInterop

type ChoiceItemRenderChildren = U2<ReactElement, unit>


type RequiredChoiceItemProps = {
    Label: string
    Value: string
}
type ChoiceItemProps =
    | DescribedByError of bool
    | Disabled of bool
    | HelpText of ReactElement
    | RenderChildren of (bool -> ChoiceItemRenderChildren)

type ChoiceItem = RequiredChoiceItemProps * ChoiceItemProps list

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


type RequiredChoiceListProps = {
    Choices: ChoiceItem list
    Selected: string list
    Title: string
}

type ChoiceListProps =
    | AllowMultiple of bool
    | Disabled of bool
    | Error of ReactElement
    | Name of string
    | TitleHidden of bool
    | OnChange of (string array -> string -> unit)


let inline polarisChoiceList (requiredProps: RequiredChoiceListProps) (props : ChoiceListProps list) : ReactElement =
    let combinedProps =
        props
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?selected <- requiredProps.Selected
            obj?choices <-
                List.map choiceItemConverterHelper requiredProps.Choices
                |> List.toArray

            obj?title <- requiredProps.Title
        )


    ofImport "ChoiceList" "@shopify/polaris" combinedProps []
