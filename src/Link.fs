namespace Fable.Polaris

[<AutoOpen>]
module Link =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Browser.Types

    type [<RequireQualifiedAccess>] LinkProps =
        | External of bool
        | Id of string
        | Monochrome of bool
        | Url of string
        | OnClick of (Event -> unit)

    let inline polarisLink (props : LinkProps list) (elems : ReactElement list) : ReactElement =
        ofImport "Link" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) elems
