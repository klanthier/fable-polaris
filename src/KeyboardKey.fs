namespace Fable.Polaris

[<AutoOpen>]
module KeyboardKey =

    open Fable.React

    let inline polarisKeyboardKey (key : string) : ReactElement =
        ofImport "KeyboardKey" "@shopify/polaris" [] [ str key ]
