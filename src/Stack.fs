namespace Fable.Polaris

[<AutoOpen>]
module Stack =

    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.React

    type [<StringEnum>] [<RequireQualifiedAccess>] StackSpacing =
        | [<CompiledName "extraTight">] ExtraTight
        | [<CompiledName "tight">] Tight
        | [<CompiledName "loose">] Loose
        | [<CompiledName "extraLoose">] ExtraLoose
        | [<CompiledName "none">] None

    type [<StringEnum>] [<RequireQualifiedAccess>] StackAlignment =
        | [<CompiledName "leading">] Leading
        | [<CompiledName "trailing">] Trailing
        | [<CompiledName "center">] Center
        | [<CompiledName "fill">] Fill
        | [<CompiledName "baseline">] Baseline


    type [<StringEnum>] [<RequireQualifiedAccess>] StackDistribution =
        | [<CompiledName "equalSpacing">] EqualSpacing
        | [<CompiledName "leading">] Leading
        | [<CompiledName "trailing">] Trailing
        | [<CompiledName "center">] Center
        | [<CompiledName "fill">] Fill
        | [<CompiledName "fillEvenly">] FillEvenly

    type [<RequireQualifiedAccess>] StackProps =
        | Alignment of StackAlignment
        | Distribution of StackDistribution
        | Spacing of StackSpacing
        | Vertical of bool
        | Wrap of bool

    type [<RequireQualifiedAccess>] StackItemProps =
        | Fill of bool

    let inline polarisStack (props : StackProps list) (children : ReactElement list) : ReactElement =
        ofImport "Stack" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) children

    let inline polarisStackItem (props : StackItemProps list) (children : ReactElement list) : ReactElement =
        ofImport "Stack.Item" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) children