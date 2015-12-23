module.exports = function (config) {
  'use strict';

  config.set({
    basePath: '',
    frameworks: ['jasmine'],
    files: [
      'jasmine-aliases.js',
      'node_modules/phantomjs-polyfill/bind-polyfill.js',
      'src/**/*.js'
    ],
    exclude: [],
    reporters: ['spec', 'growl'],
    port: 9876,
    colors: true,
    logLevel: config.LOG_INFO,
    autoWatch: true,
    browsers: ['PhantomJS'],
    captureTimeout: 60000,
    singleRun: false,

    preprocessors: {
      
      'src/**/*.js': ['babel']
      
    },
    
    'babelPreprocessor': {
      options: {
        presets: ['es2015'],
        sourceMap: 'inline'
      },
      filename: function(file) {
        return file.originalPath.replace(/\.js$/, '.es5.js');
      },
      sourceFileName: function(file) {
        return file.originalPath;
      }
    },
    
    
    
  });
};
