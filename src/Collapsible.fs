module Polaris.Collapsible


open Fable.React

type CollapsibleProps = {
    id: string
    ``open``: bool
}

let inline polarisCollapsible (props : CollapsibleProps) (elems : ReactElement list): ReactElement =
    ofImport "Collapsible" "@shopify/polaris" props elems