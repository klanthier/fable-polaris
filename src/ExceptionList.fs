namespace Fable.Polaris

module ExceptionList =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<StringEnum>] [<RequireQualifiedAccess>] ExceptionListItemStatus =
        | [<CompiledName "critical">] Critical
        | [<CompiledName "warning">] Warning

    type ExceptionListItemProps =
        | Title of string
        | Description of ReactElement
        | Icon of string
        | Status of ExceptionListItemStatus
        | Truncate of bool

    type ExceptionListProps =
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