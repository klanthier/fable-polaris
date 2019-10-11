namespace Fable.Polaris

[<AutoOpen>]
module Frame =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    type [<RequireQualifiedAccess>] FrameProps =
        | GlobalRibbon of ReactElement
        | Navigation of ReactElement
        | ShowMobileNavigation of bool
        | SkipToContentTarget of JS.Object //TODO: Should be a React.RefObject
        | TopBar of ReactElement
        | OnNavigationDismiss of (unit -> unit)

    let inline polarisFrame (props : FrameProps list) (children : ReactElement list) : ReactElement =
        ofImport "Frame" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) children