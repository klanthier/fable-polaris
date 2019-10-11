namespace Fable.Polaris

[<AutoOpen>]
module ColorPicker =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] Color = {
        alpha: int
        brightness: int
        hue: int
        saturation: int
    }

    type [<RequireQualifiedAccess>] RequiredColorPickerProps = {
        Color: Color
        OnChange: (Color -> unit)
    }

    type [<RequireQualifiedAccess>] ColorPickerProps =
        | AllowAlpha of bool
        | Id of string

    let inline polarisColorPicker (requiredProps: RequiredColorPickerProps) (props : ColorPickerProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?color <- requiredProps.Color
                obj?onChange <- requiredProps.OnChange
                obj
            )
        ofImport "ColorPicker" "@shopify/polaris" combinedProps []