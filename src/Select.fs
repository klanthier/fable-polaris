namespace Fable.Polaris

module Select =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type StrictOption = {
        disabled: bool option
        label: string
        value: string
    }

    type SelectGroup = {
        options: U2<string, StrictOption> array
        title: string
    }

    type SelectOption = U3<string, StrictOption, SelectGroup>


    type RequiredSelectProps = {
      Label: string
      Options: SelectOption array
      Value: string
      OnChange: (string -> string -> unit)
    }
    type SelectProps =
      | Disabled of bool
      | Error of ReactElement
      | HelpText of ReactElement
      | Id of string
      | LabelHidden of bool
      | LabelInline of bool
      | Name of string
      | Placeholder of string
      | OnBlur of (unit -> unit)
      | OnFocus of (unit -> unit)
      static member LabelAction (action: Action) =
        actionUnboxHelper "labelAction" action

    let inline polarisSelect (requiredProps: RequiredSelectProps) (props : SelectProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?label <- requiredProps.Label
                obj?options <- requiredProps.Options
                obj?value <- requiredProps.Value
                obj?onChange <- System.Func<_,_,_> requiredProps.OnChange
                obj
            )
        ofImport "Select" "@shopify/polaris" combinedProps []