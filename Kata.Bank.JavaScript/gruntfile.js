module.exports = function (grunt) {

  // Project configuration.
  grunt.initConfig({
    pkg: grunt.file.readJSON('package.json'),

    jshint: {
      files: ['Gruntfile.js', 'app/**/*.js', 'test/**/*.js']
    },

    typescript: {
      base: {
        src: ['./**/*.ts'],
        dest: '.',
        options: {
          module: 'commonjs',
          target: 'es5',
          base_path: '.',
          sourcemap: true,
          fullSourceMapPath: false,
          declaration: false
        }
      }
    },

    mochaTest: {
      files: [ 'test/**/*.js' ]
    },

    mochaTestConfig: {
      options: {
        reporter: 'spec',
        ui: 'tdd'
      }
    },

    watch: {
      typescript: {
        files: ['<%= typescript.base.src %>'],
        tasks: ['typescript']
      },
      mochaTest: {
        files: ['<%= mochaTest.files %>'],
        tasks: ['mochaTest']
      }
    }
  });

  // Load the plugin that provides the "uglify" task.
  grunt.loadNpmTasks('grunt-contrib-jshint');
  grunt.loadNpmTasks('grunt-contrib-watch');
  grunt.loadNpmTasks('grunt-mocha-test');
  grunt.loadNpmTasks('grunt-typescript');

  // Default task(s).
  grunt.registerTask('default', ['typescript', 'mochaTest', 'watch']);

};
