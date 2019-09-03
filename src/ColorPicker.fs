module Polaris.ColorPicker

open Fable.React
open Fable.Core
open Fable.Core.JsInterop

type Color = {
    alpha: int
    brightness: int
    hue: int
    saturation: int
}

type RequiredColorPickerProps = {
    Color: Color
    OnChange: (Color -> unit)
}

type ColorPickerProps =
    | AllowAlpha of bool
    | Id of string

let inline polarisColorPicker (requiredProps: RequiredColorPickerProps) (props : ColorPickerProps list) : ReactElement =
    let combinedProps =
        props
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?color <- requiredProps.Color
            obj?onChange <- requiredProps.OnChange
        )
    ofImport "ColorPicker" "@shopify/polaris" combinedProps []