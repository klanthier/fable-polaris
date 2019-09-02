module Polaris.ResourceList

open Fable.React
open Fable.Core
open Fable.Core.JsInterop
open Polaris.Shared

////////////////////////////////////////
///          RESOURCE-LIST           ///
////////////////////////////////////////

type ResourceListResourceName = {
    singular : string
    plural : string
}

type ResourceListActionListSection =
    | Title of string
    static member Items (items: ActionListItemDescriptor list) =
        actionListItemsDescriptorUnboxHelper "items" items

type ResourceListSelectedItems = U2<SelectAllItems, string array>
type ResourceListSortOption = U2<string, StrictOption>
let resourceListSortOptionsConverterHelper options =
    List.map (
        fun opt ->
            match opt with
                | U2.Case1 s ->
                    box s
                | U2.Case2 strictOption ->
                    strictOptionConverterHelper strictOption
    ) options
    |> List.toArray


type BulkAction =
  U2<ResourceListActionListSection list, DisableableAction> /// TODO: WHOA CAREFULL USING DAAAS


type RequiredResourceListProps<'t> = {
    Items: 't list
    RenderItem: ('t -> string -> ReactElement)
    IdForItem: ('t -> int -> string)
}
type ResourceListProps<'t> =
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

    static member PromotedBulkActions (actions: DisableableAction list) =
        unbox ("promotedBulkActions",
            List.map disableableActionConverterHelper actions
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
                            disableableActionConverterHelper bulkAction
            ) bulkActions
            |> List.toArray
        )

let inline polarisResourceList (requiredProps: RequiredResourceListProps<'t>) (props : ResourceListProps<'t> list) : ReactElement =
    let combinedProps =
      props
      |> keyValueList CaseRules.LowerFirst
      |> (fun obj ->
          obj?idForItem <- requiredProps.IdForItem
          obj?renderItem <- requiredProps.RenderItem
          obj?items <- requiredProps.Items
          obj
      )
    ofImport "ResourceList" "@shopify/polaris" combinedProps []


////////////////////////////////////////
///        RESOURCE-LIST-ITEM        ///
////////////////////////////////////////

type RequiredResourceListItemProps = {
    Id : string
}

type ResourceListItemProps =
  | AccessibilityLabel of string
  | AriaControls of string
  | AriaExpanded of bool
  | Media of ReactElement
  | PersistActions of bool
  | OnClick of (string -> unit)
  | Url of string
  static member ShortcutActions (actions: DisableableAction list) =
    unbox ("shortcutActions",
        List.map disableableActionConverterHelper actions
            |> List.toArray
    )


let inline polarisResourceListItem (requiredProps : RequiredResourceListItemProps) (props : ResourceListItemProps list) (elems : ReactElement list) : ReactElement =
    let combinedProps =
      props
      |> keyValueList CaseRules.LowerFirst
      |> (fun obj ->
          obj?id <- requiredProps.Id
          obj
      )
    ofImport "ResourceList.Item" "@shopify/polaris" combinedProps elems


////////////////////////////////////////
///       RESOURCE-LIST-FILTER       ///
////////////////////////////////////////

type FilterType = Select = 0 | TextField = 1 | DateSelector = 2

type AppliedFilter = {
    key: string
    value: string
    label: string option
}

type Operator = {
    key: string
    optionLabel: string
    filterLabel: string option
}

type OperatorText = U2<string, Operator array>


/// Filter Select ///
type RequiredFilterSelectProps = {
    Label: string
    Key: string
    Options: ResourceListSortOption list
}

type FilterSelectProps =
    | OperatorText of OperatorText

type FilterSelect = RequiredFilterSelectProps * FilterSelectProps list
///////////////////////


/// Filter TEXTFIELD ///
type RequiredFilterTextFieldProps = {
    Label: string
    Key: string
}
type FilterTextFieldProps =
    | OperatorText of U2<string, Operator array>
    | TextFieldType of TextFieldType

type FilterTextField = RequiredFilterTextFieldProps * FilterTextFieldProps list
///////////////////////


/// Filter DATESELECTOR ///
type RequiredFilterDateSelectorProps = {
    Label: string
    Key: string
    MinKey: string
    MaxKey: string
}

type FilterDateSelectorProps =
    | OperatorText of U2<string, Operator array>
    | DateOptionType of DateOptionsTypes

type FilterDateSelector = RequiredFilterDateSelectorProps * FilterDateSelectorProps list
///////////////////////

type Filter = U3<FilterSelect, FilterTextField, FilterDateSelector>
let filterUnboxerHelper (filter: Filter) =
    match filter with
        | U3.Case1 (reqSelectProps, selectProps) ->
            selectProps
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
              obj?key <- reqSelectProps.Key
              obj?label <- reqSelectProps.Label
              obj?``type`` <- FilterType.Select
              obj?key <- resourceListSortOptionsConverterHelper <| reqSelectProps.Options
              obj
          )
        | U3.Case2 (reqTextProps, textProps) ->
            textProps
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
              obj?key <- reqTextProps.Key
              obj?``type`` <- FilterType.TextField
              obj?label <- reqTextProps.Label
              obj
            )
        | U3.Case3 (reqDateProps, dateProps) ->
            dateProps
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
              obj?key <- reqDateProps.Key
              obj?``type`` <- FilterType.DateSelector
              obj?label <- reqDateProps.Label
              obj?maxKey <- reqDateProps.MaxKey
              obj?minKey <- reqDateProps.MinKey
              obj
            )

type RequiredResourceListFilterControlProps = {
    AppliedFilters: AppliedFilter array
    Filters: Filter list
    OnSearchChange: (string -> string -> unit)
}

type ResourceListFilterControlProps =
    | SearchValue of string
    | Focused of bool
    | OnSearchBlur of (unit -> unit)
    | OnFiltersChange of (AppliedFilter array -> unit)
    static member AdditionalAction (additionalAction: ComplexAction) =
        unbox ("additionalAction", complexActionConverterHelper additionalAction)

let inline polarisResourceListFilterControl (requiredProps: RequiredResourceListFilterControlProps) (props : ResourceListFilterControlProps list) : ReactElement =
    let combinedProps =
      props
      |> keyValueList CaseRules.LowerFirst
      |> (fun obj ->
          obj?appliedFilters <- requiredProps.AppliedFilters
          obj?filters <-
            List.map filterUnboxerHelper requiredProps.Filters
            |> List.toArray
          obj?onSearchChange <- requiredProps.OnSearchChange
          obj
      )
    ofImport "ResourceList.FilterControl" "@shopify/polaris" combinedProps []