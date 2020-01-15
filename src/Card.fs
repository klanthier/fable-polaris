namespace Fable.Polaris

[<AutoOpen>]
module Card =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<StringEnum>] [<RequireQualifiedAccess>] CardFooterActionAlignment = 
        | [<CompiledName "right">] Right
        | [<CompiledName "left">] Left

    type [<RequireQualifiedAccess>] CardProps =
        | Title of ReactElement
        | Sectioned of bool
        | Subdued of bool
        | FooterActionAlignment of CardFooterActionAlignment
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
        static member SecondaryFooterActions (actions: Polaris.ComplexAction list) =
            unbox ("secondaryFooterActions",
                List.map Polaris.complexActionConverterHelper actions
                |> List.toArray
            )


    type [<RequireQualifiedAccess>] CardHeaderProps =
        | Title of ReactElement
        static member Actions (actions: Polaris.DisableableAction list) =
            unbox ("actions",
                List.map Polaris.disableableActionConverterHelper actions
                |> List.toArray
            )

    type [<RequireQualifiedAccess>] CardSectionProps =
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