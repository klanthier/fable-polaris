namespace Fable.Polaris

[<AutoOpen>]
module DescriptionList =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] RequiredDescriptionListItemProps = {
        description: ReactElement
        term: ReactElement
    }

    type [<RequireQualifiedAccess>] DescriptionListProps =
        static member Items (items: RequiredDescriptionListItemProps list) =
            unbox ("items", items |> List.toArray)

    let inline polarisDescriptionList (props : DescriptionListProps list) : ReactElement =
        ofImport "DescriptionList" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []