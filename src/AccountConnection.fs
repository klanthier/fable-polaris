module Polaris.AccountConnection

open Polaris.Shared
open Fable.React
open Fable.Core
open Fable.Core.JsInterop

type [<StringEnum>] [<RequireQualifiedAccess>] TextSpacing =
    |  [<CompiledName "loose">] Loose
    |  [<CompiledName "tight">] Tight

type AccountConnectionProps =
  | AccountName of string
  | AvatarUrl of string
  | Connected of bool
  | Details of ReactElement
  | TermsOfService of ReactElement
  | Title of ReactElement
  static member Action (action: Action) =
    actionUnboxHelper "action" action

let inline accountConnection (props : AccountConnectionProps list) : ReactElement =
    ofImport "AccountConnection" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []
