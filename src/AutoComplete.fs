module Polaris.Autocomplete

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Polaris.Shared

type [<StringEnum>] [<RequireQualifiedAccess>] AutoCompletePreferedPostion =
    | [<CompiledName "above">] Above
    | [<CompiledName "below">] Below
    | [<CompiledName "mostSpace">] MostSpace

type RequiredAutocompleteProps = {
    Selected: string array
    OnSelect: (string array -> unit)
    TextField: ReactElement
    Options: OptionDescriptor list
}

type AutocompleteProps =
    | ActionBefore of ActionListItemDescriptor
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
            obj?options <- Array.map optionDescriptorPropsUnboxHelper (List.toArray requiredProps.Options)
            obj
        )
    ofImport "Autocomplete" "@shopify/polaris" combinedProps []
