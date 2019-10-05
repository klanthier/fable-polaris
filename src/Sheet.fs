namespace Fable.Polaris

module Sheet =

    open Fable.Core.JsInterop
    open Fable.Core
    open Fable.React

    type RequiredSheetProps = {
        Open: bool
        OnClose: (unit -> unit)
    }

    type SheetProps =
        | OnEntered of (unit -> unit)
        | OnExit of (unit -> unit)

    let inline polarisSheet (requiredProps : RequiredSheetProps) (props: SheetProps list) (elems : ReactElement list): ReactElement =
        let finalProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?``open`` <- requiredProps.Open
                obj?onClose <- requiredProps.OnClose
            )

        ofImport "Sheet" "@shopify/polaris" finalProps elems