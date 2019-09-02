module Polaris.SkeletonPage

open Fable.React
open Fable.Core
open Fable.Core.JsInterop

type SkeletonPageProps =
    | Breadcrumbs of bool
    | FullWith of bool
    | NarrowWidth of bool
    | PrimaryAction of bool
    | SecondaryActions of int
    | Title of string

let inline polarisSkeletonPage (props : SkeletonPageProps list) (elems : ReactElement list) : ReactElement =
    ofImport "SkeletonPage" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems
