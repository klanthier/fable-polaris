namespace Fable.Polaris

module Collapsible =

    open Fable.Core.JsInterop
    open Fable.React

    type CollapsibleProps = {
        Id: string
        Open: bool
    }

    let inline polarisCollapsible (requiredProps : CollapsibleProps) (elems : ReactElement list): ReactElement =
        let finalProps =
            []
                |> (fun obj ->
                    obj?id <- requiredProps.Id
                    obj?``open`` <- requiredProps.Open
                )

        ofImport "Collapsible" "@shopify/polaris" finalProps elems