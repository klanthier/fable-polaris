namespace Fable.Polaris

[<AutoOpen>]
module Navigation =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React
    open Fable.Polaris

    type [<RequireQualifiedAccess>] RequiredItemTypeProps = {
        Label: string
        Url: string
    }

    type [<RequireQualifiedAccess>] ItemTypeProps =
        | Icon of Polaris.FunctionPolarisIcon
    
    type ItemType = RequiredItemTypeProps * (ItemTypeProps list)

    let itemTypeConverterHelper (item: ItemType) =
        let requiredProps = fst item
        snd item
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?label <- requiredProps.Label
            obj?url <- requiredProps.Url
            obj
        )

    type [<RequireQualifiedAccess>] SectionType = 
        | Fill of bool
        | Title of string
        static member Items (items: ItemType list) =
            unbox ("items", Array.map itemTypeConverterHelper (items |> List.toArray))

    type [<RequireQualifiedAccess>] RequiredNavigationProps = {
        Location: string
    }

    let sectionConverterHelper (sectionType: SectionType list) =
        keyValueList CaseRules.LowerFirst sectionType

    type [<RequireQualifiedAccess>] NavigationProps =
        | ContextControl of ReactElement
        | OnDismiss of (unit -> unit)
        static member Sections (sections: SectionType list list) =
            unbox ("sections", Array.map sectionConverterHelper (sections |> List.toArray))

    let inline polarisNavigation (requiredProps : RequiredNavigationProps) (props : NavigationProps list) (children : ReactElement list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?location <- requiredProps.Location
                obj
            )
        ofImport "Navigation" "@shopify/polaris" combinedProps children

    
    type [<RequireQualifiedAccess>] RequiredSubNavigationSectionItemProps = {
        Label: string
        Url: string
    }
    
    type [<RequireQualifiedAccess>] SubNavigationSectionItemProps =
        | Disabled of bool
        | New of bool
        | OnClick of (unit -> unit)
    
    
    type SubNavigationSectionItem = RequiredSubNavigationSectionItemProps * (SubNavigationSectionItemProps list)

    let subNavigationItemConverterHelper (item: SubNavigationSectionItem) =
        let requiredProps = fst item
        snd item
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?label <- requiredProps.Label
            obj?url <- requiredProps.Url
            obj
        )

    type [<RequireQualifiedAccess>] SecondarySectionItemAction = {
        url: string
        accessibilityLabel: string
        icon: Polaris.FunctionPolarisIcon
    }

    type [<RequireQualifiedAccess>] SectionItem =
        | Url of string 
        | Matches of bool 
        | ExactMatch of bool 
        | MatchPaths of string array 
        | ExcludePaths of string array 
        | Badge of string 
        | Label of string 
        | Disabled of bool 
        | New of bool 
        | AccessibilityLabel of string 
        | Selected of bool 
        | OnClick of (unit -> unit)
        | SecondaryAction of SecondarySectionItemAction
        | Icon of Polaris.FunctionPolarisIcon
        static member SubNavigationItems (items: SubNavigationSectionItem list) =
             unbox ("subNavigationItems", Array.map subNavigationItemConverterHelper (items |> List.toArray))

    type [<RequireQualifiedAccess>] NavigationSectionAction = {
        accessibilityLabel : string
        onClick : (unit -> unit)
        icon: Polaris.FunctionPolarisIcon
    }

    type [<RequireQualifiedAccess>] NavigationSectionRollup = {
        after: int
        view: string
        hide: string
        activePath: string
    }
    
    type [<RequireQualifiedAccess>] NavigationSectionProps =
        | Title of string
        | Fill of bool
        | Separator of bool
        | Rollup of NavigationSectionRollup
        | Action of NavigationSectionAction
        | Icon of Polaris.FunctionPolarisIcon
        static member Items (items: SectionItem list list) =
            unbox ("items",  Array.map (keyValueList CaseRules.LowerFirst) (items |> List.toArray))

    let inline polarisNavigationSection (props : NavigationSectionProps list) : ReactElement =
        ofImport "Navigation.Section" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []