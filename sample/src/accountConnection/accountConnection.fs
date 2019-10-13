module AccountConnection

open Fable.React
open Fable.Polaris

let view _ _ =
    polarisAppProvider [] <|
    div [] [
        polarisAccountConnection [
            AccountConnectionProps.Title <| str "Title"
            AccountConnectionProps.AccountName "Fable Polaris"
            AccountConnectionProps.Action <|
                {required = {
                    Content = "Disconnect"
                    OnAction = (fun _ -> Browser.Dom.console.log ("Disconnect."))
                }; optional = []}
            AccountConnectionProps.AvatarUrl "https://raw.githubusercontent.com/klanthier/fable-polaris/master/fable-polaris.jpg"
            AccountConnectionProps.Connected true
            AccountConnectionProps.Details <| str "Detailed information about the user connection status.."
            AccountConnectionProps.TermsOfService <| str "Visit our TOS licensing at https://github.com/klanthier/fable-polaris/blob/master/LICENSE"
        ]
    ]


