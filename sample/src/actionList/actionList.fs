module ActionList

open Polaris.AppProvider
open Polaris.ActionList
open Fable.Polaris

let view _ _ =
    appProvider [] <|
        actionList
            { Items = [
                ({ Content = "Item1"; OnAction = fun _ -> ()}, [Icon BundledIcon.Calendar])
                ({ Content = "Item2 - Selected"; OnAction = fun _ -> ()}, [
                        ActionListItemDescriptorProps.Active true
                        ActionListItemDescriptorProps.Badge [
                            Content "New"
                            Status ItemDescriptorBadgeStatus.New
                        ]
                    ])
                ({ Content = "Item3"; OnAction = fun _ -> ()}, [
                        ActionListItemDescriptorProps.Active true
                        ActionListItemDescriptorProps.Badge [
                            Content "Non-new"
                        ]
                    ])
                ({ Content = "Item4"; OnAction = fun _ -> ()}, [ActionListItemDescriptorProps.Disabled true])
                ({ Content = "Item5"; OnAction = fun _ -> ()}, [ActionListItemDescriptorProps.Destructive true])
            ]}
            []

