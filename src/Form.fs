namespace Fable.Polaris

[<AutoOpen>]
module Form =
    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop

    type [<StringEnum>] [<RequireQualifiedAccess>] FormEncodingType =
        | [<CompiledName "application/x-www-form-urlencoded">] UrlEncoded
        | [<CompiledName "multipart/form-data">] FormData
        | [<CompiledName "text/plain">] Plain

    type [<StringEnum>] [<RequireQualifiedAccess>] FormMethod =
        | [<CompiledName "post">] Post
        | [<CompiledName "get">] Get
        | [<CompiledName "action">] Action

    type [<StringEnum>] [<RequireQualifiedAccess>] FormTarget =
        | [<CompiledName "_blank">] Blank
        | [<CompiledName "_self">] Self
        | [<CompiledName "_parent">] Parent
        | [<CompiledName "_top">] Top

    type [<RequireQualifiedAccess>] RequiredFormProps = {
        OnSubmit: unit -> unit
    }

    type [<RequireQualifiedAccess>] FormProps =
        | AcceptCharset of string
        | Action of string
        | AutoComplete of bool
        | EncType of FormEncodingType
        | ImplicitSubmit of bool
        | Method of FormMethod
        | Name of string
        | NoValidate of bool
        | PreventDefault of bool
        | Target of FormTarget
    

    let inline polarisForm (requiredProps: RequiredFormProps) (props : FormProps list) : ReactElement =
        let combinedProps =
            props
            |> keyValueList CaseRules.LowerFirst
            |> (fun obj ->
                obj?onSubmit <- requiredProps.OnSubmit
                obj
            )

        ofImport "Form" "@shopify/polaris" combinedProps []
