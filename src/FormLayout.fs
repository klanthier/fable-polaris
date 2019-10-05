namespace Fable.Polaris

module FormLayout =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type FormLayoutGroup =
        | Condensed of bool

    let inline polarisFormLayout (elems : ReactElement list) : ReactElement =
        ofImport "FormLayout" "@shopify/polaris" [] elems

    let inline polarisFormLayoutGroup (props: FormLayoutGroup list) (elems : ReactElement list) : ReactElement =
        ofImport "FormLayout.Group" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems