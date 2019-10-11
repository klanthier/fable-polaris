namespace Fable.Polaris

[<AutoOpen>]
module ResourceList =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    ////////////////////////////////////////
    ///          RESOURCE-LIST           ///
    ////////////////////////////////////////

    type [<RequireQualifiedAccess>] ResourceListResourceName = {
        singular : string
        plural : string
    }

    type [<RequireQualifiedAccess>] ResourceListActionListSection =
        | Title of string
        static member Items (items: Polaris.ActionListItemDescriptor list) =
            Polaris.actionListItemsDescriptorUnboxHelper "items" items

    type [<RequireQualifiedAccess>] ResourceListSelectedItems = U2<Polaris.SelectAllItems, string array>
    type [<RequireQualifiedAccess>] ResourceListSortOption = U2<string, Polaris.StrictOption>
    let resourceListSortOptionsConverterHelper options =
        List.map (
            fun opt ->
                match opt with
                    | U2.Case1 s ->
                        box s
                    | U2.Case2 strictOption ->
                        Polaris.strictOptionConverterHelper strictOption
        ) options
        |> List.toArray


    type [<RequireQualifiedAccess>] BulkAction =
      U2<ResourceListActionListSection list, Polaris.DisableableAction> /// TODO: WHOA CAREFULL USING DAAAS


    type [<RequireQualifiedAccess>] RequiredResourceListProps<'t> = {
        Items: 't list
        RenderItem: ('t -> string -> int -> ReactElement)
        IdForItem: ('t -> int -> string)
    }
    type [<RequireQualifiedAccess>] ResourceListProps<'t> =
        | AlternateTool of ReactElement
        | FilterControl of ReactElement
        | HasMoreItems of bool
        | Loading of bool
        | ResourceName of ResourceListResourceName
        | Selectable of bool
        | SelectedItems of ResourceListSelectedItems
        | ShowHeader of bool
        | SortValue of string
        | OnSelectionChange of (ResourceListSelectedItems -> unit)
        | OnSortChange of (string -> string -> unit)
        | ResolveItemId of ('t -> string)
        static member SortOptions (options: ResourceListSortOption list) =
            unbox ("sortOptions",
                resourceListSortOptionsConverterHelper options
            )

        static member PromotedBulkActions (actions: Polaris.DisableableAction list) =
            unbox ("promotedBulkActions",
                List.map Polaris.disableableActionConverterHelper actions
                |> List.toArray
            )

        static member BulkActions (bulkActions: BulkAction list) =
            unbox ("bulkActions",
                List.map (
                    fun bAction ->
                        match bAction with
                            | U2.Case1 section ->
                                keyValueList CaseRules.LowerFirst section
                            | U2.Case2 bulkAction ->
                                Polaris.disableableActionConverterHelper bulkAction
                ) bulkActions
                |> List.toArray
            )

    let inline polarisResourceList (requiredProps: RequiredResourceListProps<'t>) (props : ResourceListProps<'t> list) : ReactElement =
        let combinedProps =
          props
          |> keyValueList CaseRules.LowerFirst
          |> (fun obj ->
              obj?idForItem <- System.Func<_,_,_> requiredProps.IdForItem
              obj?renderItem <- System.Func<_, _, _, _> requiredProps.RenderItem
              obj?items <- List.toArray requiredProps.Items
              obj
          )
        ofImport "ResourceList" "@shopify/polaris" combinedProps []

    ////////////////////////////////////////
    ///       RESOURCE-LIST-FILTER       ///
    ////////////////////////////////////////

    type [<RequireQualifiedAccess>] FilterType = Select = 0 | TextField = 1 | DateSelector = 2

    type [<RequireQualifiedAccess>] AppliedFilter = {
        key: string
        value: string
        label: string option
    }

    type [<RequireQualifiedAccess>] Operator = {
        key: string
        optionLabel: string
        filterLabel: string option
    }

    type [<RequireQualifiedAccess>] OperatorText = U2<string, Operator array>


    /// Filter Select ///
    type [<RequireQualifiedAccess>] RequiredFilterSelectProps = {
        Label: string
        Key: string
        Options: ResourceListSortOption list
    }

    type [<RequireQualifiedAccess>] FilterSelectProps =
        | OperatorText of OperatorText

    type FilterSelect = {
        required: RequiredFilterSelectProps
        optional: FilterSelectProps list
    }
    ///////////////////////


    /// Filter TEXTFIELD ///
    type [<RequireQualifiedAccess>] RequiredFilterTextFieldProps = {
        Label: string
        Key: string
    }
    type [<RequireQualifiedAccess>] FilterTextFieldProps =
        | OperatorText of U2<string, Operator array>
        | TextFieldType of Polaris.TextFieldType

    type FilterTextField = {
        required: RequiredFilterTextFieldProps
        optional: FilterTextFieldProps list
    }
    ///////////////////////


    /// Filter DATESELECTOR ///
    type [<RequireQualifiedAccess>] RequiredFilterDateSelectorProps = {
        Label: string
        Key: string
        MinKey: string
        MaxKey: string
    }

    type [<RequireQualifiedAccess>] FilterDateSelectorProps =
        | OperatorText of U2<string, Operator array>
        | DateOptionType of Polaris.DateOptionsTypes

    type FilterDateSelector = {
        required: RequiredFilterDateSelectorProps
        optional: FilterDateSelectorProps list
    }
    ///////////////////////

    type [<RequireQualifiedAccess>] ResourceListFilter = U3<FilterSelect, FilterTextField, FilterDateSelector>

    let filterUnboxerHelper (filter: ResourceListFilter) =
        match filter with
            | U3.Case1 componentProps ->                
                componentProps.optional
                |> keyValueList CaseRules.LowerFirst
                |> (fun obj ->
                  obj?key <- componentProps.required.Key
                  obj?label <- componentProps.required.Label
                  obj?``type`` <- FilterType.Select
                  obj?options <- resourceListSortOptionsConverterHelper <| componentProps.required.Options
                  obj
              )
            | U3.Case2 componentProps ->
                componentProps.optional
                |> keyValueList CaseRules.LowerFirst
                |> (fun obj ->
                  obj?key <- componentProps.required.Key
                  obj?``type`` <- FilterType.TextField
                  obj?label <- componentProps.required.Label
                  obj
                )
            | U3.Case3 componentProps ->
                componentProps.optional
                |> keyValueList CaseRules.LowerFirst
                |> (fun obj ->
                  obj?key <- componentProps.required.Key
                  obj?``type`` <- FilterType.DateSelector
                  obj?label <- componentProps.required.Label
                  obj?maxKey <- componentProps.required.MaxKey
                  obj?minKey <- componentProps.required.MinKey
                  obj
                )

    type [<RequireQualifiedAccess>] RequiredResourceListFilterControlProps = {
        AppliedFilters: AppliedFilter array
        Filters: ResourceListFilter list
        OnSearchChange: (string -> string -> unit)
    }

    type [<RequireQualifiedAccess>] ResourceListFilterControlProps =
        | SearchValue of string
        | Focused of bool
        | Placeholder of string
        | OnSearchBlur of (unit -> unit)
        | OnFiltersChange of (AppliedFilter array -> unit)
        static member AdditionalAction (additionalAction: Polaris.ComplexAction) =
            unbox ("additionalAction", Polaris.complexActionConverterHelper additionalAction)

    let inline polarisResourceListFilterControl (requiredProps: RequiredResourceListFilterControlProps) (props : ResourceListFilterControlProps list) : ReactElement =
        let combinedProps =
          props
          |> keyValueList CaseRules.LowerFirst
          |> (fun obj ->
              obj?appliedFilters <- requiredProps.AppliedFilters
              obj?filters <-
                List.map filterUnboxerHelper requiredProps.Filters
                |> List.toArray
              obj?onSearchChange <- System.Func<_,_,_> requiredProps.OnSearchChange
              obj
          )
        ofImport "ResourceList.FilterControl" "@shopify/polaris" combinedProps []