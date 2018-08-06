"use strict";

const path = require('path');
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const distPath = path.join(__dirname, 'wwwroot');

module.exports = {
    entry: {
        'jquery': [
            'jquery/dist/jquery.js',
            'jquery/dist/jquery.min.js'
        ],
        'bootstrap': [
            'bootstrap/dist/js/bootstrap.js',
            'bootstrap/dist/js/bootstrap.min.js',
            'bootstrap/dist/css/bootstrap.css',
            'bootstrap/dist/css/bootstrap.min.css'
        ]
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/dist'),
        publicPath: '/',
        filename: 'js/[name].js'
    },
    resolve: {
        modules: ['./node_modules']
    },
    plugins: [
        new ExtractTextPlugin('css/[name].css')
    ]
};