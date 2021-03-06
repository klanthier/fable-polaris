namespace Fable.Polaris

[<AutoOpen>]
module ButtonGroup =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] ButtonGroupProps =
        | ConnectedTop of bool
        | FullWidth of bool
        | Segmented of bool

    let inline polarisButtonGroup (props : ButtonGroupProps list) (elems : ReactElement list): ReactElement =
        ofImport "ButtonGroup" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems
