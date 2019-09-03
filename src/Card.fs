module Polaris.Card

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

type CardProps =
    | Title of ReactElement
    | Sectioned of bool
    | Subdued of bool
    | SecondaryFooterActionsDisclosureText of string
    static member Actions (actions: DisableableAction list) =
        unbox ("actions",
            List.map disableableActionConverterHelper actions
            |> List.toArray
        )
    static member PrimaryFooterAction (action: ComplexAction) =
        unbox ("primaryFooterAction",
            complexActionConverterHelper action
        )
    static member SecondaryFooterAction (action: ComplexAction) =
        unbox ("secondaryFooterAction",
            complexActionConverterHelper action
        )


type CardHeaderProps =
    | Title of ReactElement
    static member Actions (actions: DisableableAction list) =
        unbox ("actions",
            List.map disableableActionConverterHelper actions
            |> List.toArray
        )

type CardSectionProps =
    | Title of ReactElement
    | Subdued of bool
    | FullWidth of bool
    static member Actions (actions: ComplexAction list) =
        unbox ("actions",
            List.map complexActionConverterHelper actions
            |> List.toArray
        )

let inline polarisCard (props : CardProps List) (elems : ReactElement list) : ReactElement =
    ofImport "Card" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems

let inline polarisCardHeader (props : CardHeaderProps List) (elems : ReactElement list) : ReactElement =
    ofImport "Card.Header" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems

let inline polarisCardSection (props : CardSectionProps List) (elems : ReactElement list) : ReactElement =
    ofImport "Card.Section" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems

let inline polarisCardSubsection (elems : ReactElement list) : ReactElement =
    ofImport "Card.Subsection" "@shopify/polaris" [] elems