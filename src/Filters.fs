namespace Fable.Polaris

module Filters =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type Filter = {
        key: string
        label: string
        onRemove: string -> unit //key -> void
    }

    type RequiredFilterProps = {
        Filters: Filter array
        OnClearAll: unit -> unit
        OnQueryChange: string -> unit //queryValue -> void
        OnQueryClear: unit -> unit
    }

    type FilterProps = 
        | AppliedFilters of Filter array
        | Focused of bool
        | QueryPlaceholder of string
        | QueryValue of string
        | OnQueryBlur of (unit -> unit)
        | OnQueryFocus of (unit -> unit)


    let inline polarisFilters (requiredProps: RequiredFilterProps) (props : FilterProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?filters <- requiredProps.Filters
                obj?onClearAll <- requiredProps.OnClearAll
                obj?onQueryChange <- requiredProps.OnQueryChange
                obj?onQueryClear <- requiredProps.OnQueryClear
            )

        ofImport "Filters" "@shopify/polaris" combinedProps []