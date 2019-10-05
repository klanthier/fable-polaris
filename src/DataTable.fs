namespace Fable.Polaris

module DataTable =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<StringEnum>] [<RequireQualifiedAccess>] DataTableColumnContent =
        | [<CompiledName "text">] Text
        | [<CompiledName "numeric">] Numeric

    type [<StringEnum>] [<RequireQualifiedAccess>] DataTableSortDirection =
        | [<CompiledName "ascending">] Ascending
        | [<CompiledName "descending">] Descending
        | [<CompiledName "none">] None

    type [<StringEnum>] [<RequireQualifiedAccess>] DataTableVerticalAlign =
        | [<CompiledName "baseline">] Baseline
        | [<CompiledName "bottom">] Bottom
        | [<CompiledName "middle">] Middle
        | [<CompiledName "top">] Top

    type DataTableRow = U3<ReactElement, string, float>

    type RequiredDataTableProps = {
        Headings: string array
        Rows: DataTableRow array array
    }

    type DataTableProps =
        | ColumnContentTypes of DataTableColumnContent array
        | DefaultSortDirection of DataTableSortDirection
        | FooterContent of ReactElement
        | InitialSortColumnIndex of int
        | Sortable of bool array
        | Totals of DataTableRow array
        | Truncate of bool
        | VerticalAlign of DataTableVerticalAlign
        | OnSort of (int -> DataTableSortDirection -> unit)

    let inline dataTable (requiredProps: RequiredDataTableProps) (props : DataTableProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?headings <- requiredProps.Headings
                obj?rows <- requiredProps.Rows
            )

        ofImport "DataTable" "@shopify/polaris" combinedProps []
