namespace Fable.Polaris

[<AutoOpen>]
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

    type [<RequireQualifiedAccess>] DataTableRow = U3<ReactElement, string, float>

    type [<RequireQualifiedAccess>] RequiredDataTableProps = {
        Headings: ReactElement array
        Rows: DataTableRow array array
    }

    type DataTableTotalsName = {
        plural: string
        singular: string
    }

    type [<RequireQualifiedAccess>] DataTableProps =
        | ColumnContentTypes of DataTableColumnContent array
        | DefaultSortDirection of DataTableSortDirection
        | FooterContent of ReactElement
        | InitialSortColumnIndex of int
        | Sortable of bool array
        | ShowTotalsInFooter of bool
        | TotalsName of DataTableTotalsName
        | Totals of DataTableRow array
        | Truncate of bool
        | VerticalAlign of DataTableVerticalAlign
        | OnSort of (int -> DataTableSortDirection -> unit)

    let inline polarisDataTable (requiredProps: RequiredDataTableProps) (props : DataTableProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?headings <- requiredProps.Headings
                obj?rows <- requiredProps.Rows
                obj
            )

        ofImport "DataTable" "@shopify/polaris" combinedProps []
