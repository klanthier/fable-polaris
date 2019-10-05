namespace Fable.Polaris

module Pagination =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    let inline polarisPagination (props : Polaris.PaginationDescriptor list): ReactElement =
        ofImport "Pagination" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) []