module Autocomplete

open Fable.React
open Polaris.AppProvider
open Polaris.Autocomplete
open Fable.Polaris

let view _ _ =
    appProvider [] <|
        div [] [
            autoComplete {
                Selected = [|"Label"|]
                OnSelect = (fun x -> ())
                TextField = div [] [str "abc"]
                Options = [
                    ({Label = str "Label"; Value = "LabelValue"}, [])
                    ({Label = str "Label2"; Value = "LabelValue2"}, [])
                ]
            } []

            autoComplete {
                Selected = [|""|]
                OnSelect = (fun x -> ())
                TextField = div [] [str "abc"]
                Options = [
                    ({Label = str "Label"; Value = "LabelValue"}, [])
                ]
            } []
        ]
