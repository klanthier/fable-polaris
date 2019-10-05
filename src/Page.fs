namespace Fable.Polaris

module Page =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    type ActionGroupDescriptor = ActionGroupDescriptor
    type PaginationDescriptor = PaginationDescriptor
    type CallbackAction = unit -> unit
    type LinkAction = LinkAction
    type SecondaryAction = SecondaryAction

    type PrimaryActionProps = PrimaryActionProps

    [<RequireQualifiedAccess>]
    type PageProps =
        | ActionGroups of ActionGroupDescriptor list
        | Breadcrumbs of U2<CallbackAction, LinkAction> list
        | ForceRender of bool
        | FullWidth of bool
        | Icon of string
        | Pagination of PaginationDescriptor
        | PrimaryAction of PrimaryActionProps
        | SecondaryActions of SecondaryAction list
        | Separator of bool
        | TitleHidden of bool
        | TitleMetadata of ReactElement

    type RequiredPageProps = {
        Title : string
    }

    let inline polarisPage (requiredProps : RequiredPageProps) (props : PageProps list) (children : ReactElement list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj -> obj?title <- requiredProps.Title; obj)

        ofImport "Page" "@shopify/polaris" combinedProps children