var path = require("path");
var webpack = require("webpack");

var cfg = {
  devtool: "source-map",
  entry: "./tmp/App",
  output: {
    path: path.join(__dirname, "dist"),
    filename: "bundle.js"
  },
  module: {
    preLoaders: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        loader: "source-map-loader"
      }
    ],
    loaders: [
      {
        test: /\.sass$/,
        loaders: ["style", "css?sourceMap", "sass?sourceMap"]
      }
    ]
  },
  devServer: {
    proxy: {
      '/api/starships': {
        target: 'http://127.0.0.1:8083',
        secure: false
      }
    }
  }
};

module.exports = cfg;
