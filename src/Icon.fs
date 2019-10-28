namespace Fable.Polaris



[<AutoOpen>]
module Icon =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React
    open Fable.Polaris

    [<RequireQualifiedAccess>]
    [<StringEnum>]
    type IconColor =
        | [<CompiledName "white">] White
        | [<CompiledName "black">] Black
        | [<CompiledName "skyLighter">] SkyLighter
        | [<CompiledName "skyLight">] SkyLight
        | [<CompiledName "sky">] Sky
        | [<CompiledName "skyDark">] SkyDark
        | [<CompiledName "inkLightest">] InkLightest
        | [<CompiledName "inkLighter">] InkLighter
        | [<CompiledName "inkLight">] InkLight
        | [<CompiledName "ink">] Ink
        | [<CompiledName "blueLighter">] BlueLighter
        | [<CompiledName "blueLight">] BlueLight
        | [<CompiledName "blue">] Blue
        | [<CompiledName "blueDark">] BlueDark
        | [<CompiledName "blueDarker">] BlueDarker
        | [<CompiledName "indigoLighter">] IndigoLighter
        | [<CompiledName "indigoLight">] IndigoLight
        | [<CompiledName "indigo">] Indigo
        | [<CompiledName "indigoDark">] IndigoDark
        | [<CompiledName "indigoDarker">] IndigoDarker
        | [<CompiledName "tealLighter">] TealLighter
        | [<CompiledName "tealLight">] TealLight
        | [<CompiledName "teal">] Teal
        | [<CompiledName "tealDark">] TealDark
        | [<CompiledName "tealDarker">] TealDarker
        | [<CompiledName "greenLighter">] GreenLighter
        | [<CompiledName "green">] Green
        | [<CompiledName "greenDark">] GreenDark
        | [<CompiledName "yellowLighter">] YellowLighter
        | [<CompiledName "yellow">] Yellow
        | [<CompiledName "yellowDark">] YellowDark
        | [<CompiledName "orange">] Orange
        | [<CompiledName "redLighter">] RedLighter
        | [<CompiledName "red">] Red
        | [<CompiledName "redDark">] RedDark
        | [<CompiledName "purple">] Purple

    type IconPlaceHolder = IconPlaceholer
    type [<RequireQualifiedAccess>] IconSource = U3<Polaris.FunctionPolarisIcon, IconPlaceHolder, string>

    type [<RequireQualifiedAccess>] IconProps =
        | AccessibilityLabel of string
        | Backdrop of bool
        | Color of IconColor

    type [<RequireQualifiedAccess>] RequiredIconProps = {
        Source : IconSource
    }


    [<ImportAll("@shopify/polaris-icons")>]
    let importedPolarisIcons: Fable.Core.JS.Object = jsNative

    let inline polarisUserProvidedIcon (iconName: string): Polaris.FunctionPolarisIcon =
        importedPolarisIcons?(iconName)


    let inline polarisIcon (requiredProps: RequiredIconProps) (props : IconProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?source <-
                    match requiredProps.Source with
                        | IconSource.Case1 x ->
                            unbox (x)
                        | IconSource.Case2 x ->
                            unbox ("placeholder")
                        | IconSource.Case3 x ->
                            unbox (x)
                obj
            )
        ofImport "Icon" "@shopify/polaris" combinedProps []