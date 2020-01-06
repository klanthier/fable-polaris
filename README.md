# fable-polaris [![Build Status](https://travis-ci.org/klanthier/fable-polaris.svg?branch=master)](https://travis-ci.org/klanthier/fable-polaris) [![NuGet version](https://badge.fury.io/nu/fable-polaris.svg)](https://badge.fury.io/nu/fable-polaris)

Fable/F# bindings for Shopify's Polaris react component library

Current bindings are written for Shopify Polaris version **4.10.2**
Each release of this project is an equivalent of Polaris version.

# Using in your Fable Project

## Dependency

You will need to install Shopify Polaris
`yarn add @shopify/polaris@4.10.2`

Then you must ensure you add the styles to your main F# file like so:
`importAll "@shopify/polaris/styles.css"`

## Fable-Polaris

Add shopify-polaris to your project
`dotnet add package fable-polaris`

### You may now begin using the library like so

```
module App

open Elmish
open Elmish.React
open Fable.React
open Fable.Core.JsInterop
open Fable.Polaris

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
    polarisAppProvider [] <|
      polarisStack [ StackProps.Vertical true ]
        [
          polarisButton [ ButtonProps.OnClick <| (fun _ -> dispatch Increment)] [ str "+" ]
          div [] [ str (string model) ]
          polarisButton [ ButtonProps.OnClick <| (fun _ -> dispatch Decrement)] [ str "-" ]
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
| Action list           | :white_check_mark: |
| App provider          | :white_check_mark: |
| Autocomplete          | :white_check_mark: |
| Avatar                | :white_check_mark: |
| Badge                 | :white_check_mark: |
| Banner                | :white_check_mark: |
| Button                | :white_check_mark: |
| Button group          | :white_check_mark: |
| Callout card          | :white_check_mark: |
| Caption               | :white_check_mark: |
| Card                  | :white_check_mark: |
| Checkbox              | :white_check_mark: |
| Choice list           | :white_check_mark: |
| Collapsible           | :white_check_mark: |
| Color picker          | :white_check_mark: |
| Contextual save bar   | :white_check_mark: |
| Data table            | :white_check_mark: |
| Date picker           | :white_check_mark: |
| Description list      | :white_check_mark: |
| Display text          | :white_check_mark: |
| Dropzone              | :white_check_mark: |
| Empty state           | :white_check_mark: |
| Exception list        | :white_check_mark: |
| Footer help           | :white_check_mark: |
| Filters               | :white_check_mark: |
| Form                  | :white_check_mark: |
| Form layout           | :white_check_mark: |
| Frame                 | :white_check_mark: |
| Heading               | :white_check_mark: |
| Icon                  | :white_check_mark: |
| Inline error          | :white_check_mark: |
| Keyboard key          | :white_check_mark: |
| Layout                | :white_check_mark: |
| Link                  | :white_check_mark: |
| List                  | :white_check_mark: |
| Loading               | :white_check_mark: |
| Modal                 | :white_check_mark: |
| Navigation            | :white_check_mark: |
| Option List           | :white_check_mark: |
| Page                  | :white_check_mark: |
| Page actions          | :white_check_mark: |
| Pagination            | :white_check_mark: |
| Popover               | :white_check_mark: |
| Progress bar          | :white_check_mark: |
| Radio button          | :white_check_mark: |
| Range slider          | :white_check_mark: |
| Resource item         | :white_check_mark: |
| Resource list         | :white_check_mark: |
| Resource picker       |     :no_entry:     |
| Scrollable            | :white_check_mark: |
| Section header        |     :no_entry:     |
| Select                | :white_check_mark: |
| Setting toggle        | :white_check_mark: |
| Sheet                 | :white_check_mark: |
| Skeleton body text    | :white_check_mark: |
| Skeleton display text | :white_check_mark: |
| Skeleton page         | :white_check_mark: |
| Skeleton thumbnail    | :white_check_mark: |
| Spinner               | :white_check_mark: |
| Stack                 | :white_check_mark: |
| Stepper               |     :no_entry:     |
| Subheading            | :white_check_mark: |
| Tabs                  | :white_check_mark: |
| Tag                   | :white_check_mark: |
| Text container        | :white_check_mark: |
| Text field            | :white_check_mark: |
| Text style            | :white_check_mark: |
| Thumbnail             | :white_check_mark: |
| Toast (flash message) | :white_check_mark: |
| Tooltip               | :white_check_mark: |
| Top bar               |   :construction:   |
| Visually hidden       | :white_check_mark: |

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
