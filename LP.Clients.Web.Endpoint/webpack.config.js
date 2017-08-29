var path = require('path');
var merge = require('webpack-merge');

var isDevelopment = process.env.ASPNETCORE_ENVIRONMENT === 'Development';

module.exports = merge({
  resolve: {
    extensions: ['.js', '.ts'],
    alias: {
      vue: 'vue/dist/vue.js'
    }
  },
  module: {
    loaders: [
      {test: /\.ts(x?)$/, exclude: /node_modules/, loader: 'ts-loader?silent'}
    ]
  },
  entry: {
    main: './Scripts/App.ts'
  },
  output: {
    path: path.join(__dirname, 'wwwroot', 'dist'),
    filename: '[name].js',
    publicPath: '/dist/'
  }
});