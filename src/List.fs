namespace Fable.Polaris

[<AutoOpen>]
module List =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<StringEnum>] [<RequireQualifiedAccess>] ListType =
        | [<CompiledName "bullet">] Bullet
        | [<CompiledName "number">] Number

    type [<RequireQualifiedAccess>] ListProps =
      | Type of ListType

    let inline polarisListItem (elems : ReactElement list) : ReactElement =
        ofImport "List.Item" "@shopify/polaris" [] elems

    let inline polarisList (props : ListProps list) (elems : ReactElement list) : ReactElement =
        ofImport "List" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) elems