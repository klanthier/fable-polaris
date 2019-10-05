namespace Fable.Polaris

module KeyboardKey =

    open Fable.React

    let inline polarisKeyboardKey (key : string) : ReactElement =
        ofImport "KeyboardKey" "@shopify/polaris" [] [ str key ]
