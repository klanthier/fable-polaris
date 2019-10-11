namespace Fable.Polaris

[<AutoOpen>]
module AccountConnection =

  open Fable.Polaris
  open Fable.React
  open Fable.Core
  open Fable.Core.JsInterop
  
  type [<RequireQualifiedAccess>] AccountConnectionProps =
    | AccountName of string
    | AvatarUrl of string
    | Connected of bool
    | Details of ReactElement
    | TermsOfService of ReactElement
    | Title of ReactElement
    static member Action (action: Polaris.Action) =
      Polaris.actionUnboxHelper "action" action

  let inline polarisAccountConnection (props : AccountConnectionProps list) : ReactElement =
      ofImport "AccountConnection" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []
