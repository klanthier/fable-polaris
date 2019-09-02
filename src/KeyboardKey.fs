module Polaris.KeyboardKey
open Fable.React

let inline polarisKeyboardKey (key : string) : ReactElement =
    ofImport "KeyboardKey" "@shopify/polaris" [] [ str key ]
