namespace Fable.Polaris

[<AutoOpen>]
module AppProvider =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    // Needs work to have proper type
    type TranslationDictionary = obj

    type [<RequireQualifiedAccess>] AppColorsTopBar = {
        background: string
    }

    type [<RequireQualifiedAccess>] AppColors =
        | TopBar of AppColorsTopBar

    type [<RequireQualifiedAccess>] AppLogo =
        | AccessibilityLabel of string
        | ContextualSaveBarSource of string
        | TopBarSource of string
        | Url of string
        | Width of int

    type [<RequireQualifiedAccess>] AppTheme =
        static member Colors (colors: AppColors list) =
            unbox ("colors", (keyValueList CaseRules.LowerFirst colors))

        static member Logo (logo: AppLogo list) =
            unbox ("logo", (keyValueList CaseRules.LowerFirst logo))


    type [<RequireQualifiedAccess>] AppProviderProps =
        | ApiKey of string
        | Features of Polaris.Features
        | ForceRedirect of bool
        | I18n of U2<TranslationDictionary, TranslationDictionary list>
        | LinkComponent of ReactElement
        | ShopOrigin of string
        static member Theme (theme: AppTheme list) =
            unbox ("theme", (keyValueList CaseRules.LowerFirst theme))

    let inline polarisAppProvider (props : AppProviderProps list) (child : ReactElement) : ReactElement =
        ofImport "AppProvider" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) [ child ]