namespace Fable.Polaris

[<AutoOpen>]
module TopBar =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] TopBarProps =
      | ContextControl of ReactElement
      | SearchField of ReactElement
      | SearchResults of ReactElement
      | SearchResultsVisible of bool
      | SecondaryMenu of ReactElement
      | SearchResultsOverlayVisible of bool
      | ShowNavigationToggle of bool
      | UserMenu of ReactElement
      | OnSearchResultsDismiss of (unit -> unit)
      | OnNavigationToggle of (unit -> unit)


    type [<RequireQualifiedAccess>] IconableAction = {
        content: string
        icon: Polaris.FunctionPolarisIcon option
        onAction: (unit -> unit) option
        disabled: bool
    }

    type [<RequireQualifiedAccess>] TopBarUserMenuActionsProps = {
        items: IconableAction array
    }

    type [<RequireQualifiedAccess>] TopBarUserMenuProps =
        | OnToggle of (unit -> unit)
        | Detail of string
        | Name of string
        | Initials of string
        | Open of bool
        | Avatar of string
        | Message of string
        | Actions of TopBarUserMenuActionsProps array

    let inline polarisTopBar (props : TopBarProps list): ReactElement =
        ofImport "TopBar" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []

    let inline polarisTopBarUserMenu (props : TopBarUserMenuProps list) : ReactElement =
        ofImport "TopBar.UserMenu" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []