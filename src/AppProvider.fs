module Polaris.AppProvider

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

type AppProviderProps = {
    linkComponent: ReactElement option
    theme: AppTheme option
}

let inline appProvider (props : AppProviderProps) (elems : ReactElement list) : ReactElement =
    ofImport "AppProvider" "@shopify/polaris" props elems