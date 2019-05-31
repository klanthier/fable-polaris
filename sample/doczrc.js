// doczrc.js
var path = require("path");
const merge = require('webpack-merge');

const webpackOverlay = {
    mode: "development",
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
}

export default {
    title: 'Fable-Polaris',
    description: 'Documentation and Examples of the bindings',
    modifyBundlerConfig: config => {
        const merged = merge(config, webpackOverlay);
        merged.entry["app"].push("./src/App.fsproj");
        return merged;
    }
}