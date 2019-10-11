namespace Fable.Polaris

[<AutoOpen>]
module DatePicker =

    open System
    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] SelectedDateOrRange = U2<DateTime, PolarisDateHelpers.Range>

    type [<RequireQualifiedAccess>] RequiredDatePickerProps = {
        Month: PolarisDateHelpers.Months
        Year: PolarisDateHelpers.Year
    }

    type [<RequireQualifiedAccess>] DatePickerProps =
        | AllowRange of bool
        | DisableDatesAfter of DateTime
        | DisableDatesBefore of DateTime
        | Id of string
        | MultiMonth of bool
        | Selected of SelectedDateOrRange
        | WeekStartsOn of PolarisDateHelpers.Weekdays
        | OnChange of (PolarisDateHelpers.Range -> unit)
        | OnMonthChange of (PolarisDateHelpers.Months -> PolarisDateHelpers.Year -> unit)


    let inline polarisDatePicker (requiredProps: RequiredDatePickerProps) (props : DatePickerProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?month <- requiredProps.Month
                obj?year <- requiredProps.Year
                obj
            )

        ofImport "DatePicker" "@shopify/polaris" combinedProps []
