﻿'use strict';

const path = require('path');
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const VueLoaderPlugin = require('vue-loader/lib/plugin');

const distPath = path.resolve(__dirname, 'wwwroot');

module.exports = {
    entry: {
        'vendor': [
            'jquery/dist/jquery.js',
            'bootstrap/dist/js/bootstrap.js',
            'bootstrap/dist/css/bootstrap.css'
        ],
        'client': './Client/bootstrapper.js'
    },
    output: {
        path: distPath,
        publicPath: '/',
        filename: 'js/[name].js'
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/
            },
            {
                test: /\.css$/,
                use: ExtractTextPlugin.extract({
                    fallback: 'style-loader',
                    use: ['css-loader']
                })
            }
        ]
    },
    resolve: {
        modules: ['./node_modules']
    },
    plugins: [
        new ExtractTextPlugin('css/[name].css'),
        new VueLoaderPlugin()
    ]
};