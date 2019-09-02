module Polaris.InlineError

open Fable.React
open Fable.Core.JsInterop
open Fable.Core

type RequiredInlineErrorProps = {
    fieldID: string
    message: ReactElement
}

let inline polarisInlineError (props : RequiredInlineErrorProps) : ReactElement =
    ofImport "InlineError" "@shopify/polaris" props []

