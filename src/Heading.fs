module Polaris.Heading

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type HeadingProps =
    | Element of ElementNameSelection

let inline polarisHeading (props: HeadingProps list) (elems : ReactElement) : ReactElement =
    ofImport "Heading" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) [elems]

