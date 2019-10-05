namespace Fable.Polaris

module FooterHelp =

    open Fable.React

    let inline polarisFooterHelp (elems : ReactElement list) : ReactElement =
        ofImport "FooterHelp" "@shopify/polaris" [] elems