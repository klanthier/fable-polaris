module Polaris.OptionList

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type RequiredOptionListProps = {
    Selected: string array
    OnChange: (string array -> unit)
}

type OptionListProps =
    | AllowMultiple of bool
    | Id of string
    | OptionRole of string
    | Role of string
    | Title of string
    static member Options (options: OptionDescriptor list) =
        optionsDescriptorPropsUnboxHelper "options" options
    static member Sections (sections: SectionDescriptor list) =
        sectionDescriptorsPropsUnboxHelper "sections" sections


let inline polarisOptionList (requiredProps: RequiredOptionListProps) (props : OptionListProps list): ReactElement =
    let combinedProps =
        props
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?onChange <- requiredProps.OnChange
            obj?selected <- requiredProps.Selected
            obj
        )

    ofImport "OptionList" "@shopify/polaris" combinedProps []