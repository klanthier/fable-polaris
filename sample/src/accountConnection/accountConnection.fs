module AccountConnection

open Fable.React
open Polaris.AppProvider
open Polaris.AccountConnection

let view _ _ =
    appProvider [] <|
        accountConnection [
            Title <| str "Title"
            AccountName "Fable Polaris"
            Action <| Polaris.Shared.Action (content = "Disconnect", onAction = (fun x -> Browser.Dom.console.log ("Disconnect.")))
            AvatarUrl "https://raw.githubusercontent.com/klanthier/fable-polaris/master/fable-polaris.jpg"
            Connected true
            Details <| str "Detailed information about the user connection status.."
            TermsOfService <| str "Visit our TOS licensing at https://github.com/klanthier/fable-polaris/blob/master/LICENSE"
        ]


