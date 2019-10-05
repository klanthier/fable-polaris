namespace Fable.Polaris

module Tag =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    type TagProps =
        | Disabled of bool
        | OnRemove of (unit -> unit)

    let inline polarisTag (props : TagProps list) (elems: ReactElement list): ReactElement =
        ofImport "Tag" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) elems


