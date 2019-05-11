module Polaris

open Fable.Core

type [<RequireQualifiedAccess>] [<StringEnum>] ColorOption =
    | [<CompiledName "white">] White
    | [<CompiledName "teal">] Teal
    | [<CompiledName "inkLightest">] InkLightest

