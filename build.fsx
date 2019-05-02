#r "paket: groupref netcorebuild //"
#load ".fake/build.fsx/intellisense.fsx"

#if !FAKE
#r "Facades/netstandard"
#r "netstandard"
#endif

open System
open Fake.Core
open Fake.Core.TargetOperators
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.JavaScript

Target.create "Clean" (fun _ ->
    !! "sample/src/**/bin"
    ++ "sample/src/**/obj"
    ++ "src/**/bin"
    ++ "src/**/obj"
    |> Seq.iter Shell.cleanDir
)

Target.create "Install" (fun _ ->
    !! "src/**/*.fsproj"
    ++ "sample/src/**/*.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        DotNet.restore id dir)
)

Target.create "Build" (fun _ ->
    !! "src/**/*.fsproj"
    ++ "sample/src/**/*.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        DotNet.build id dir)
)

Target.create "YarnInstall" (fun _ ->
    Yarn.install id
)


// Build order
"Clean"
    ==> "Install"
    ==> "Build"

"Build"
    ==> "YarnInstall"

// start build
Target.runOrDefault "Build"