namespace Fable.Polaris

module Pagination =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type PaginationProps =
        | AccessibilityLabel of string
        | HasNext of bool
        | HasPrevious of bool
        | NextKeys of Polaris.Key array
        | NextTooltip of string
        | NextURL of string
        | Plain of bool
        | PreviousKeys of Polaris.Key array
        | PreviousTooltip of string
        | PreviousURL of string
        | OnNext of (unit -> unit)
        | OnPrevious of (unit -> unit)

    let inline polarisPagination (props : PaginationProps list): ReactElement =
        ofImport "Pagination" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) []