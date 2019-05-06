const path = require('path');
const webpack = require('webpack');
const htmlPlugin = require('html-webpack-plugin');


const babelConfiguration = {
    test: /\.(js|jsx)$/,
    //Include the files you want to compile
    include: [
        path.join(__dirname, '/src/index'),
        path.join(__dirname, '/src')
    ],
    exclude: [
        path.join(__dirname, '/node_modules/')
    ],
    use: {
        loader: "babel-loader",
        options: {
            cacheDirectory: true
        }
    }
}

module.exports = {
    //whatwg-fetch fetch polyfill for making compatible for all browsers
    //babel-polyfill babel-polyfil for making your babel compiler compatible for all browsers.
    entry: ['whatwg-fetch', '@babel/polyfill', path.join(__dirname, './src/index.js')],
    output: {
        filename: 'index.bundle.js',
        path: path.join(__dirname, '/dist')
    },
    devServer: {
        publicPath: '/',
        historyApiFallback: true,
        contentBase: './dist'
    },
    module: {
        rules: [
            babelConfiguration, 
            {
                test: /\.css$/,
                use: [
                    'style-loader',
                    {
                        loader: 'css-loader',
                        options: {
                            sourceMap: true
                        }
                    }
                ]
            }
        ]
    },
    plugins: [
        new htmlPlugin({
            template: './src/index.html'
        })
    ],
    //NOw define your resolve property that will be used to change how modules is resolved.
    resolve: {
        //Now can set aliases, which will make it easier to import or require modules or files.
        alias: {
            'redux-storage-engine-reactnativeasyncstorage': 'redux-storage-engine-localstorage'
        },
        //Define the extensions property that would resolve certain files.
        //Allows leaving off extensions when importing them.
        extensions: ['.js', '.jsx']
    }
}