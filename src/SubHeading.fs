namespace Fable.Polaris

[<AutoOpen>]
module SubHeading =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<RequireQualifiedAccess>] SubHeadingProps =
        | Element of Polaris.ElementNameSelection

    let inline polarisSubHeading (props : SubHeadingProps list) (elems : ReactElement list) : ReactElement =
        ofImport "Subheading" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems