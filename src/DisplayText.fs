namespace Fable.Polaris

[<AutoOpen>]
module DisplayText =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris
    
    type [<RequireQualifiedAccess>] DisplayTextProps =
        | Element of Polaris.ElementNameSelection
        | Size of Polaris.DisplayTextSize

    let inline polarisDisplayText (props : DisplayTextProps list) (elems : ReactElement list) : ReactElement =
        ofImport "DisplayText" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems