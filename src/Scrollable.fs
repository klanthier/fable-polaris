namespace Fable.Polaris

module Scrollable =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] ScrollableProps =
        | Hint of bool
        | Horizontal of bool
        | Shadow of bool
        | Vertical of bool
        | OnScrolledToBottom of (unit -> unit)

    let inline polarisScrollable (props : ScrollableProps list) (elems : ReactElement list) : ReactElement =
        ofImport "Scrollable" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems