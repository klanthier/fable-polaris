namespace Fable.Polaris

module OptionList =


    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

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
        static member Options (options: Polaris.OptionDescriptor list) =
            Polaris.optionsDescriptorPropsUnboxHelper "options" options
        static member Sections (sections: Polaris.SectionDescriptor list) =
            Polaris.sectionDescriptorsPropsUnboxHelper "sections" sections


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