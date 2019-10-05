namespace Fable.Polaris

module RangeSlider =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type RequiredRangeSliderProps = {
        OnChange: (int -> string -> unit)
        Value: int // Missing dual value implementation
    }
    type RangeSliderProps =
        | Disabled of bool
        | Error of ReactElement
        | HelpText of ReactElement
        | Id of string
        | Label of string
        | LabelHidden of bool
        | Max of int
        | Min of int
        | Output of bool
        | Prefix of ReactElement
        | Step of int
        | Suffix of ReactElement
        | OnBlur of (unit -> unit)
        | OnFocus of (unit -> unit)
        static member LabelAction (action: Polaris.Action) =
            Polaris.actionUnboxHelper "labelAction" action


    let inline polarisRangeSlider (requiredProps: RequiredRangeSliderProps) (props : RangeSliderProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?onChange <- requiredProps.OnChange
                obj?value <- requiredProps.Value
                obj
            )

        ofImport "RangeSlider" "@shopify/polaris" combinedProps []

