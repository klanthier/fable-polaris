namespace Fable.Polaris

module Toast =


  open Fable.React
  open Fable.Polaris
  open Fable.Core
  open Fable.Core.JsInterop

  type RequiredToastProps = {
    Content: string
    OnDismiss: (unit -> unit)
  }

  type ToastProps =
    | Duration of int
    | Error of bool
    static member Action (action: Polaris.Action) =
      unbox ("action", Polaris.actionConverterHelper action)


  let inline polarisToast requiredProps (props : ToastProps list) : ReactElement =
      let combinedProps =
        props
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?content <- requiredProps.Content
            obj?onDismiss <- requiredProps.OnDismiss
            obj
        )
      ofImport "Toast" "@shopify/polaris" combinedProps []
