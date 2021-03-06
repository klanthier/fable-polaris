namespace Fable.Polaris

[<AutoOpen>]
module RadioButton =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] RequiredRadioButtonProps = {
        Label: ReactElement
        Checked: bool
        OnChange: (bool -> string -> unit)
    }

    type [<RequireQualifiedAccess>] RadioButtonProps =
        | AriaDescribedBy of string
        | Disabled of bool
        | HelpText of ReactElement
        | Id of string
        | LabelHidden of bool
        | Name of string
        | Value of string
        | OnBlur of (unit -> unit)
        | OnFocus of (unit -> unit)


    let inline polarisRadioButton (requiredProps: RequiredRadioButtonProps) (props : RadioButtonProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?onChange <- requiredProps.OnChange
                obj?``checked`` <- requiredProps.Checked
                obj?label <- requiredProps.Label
                obj
            )

        ofImport "RadioButton" "@shopify/polaris" combinedProps []

