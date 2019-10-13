namespace Fable.Polaris

[<AutoOpen>]
module Page =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    type [<RequireQualifiedAccess>] ActionGroupItemBadge = {
        content: string
        status: Badge.BadgeStatus
    }

    type [<RequireQualifiedAccess>] RequiredActionGroupProps = {
        Actions : Polaris.ActionListItemDescriptor list
        Title: string
    }
    type [<RequireQualifiedAccess>] ActionGroupProps =
        | Badge of ActionGroupItemBadge
        | Details of ReactElement
        | OnActionAnyItem of (unit -> unit)
        | Icon of Polaris.FunctionPolarisIcon
    
    type [<RequireQualifiedAccess>] ActionGroupItem = RequiredActionGroupProps * (ActionGroupProps list)

    let actionGroupItemConverterHelper (item: ActionGroupItem) =
        let requiredProps = fst item
        snd item
        |> keyValueList CaseRules.LowerFirst
        |> (fun obj ->
            obj?actions <- Array.map Polaris.actionListItemDescriptorUnboxHelper (List.toArray requiredProps.Actions)
            obj?title <- requiredProps.Title
            obj
        )



    type [<RequireQualifiedAccess>] PageBreadcrumbsAction = U2<Polaris.CallbackAction, Polaris.LinkAction>

    type [<RequireQualifiedAccess>] PageProps =
        | ForceRender of bool
        | FullWidth of bool
        | NarrowWidth of bool
        | Icon of Polaris.FunctionPolarisIcon
        | Subtitle of string
        | Thumbnail of ReactElement
        | Separator of bool
        | Title of string
        | TitleHidden of bool
        | TitleMetadata of ReactElement
        
        static member ActionGroups (items: ActionGroupItem list) =
            unbox ("actionGroups", Array.map actionGroupItemConverterHelper (items |> List.toArray))

        static member Breadcrumbs (actions: PageBreadcrumbsAction list) =
            unbox ("breadcrumbs",
                Array.map 
                    <| (fun x -> 
                        match x with
                            | U2.Case1 callbackAction ->
                                Polaris.CallbackActionConverterHelper callbackAction
                            | U2.Case2 linkAction ->
                                Polaris.LinkActionConverterHelper linkAction
                    ) 
                    <| (actions |> List.toArray)
            )

        static member Pagination (pagination: Polaris.PaginationDescriptor list) =
            unbox ("pagination", keyValueList CaseRules.LowerFirst pagination)

        static member PrimaryAction (action: Polaris.PrimaryAction) =
            unbox ("primaryAction", Polaris.primaryActionConverterHelper action)

        static member SecondaryActions (actions: Polaris.ComplexAction list) =
            unbox ("secondaryActions",
                List.map Polaris.complexActionConverterHelper actions
                |> List.toArray
            )

    let inline polarisPage (props : PageProps list) (children : ReactElement list) : ReactElement =
        ofImport "Page" "@shopify/polaris" (props |> keyValueList CaseRules.LowerFirst) children