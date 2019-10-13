module Navigation
open Fable.React
open Fable.Polaris


let view _ _ =
    polarisAppProvider [] <|
        div [] [
            polarisNavigation {
                  Location = "/"
            } [] [
                polarisNavigationSection <| 
                    [
                        NavigationSectionProps.Items <|
                              [
                                    [
                                          SectionItem.Label "Dashboard"
                                          SectionItem.Icon <| polarisUserProvidedIcon "StoreStatusMajorMonotone"
                                          SectionItem.Url "#"
                                          SectionItem.Selected true
                                    ]                
                                    [ 
                                          SectionItem.Label "Users"
                                          SectionItem.Icon <| polarisUserProvidedIcon "CustomersMajorMonotone"
                                          SectionItem.Url "#"
                                              
                                          SectionItem.Selected false
                                    ]
                              ]
                        
                        NavigationSectionProps.Title "Management"
                  ]
            ]
        ]
