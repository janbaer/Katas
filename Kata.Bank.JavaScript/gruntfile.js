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

    // Tasks being executed with 'grunt watch'
    watch: {
      files: ['<%= typescript.base.src %>'],
      tasks: ['typescript']
    }
  });

  // Load the plugin that provides the "uglify" task.
  grunt.loadNpmTasks('grunt-contrib-jshint');
  grunt.loadNpmTasks('grunt-contrib-watch');
  grunt.loadNpmTasks('grunt-typescript');

  // Default task(s).
  grunt.registerTask('default', ['jshint', 'typescript', 'watch']);

};