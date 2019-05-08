namespace Polaris

open Fable.Core
open Fable.Core.JsInterop
open Fable.React

type [<RequireQualifiedAccess>] [<StringEnum>] ColorOption =
    | [<CompiledName "white">] White
    | [<CompiledName "teal">] Teal
    | [<CompiledName "inkLightest">] InkLightest

module AppProvider =
    type AppColorsTopBar = {
        background: string
    }
     
    type AppColors = {
        topBar: AppColorsTopBar
    }

    type AppLogo = {
        width: int
        topBarSource: string
        url: string
        accessibilityLabel: string option
        contextualSaveBarSource: string option
    }

    type AppTheme = {
        colors: AppColors option
        logo: AppLogo option
    }

    type AppProviderProps = {
        linkComponent: ReactElement option
        theme: AppTheme option
    }

    let inline appProvider (props : AppProviderProps) (elems : ReactElement list) : ReactElement =
        ofImport "AppProvider" "@shopify/polaris" props elems

module Avatar =
    type [<StringEnum>] [<RequireQualifiedAccess>] AvatarSize =
      | [<CompiledName "small">] Small
      | [<CompiledName "medium">] Medium
      | [<CompiledName "large">] Large

    type AvatarProps = {
        accessibilityLabel: string option
        customer: bool option
        initials: string option
        name: string option
        size: AvatarSize option
        source: string option
    }

    let inline avatar (props : AvatarProps): ReactElement =
        ofImport "Avatar" "@shopify/polaris" props []

module Page =
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

    let inline page (requiredProps : RequiredPageProps) (props : PageProps list) (children : ReactElement list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj -> obj?title <- requiredProps.Title; obj)

        ofImport "Page" "@shopify/polaris" combinedProps children

module Spinner =
    type [<RequireQualifiedAccess>] [<StringEnum>] SpinnerSize =
        | [<CompiledName "small">] Small
        | [<CompiledName "large">] Large

    type [<RequireQualifiedAccess>] SpinnerProps =
        | AccessibilityLabel of string
        | Color of ColorOption
        | Size of SpinnerSize

    let inline spinner (props : SpinnerProps list) : ReactElement =
        ofImport "Spinner" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []