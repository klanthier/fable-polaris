namespace Fable.Polaris

[<AutoOpen>]
module VisuallyHidden =
    open Fable.React

    let inline polarisVisuallyHidden (elems: ReactElement list): ReactElement =
        ofImport "VisuallyHidden" "@shopify/polaris" [] elems