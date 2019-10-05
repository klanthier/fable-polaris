namespace Fable.Polaris

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

    type IconProps =
        | AccessibilityLabel of string
        | Backdrop of bool
        | Color of IconColor

    type RequiredIconProps = {
        Source : U3<ReactElement, Polaris.BundledIcon, string>
    }

    let inline polarisIcon (requiredProps: RequiredIconProps) (props : IconProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?source <- requiredProps.Source
            )
        ofImport "Icon" "@shopify/polaris" combinedProps []