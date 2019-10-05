namespace Fable.Polaris

module InlineError =

    open Fable.React

    type RequiredInlineErrorProps = {
        fieldID: string
        message: ReactElement
    }

    let inline polarisInlineError (props : RequiredInlineErrorProps) : ReactElement =
        ofImport "InlineError" "@shopify/polaris" props []

