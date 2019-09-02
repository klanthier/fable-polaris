module Polaris.Toast


open Fable.React
open Polaris.Shared
open Fable.Core
open Fable.Core.JsInterop

type RequiredToastProps = {
  Content: string
  OnDismiss: (unit -> unit)
}

type ToastProps =
  | Duration of int
  | Error of bool
  static member Actions (actions: Action list) =
    let acs = Array.map actionConverterHelper (List.toArray actions)
    unbox ("actions", acs)


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
