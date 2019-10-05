namespace Fable.Polaris

module TopBar =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type TopBarProps =
      | ContextControl of ReactElement
      | SearchField of ReactElement
      | SearchResults of ReactElement
      | SearchResultsVisible of bool
      | SecondaryMenu of ReactElement
      | ShowNavigationToggle of bool
      | UserMenu of ReactElement
      | OnSearchResultsDismiss of (unit -> unit)
      | OnNavigationToggle of (unit -> unit)


    type IconableAction = {
        content: string
        icon: string option
    }

    type TopBarUserMenuActionsProps = {
        items: IconableAction array
    }

    type TopBarUserMenuProps =
        | OnToggle of (unit -> unit) option
        | Detail of string
        | Name of string
        | Initials of string
        | Open of bool
        | Avatar of string
        | Message of string
        | Actions of TopBarUserMenuActionsProps

    let inline polarisTopBar (props : TopBarProps list): ReactElement =
        ofImport "TopBar" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []

    let inline polarisTopBarUserMenu (props : TopBarUserMenuProps list) : ReactElement =
        ofImport "TopBar.UserMenu" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []