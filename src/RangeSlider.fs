namespace Fable.Polaris

module RangeSlider =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type DualValue = float * float
    type RangeValue = U2<float, DualValue>

    type RequiredRangeSliderProps = {
        OnChange: RangeValue -> string -> unit
        Value: RangeValue
    }
    type RangeSliderProps =
        | Disabled of bool
        | Error of ReactElement
        | HelpText of ReactElement
        | Id of string
        | Label of string
        | LabelHidden of bool
        | Max of float
        | Min of float
        | Output of bool
        | Prefix of ReactElement
        | Step of float
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

