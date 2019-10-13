namespace Fable.Polaris


[<AutoOpen>]
module ExceptionList =
    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<StringEnum>] [<RequireQualifiedAccess>] ExceptionListItemStatus =
        | [<CompiledName "critical">] Critical
        | [<CompiledName "warning">] Warning

    type [<RequireQualifiedAccess>] ExceptionListItemProps =
        | Title of string
        | Description of ReactElement
        | Status of ExceptionListItemStatus
        | Truncate of bool
        | Icon of Polaris.FunctionPolarisIcon

    type [<RequireQualifiedAccess>] ExceptionListProps =
        static member Items (items: ExceptionListItemProps list list) =
            unbox ("items",
                (List.map (
                    fun (x: ExceptionListItemProps list) ->
                        keyValueList CaseRules.LowerFirst x
                ) items
                |> List.toArray)
            )

    let inline polarisExceptionList (props : ExceptionListProps list) : ReactElement =
        ofImport "ExceptionList" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []