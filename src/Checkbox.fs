namespace Fable.Polaris

[<AutoOpen>]
module CheckBox =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<StringEnum>] [<RequireQualifiedAccess>] CheckBoxCheckStatuses =
        | [<CompiledName "indeterminate">] Indeterminate

    type [<RequireQualifiedAccess>] CheckedStatus = U2<bool, CheckBoxCheckStatuses>

    type [<RequireQualifiedAccess>] RequiredCheckBoxProps = {
        Checked: CheckedStatus
        Label: ReactElement
    }

    type [<RequireQualifiedAccess>] CheckBoxProps =
        | AriaDescribedBy of string
        | Disabled of bool
        | Error of ReactElement
        | HelpText of ReactElement
        | Id of string
        | LabelHidden of bool
        | Name of string
        | Value of string
        | OnBlur of (unit -> unit)
        | OnChange of (bool -> string -> unit)
        | OnFocus of (unit -> unit)

    let inline polarisCheckBox (requiredProps: RequiredCheckBoxProps) (props : CheckBoxProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?``checked`` <- requiredProps.Checked
                obj?label <- requiredProps.Label
                obj
            )

        ofImport "Checkbox" "@shopify/polaris" combinedProps []
