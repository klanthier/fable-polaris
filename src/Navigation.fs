namespace Fable.Polaris

module Navigation =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React
    open Fable.Polaris

    type ItemType = {
        icon: Polaris.BundledIcon option
        label: string
        url: string
    }

    type SectionType = 
        abstract fill : bool with set
        abstract items : ResizeArray<ItemType> with set
        abstract title : string with set

    type SubNavigationSectionItem = {
        label: string
        url: string
        disabled: bool
    }

    type NavigationSectionItem =
        abstract label : string with set
        abstract url : string with set
        abstract matches : bool with set
        abstract exactMatch : bool with set
        abstract matchPaths : ResizeArray<string> with set
        abstract excludePaths : ResizeArray<string> with set
        abstract icon : Polaris.BundledIcon with set
        abstract badge : string with set
        abstract disabled : bool with set
        abstract ``new``: bool with set
        abstract accessibilityLabel : string with set
        abstract selected : bool with set
        abstract subNavigationItems : ResizeArray<SubNavigationSectionItem> with set
        abstract onClick : (unit -> unit) with set

    type NavigationSectionAction =
        abstract icon : Polaris.BundledIcon with set
        abstract accessibilityLabel : string with set
        abstract onClick : (unit -> unit) with set

    type NavigationSectionRollup = {
        after: int
        view: string
        hide: string
        activePath: string
    }

    type RequiredNavigationProps = {
        Location: string
    }

    type NavigationProps =
        | ContextControl of ReactElement
        | Sections of SectionType list
        | OnDismiss of (unit -> unit)

    type NavigationSectionProps =
        | Items of ResizeArray<NavigationSectionItem>
        | Icon of Polaris.BundledIcon
        | Title of string
        | Fill of bool
        | Rollup of NavigationSectionRollup
        | Action of NavigationSectionAction
        | Separator of bool

    let inline navigation (requiredProps : RequiredNavigationProps) (props : NavigationProps list) (children : ReactElement list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?location <- requiredProps.Location
                obj
            )
        ofImport "Navigation" "@shopify/polaris" combinedProps children

    let inline navigationSection (props : NavigationSectionProps list) (children : ReactElement list) : ReactElement =
        ofImport "Navigation.Section" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) children