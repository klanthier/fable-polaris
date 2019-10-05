namespace Fable.Polaris

module Layout =

  open Fable.React
  open Fable.Core
  open Fable.Core.JsInterop

  type LayoutProps =
    | Sectioned of bool

  type LayoutSectionProps =
    | Secondary of bool
    | FullWidth of bool
    | OneHalf of bool
    | OneThird of bool

  type LayoutAnnotatedSectionProps =
    | Title of ReactElement
    | Description of ReactElement

  let inline polarisLayout (props : LayoutProps List) (elems : ReactElement list) : ReactElement =
      ofImport "Layout" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems

  let inline polarisLayoutSection (props : LayoutSectionProps List) (elems : ReactElement list) : ReactElement =
      ofImport "Layout.Section" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems

  let inline polarisLayoutAnnotatedSection (props : LayoutAnnotatedSectionProps List) (elems : ReactElement list) : ReactElement =
      ofImport "Layout.AnnotatedSection" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems