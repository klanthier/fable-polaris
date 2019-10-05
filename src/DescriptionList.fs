namespace Fable.Polaris

module DescriptionList =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type RequiredDescriptionListItemProps = {
        Description: ReactElement
        Term: ReactElement
    }

    type DescriptionListProps =
        static member Items (items: RequiredDescriptionListItemProps list) =
            unbox ("items",
                (List.map (
                    fun (x: RequiredDescriptionListItemProps) ->
                         (fun obj ->
                            obj?description <- x.Description
                            obj?term <- x.Term
                            obj
                         )
                ) items
                |> List.toArray)
            )

    let inline polarisDescriptionList (props : DescriptionListProps list) : ReactElement =
        ofImport "DescriptionList" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []