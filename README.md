# fable-polaris [![Build Status](https://travis-ci.org/klanthier/fable-polaris.svg?branch=master)](https://travis-ci.org/klanthier/fable-polaris) [![NuGet version](https://badge.fury.io/nu/fable-polaris.svg)](https://badge.fury.io/nu/fable-polaris)

Fable/F# bindings for Shopify's Polaris react component library

Current bindings are written for Shopify Polaris version **3.14.0**

# Using in your Fable Project

## Dependency

You will need to install Shopify Polaris
`yarn add @shopify/polaris@3.14.0`

Then you must ensure you add the styles to your main F# file like so:
`importAll "@shopify/polaris/styles.css"`

## Fable-Polaris

Add shopify-polaris to your project
`dotnet add package fable-polaris --version 0.2.0`

### You may now begin using the library like so

```
module App

open Elmish
open Elmish.React
open Fable.React
open Fable.Core.JsInterop

open Polaris
open Polaris.AppProvider
open Polaris.Stack

importAll "@shopify/polaris/styles.css"

type Model = int

type Msg =
| Increment
| Decrement

let init() : Model = 0

let update (msg:Msg) (model:Model) =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

let view (model:Model) dispatch =

    appProvider [] [
      stack [ StackProps.Vertical true ]
        [
          Button.button { OnClick = (fun _ -> dispatch Increment) } [] [ str "+" ]
          div [] [ str (string model) ]
          Button.button { OnClick = (fun _ -> dispatch Decrement) } [] [ str "-" ]
        ]
    ]

// App
Program.mkSimple init update view
|> Program.withReactBatched "fable-polaris-app"
|> Program.withConsoleTrace
|> Program.run
```

# Installing and Running the sample

Run `yarn build` to build all the project source

To start the sample project run
`cd sample && yarn && yarn start`

# List of supported components

| Component             |     Supported      |
| --------------------- | :----------------: |
| Account connection    | :white_check_mark: |
| Action list           |     :no_entry:     |
| App provider          | :white_check_mark: |
| Autocomplete          |     :no_entry:     |
| Avatar                | :white_check_mark: |
| Badge                 |     :no_entry:     |
| Banner                |     :no_entry:     |
| Button                | :white_check_mark: |
| Button group          |     :no_entry:     |
| Callout card          |     :no_entry:     |
| Caption               |     :no_entry:     |
| Card                  |     :no_entry:     |
| Checkbox              |     :no_entry:     |
| Choice list           |     :no_entry:     |
| Collapsible           |     :no_entry:     |
| Color picker          |     :no_entry:     |
| Contextual save bar   |     :no_entry:     |
| Data table            |     :no_entry:     |
| Date picker           |     :no_entry:     |
| Description list      |     :no_entry:     |
| Display text          |     :no_entry:     |
| Dropzone              |     :no_entry:     |
| Empty state           |     :no_entry:     |
| Exception list        |     :no_entry:     |
| Footer help           |     :no_entry:     |
| Form                  |     :no_entry:     |
| Form layout           |     :no_entry:     |
| Frame                 | :white_check_mark: |
| Heading               |     :no_entry:     |
| Icon                  | :white_check_mark: |
| Inline error          |     :no_entry:     |
| Keyboard key          |     :no_entry:     |
| Layout                |     :no_entry:     |
| Link                  |     :no_entry:     |
| List                  |     :no_entry:     |
| Loading               |     :no_entry:     |
| Modal                 |     :no_entry:     |
| Navigation            | :white_check_mark: |
| Option List           |     :no_entry:     |
| Page                  |     :no_entry:     |
| Page actions          |     :no_entry:     |
| Pagination            |     :no_entry:     |
| Popover               |     :no_entry:     |
| Progress bar          |     :no_entry:     |
| Radio button          |     :no_entry:     |
| Range slider          |     :no_entry:     |
| Resource list         |     :no_entry:     |
| Resource picker       |     :no_entry:     |
| Scrollable            |     :no_entry:     |
| Section header        |     :no_entry:     |
| Select                |     :no_entry:     |
| Setting toggle        |     :no_entry:     |
| Skeleton body text    |     :no_entry:     |
| Skeleton display text |     :no_entry:     |
| Skeleton page         |     :no_entry:     |
| Skeleton thumbnail    |     :no_entry:     |
| Spinner               | :white_check_mark: |
| Stack                 | :white_check_mark: |
| Stepper               |     :no_entry:     |
| Subheading            |     :no_entry:     |
| Tabs                  |     :no_entry:     |
| Tag                   |     :no_entry:     |
| Text container        |     :no_entry:     |
| Text field            |     :no_entry:     |
| Text style            |     :no_entry:     |
| Thumbnail             |     :no_entry:     |
| Toast (flash message) |     :no_entry:     |
| Tooltip               |     :no_entry:     |
| Top bar               |     :no_entry:     |
| Visually hidden       |     :no_entry:     |

# Common issues

You will need to ensure that there is a loader for the css files from Polaris, in your webpack make sure you have that set-up

```

module: {
       rules: [
           {
               test: /\.fs(x|proj)?$/,
               use: "fable-loader"
           },
           {
               test: /\.css$/,
               use: [
                   "style-loader", // creates style nodes from JS strings
                   "css-loader", // translates CSS into CommonJS
               ]
           }

       ]
   }
```

# Disclaimer

This library facilitate usage of Shopify's Polaris React library through bindings. We do not have any license or rights over their library and you must ensure while using Fable-Polaris that you have the proper rights to consume Shopify's Polaris library according to their [license](https://polaris.shopify.com/legal/license).
