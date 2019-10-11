namespace Fable.Polaris

[<AutoOpen>]
module SkeletonPage =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] SkeletonPageProps =
        | Breadcrumbs of bool
        | FullWidth of bool
        | NarrowWidth of bool
        | PrimaryAction of bool
        | SecondaryActions of int
        | Title of string

    let inline polarisSkeletonPage (props: SkeletonPageProps list) (elems: ReactElement list): ReactElement =
        ofImport "SkeletonPage" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems
