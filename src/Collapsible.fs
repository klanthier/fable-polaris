namespace Fable.Polaris

[<AutoOpen>]
module Collapsible =

    open Fable.React
    open Fable.Core.JsInterop

    type [<RequireQualifiedAccess>] CollapsibleProps = {
        Id: string
        Open: bool
    }

    let inline polarisCollapsible (requiredProps : CollapsibleProps) (elems : ReactElement list): ReactElement =
        let finalProps =
            []
                |> (fun obj ->
                    obj?id <- requiredProps.Id
                    obj?``open`` <- requiredProps.Open
                    obj
                )

        ofImport "Collapsible" "@shopify/polaris" finalProps elems