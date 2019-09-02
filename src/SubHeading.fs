module Polaris.SubHeading

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type SubHeadingProps =
    | Element of ElementNameSelection

let inline polarisSubHeading (props : SubHeadingProps list) (elems : ReactElement list) : ReactElement =
    ofImport "Subheading" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems