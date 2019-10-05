namespace Fable.Polaris

module Dropzone =

    open Fable.React
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Polaris

    type [<StringEnum>] [<RequireQualifiedAccess>] FileType =
        | [<CompiledName "file">] File
        | [<CompiledName "image">] Image

    type DropZoneProps =
        | Accept of string
        | Active of bool
        | AllowMultiple of bool
        | Disabled of bool
        | DropOnPage of bool
        | Error of bool
        | ErrorOverlayText of string
        | Id of string
        | Label of string
        | LabelHidden of bool
        | OpenFileDialog of bool
        | Outline of bool
        | Overlay of bool
        | OverlayText of string
        | Type of FileType
        | CustomValidator of (unit -> unit)
        | OnClick of (unit -> unit)
        | OnDragEnter of (unit -> unit)
        | OnDragLeave of (unit -> unit)
        | OnDragOver of (unit -> unit)
        | OnDrop of (unit -> unit)
        | OnDropAccepted of (unit -> unit)
        | OnDropRejected of (unit -> unit)
        | OnFileDialogClose of (unit -> unit)
        static member LabelAction (action: Action) =
            actionUnboxHelper "labelAction" action

    let inline polarisDropZone (props : DropZoneProps list) (elems: ReactElement list) : ReactElement =
        ofImport "DropZone" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) elems


    type DropZoneFileUploadProps =
        | ActionTitle of string
        | ActionHint of string

    let inline polarisDropZoneFileUpload (props: DropZoneFileUploadProps list) : ReactElement =
        ofImport "DropZone.FileUpload" "@shopify/polaris" (keyValueList CaseRules.LowerFirst props) []