namespace Fable.Polaris

[<AutoOpen>]
module Caption =

    open Fable.React

    let inline polarisCaption (elems: ReactElement list): ReactElement =
        ofImport "Caption" "@shopify/polaris" [] elems
