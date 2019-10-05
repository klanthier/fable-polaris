namespace Fable.Polaris

module SubHeading =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type SubHeadingProps =
        | Element of Polaris.ElementNameSelection

    let inline polarisSubHeading (props : SubHeadingProps list) (elems : ReactElement list) : ReactElement =
        ofImport "Subheading" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems