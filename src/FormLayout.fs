namespace Fable.Polaris

[<AutoOpen>]
module FormLayout =
    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] FormLayoutGroup =
        | Condensed of bool
        | Title of string
        | HelpText of ReactElement

    let inline polarisFormLayout (elems : ReactElement list) : ReactElement =
        ofImport "FormLayout" "@shopify/polaris" [] elems

    let inline polarisFormLayoutItem (elems : ReactElement list) : ReactElement =
        ofImport "FormLayout.Item" "@shopify/polaris" [] elems

    let inline polarisFormLayoutGroup (props: FormLayoutGroup list) (elems : ReactElement list) : ReactElement =
        ofImport "FormLayout.Group" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems