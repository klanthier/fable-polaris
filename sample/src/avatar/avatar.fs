module Avatar

open Fable.React
open Polaris.AppProvider
open Polaris.Avatar
open Polaris.Stack

let view _ _ =

    appProvider [] <|
      stack [ Spacing StackSpacing.ExtraLoose] [

        div [] [
          h1 [] [str "Example 1"]
          avatar [
            AccessibilityLabel "Accessiblity Label String"
            Customer true
            Initials "FP"
            Name "Fable Polaris"
            Size AvatarSize.Medium
          ]
        ]

        div [] [
          h1 [] [str "Example 2"]
          avatar [
            AccessibilityLabel "Accessiblity Label String"
            Customer true
            Initials "FP"
            Name "Fable Polaris"
            Size AvatarSize.Medium
            Source "https://raw.githubusercontent.com/klanthier/fable-polaris/master/fable-polaris.jpg"
          ]
        ]

        div [] [
          h1 [] [str "Example 3"]
          avatar [
            AccessibilityLabel "Accessiblity Label String"
            Customer false
            Initials "FP"
            Name "Fable Polaris"
            Size AvatarSize.Medium
          ]
        ]


  ]

