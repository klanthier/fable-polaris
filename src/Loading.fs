namespace Fable.Polaris

module Loading =

    open Fable.React

    let inline polarisLoading() : ReactElement =
        ofImport "Loading" "@shopify/polaris" [] []
