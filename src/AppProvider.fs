module Polaris.AppProvider

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
type AppColorsTopBar = {
    background: string
}
 
type AppColors = {
    topBar: AppColorsTopBar
}

type AppLogo = {
    width: int
    topBarSource: string
    url: string
    accessibilityLabel: string option
    contextualSaveBarSource: string option
}

type AppTheme = {
    colors: AppColors option
    logo: AppLogo option
}

type TranslationDictionary = TranslationDictionary

type AppProviderProps =
    | ApiKey of string
    | ForceRedirect of bool
    | I18n of U2<TranslationDictionary, TranslationDictionary list>
    | LinkComponent of ReactElement
    | ShopOrigin of string
    | Theme of AppTheme

let inline appProvider (props : AppProviderProps list) (child : ReactElement) : ReactElement =
    ofImport "AppProvider" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) [ child ]