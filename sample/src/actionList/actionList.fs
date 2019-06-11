module ActionList

open Polaris.AppProvider
open Polaris.ActionList
open Polaris.Shared

let view _ _ =
    appProvider [] <|
        actionList
            { Items = [|
                ActionListItemDescriptor( content = "Item1", icon = BundledIcon.Calendar )
                ActionListItemDescriptor( content = "Item2 - Selected", active = true, badge = ActionListItemDescriptorBadge("New", ItemDescriptorBadgeStatus.New) )
                ActionListItemDescriptor( content = "Item3", badge = ActionListItemDescriptorBadge("Non-new") )
                ActionListItemDescriptor( content = "Item4", disabled = true )
                ActionListItemDescriptor( content = "Item5", destructive = true )
            |]}
            []

