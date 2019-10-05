namespace Fable.Polaris

module Autocomplete =

    open Fable.Polaris
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    type [<StringEnum>] [<RequireQualifiedAccess>] AutoCompletePreferedPostion =
        | [<CompiledName "above">] Above
        | [<CompiledName "below">] Below
        | [<CompiledName "mostSpace">] MostSpace

    type RequiredAutocompleteProps = {
        Selected: string array
        OnSelect: (string array -> unit)
        TextField: ReactElement
        Options: Polaris.OptionDescriptor list
    }

    type AutocompleteProps =
        | ActionBefore of Polaris.ActionListItemDescriptor
        | AllowMultiple of bool
        | EmptyState of ReactElement
        | Id of string
        | ListTitle of string
        | Loading of bool
        | PreferredPosition of AutoCompletePreferedPostion
        | WillLoadMoreResults of bool
        | OnLoadMoreResults of (unit -> unit)

    let inline autoComplete requiredProps (props : AutocompleteProps list): ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?selected <- requiredProps.Selected
                obj?onSelect <- requiredProps.OnSelect
                obj?textField <- requiredProps.TextField
                obj?options <- Array.map Polaris.optionDescriptorPropsConverterHelper (List.toArray requiredProps.Options)
                obj
            )
        ofImport "Autocomplete" "@shopify/polaris" combinedProps []
