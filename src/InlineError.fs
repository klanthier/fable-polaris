namespace Fable.Polaris

[<AutoOpen>]
module InlineError =

    open Fable.React

    type [<RequireQualifiedAccess>] RequiredInlineErrorProps = {
        fieldID: string
        message: ReactElement
    }

    let inline polarisInlineError (props : RequiredInlineErrorProps) : ReactElement =
        ofImport "InlineError" "@shopify/polaris" props []

