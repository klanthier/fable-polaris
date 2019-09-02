module Polaris.Pagination

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type PaginationProps =
    | AccessibilityLabel of string
    | HasNext of bool
    | HasPrevious of bool
    | NextKeys of Key array
    | NextTooltip of string
    | NextURL of string
    | Plain of bool
    | PreviousKeys of Key array
    | PreviousTooltip of string
    | PreviousURL of string
    | OnNext of (unit -> unit)
    | OnPrevious of (unit -> unit)

let inline polarisPagination (props : PaginationProps list): ReactElement =
    ofImport "Pagination" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) []