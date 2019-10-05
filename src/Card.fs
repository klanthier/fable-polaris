namespace Fable.Polaris

module Card =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type CardProps =
        | Title of ReactElement
        | Sectioned of bool
        | Subdued of bool
        | SecondaryFooterActionsDisclosureText of string
        static member Actions (actions: Polaris.DisableableAction list) =
            unbox ("actions",
                List.map Polaris.disableableActionConverterHelper actions
                |> List.toArray
            )
        static member PrimaryFooterAction (action: Polaris.ComplexAction) =
            unbox ("primaryFooterAction",
                Polaris.complexActionConverterHelper action
            )
        static member SecondaryFooterAction (action: Polaris.ComplexAction) =
            unbox ("secondaryFooterAction",
                Polaris.complexActionConverterHelper action
            )


    type CardHeaderProps =
        | Title of ReactElement
        static member Actions (actions: Polaris.DisableableAction list) =
            unbox ("actions",
                List.map Polaris.disableableActionConverterHelper actions
                |> List.toArray
            )

    type CardSectionProps =
        | Title of ReactElement
        | Subdued of bool
        | FullWidth of bool
        static member Actions (actions: Polaris.ComplexAction list) =
            unbox ("actions",
                List.map Polaris.complexActionConverterHelper actions
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