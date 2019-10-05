namespace Fable.Polaris

module Heading =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type HeadingProps =
        | Element of Polaris.ElementNameSelection

    let inline polarisHeading (props: HeadingProps list) (elems : ReactElement) : ReactElement =
        ofImport "Heading" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) [elems]

