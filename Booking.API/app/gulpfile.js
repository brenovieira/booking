'use strict';

var gulp        = require('gulp'),
    debug       = require('gulp-debug'),
    concat      = require('gulp-concat'),
    sourcemaps  = require('gulp-sourcemaps'),
    uglify      = require('gulp-uglify'),
    cssnano     = require('gulp-cssnano'),
    less        = require('gulp-less'),
    ngAnnotate  = require('gulp-ng-annotate'),
    replace     = require('gulp-regex-replace'),
    rev         = require('gulp-rev'),
    revReplace  = require('gulp-rev-replace'),
    revDel      = require('rev-del');

var paths = {
    libs: [
        'bower_components/angular/angular.min.js',
        'bower_components/angular-route/angular-route.min.js',
        'bower_components/angular-animate/angular-animate.min.js',
        'bower_components/angular-bootstrap/ui-bootstrap-tpls.min.js',
    ],
    scripts: [
        'module.js',
        'app.*.js',
        'components/**/*.js',
        'directives/**/*.js',
        'filters/**/*.js',
    ],
    less: 'css/app.less',

    dest: 'dist',
    libsFile: 'libs.js',
    scriptsFile: 'app.js',
    cssFile: 'app.css',
};

paths.finalFiles = [
    paths.dest + '/' + paths.libsFile,
    paths.dest + '/' + paths.scriptsFile,
    paths.dest + '/' + paths.cssFile,
];

// Concat 3rd party libs
gulp.task('libs', function () {
    return gulp.src(paths.libs)
        .pipe(debug({
            title: '1. Libs file:'
        }))
        .pipe(concat(paths.libsFile))
        .pipe(gulp.dest(paths.dest))
});

// Concat, minify and create sourcemaps for app scripts
gulp.task('js', function () {
    return gulp.src(paths.scripts)
        .pipe(debug({
            title: '2. App file:'
        }))
        .pipe(sourcemaps.init())
        .pipe(ngAnnotate().on('error', function (err) { console.log(err); }))
        .pipe(concat(paths.scriptsFile))
		.pipe(replace({ regex: '.html', replace: '.html?v=' + Date.now() }))
        .pipe(uglify())
        .pipe(sourcemaps.write())
        .pipe(gulp.dest(paths.dest))
});

// Compile less and minify css
gulp.task('css', function () {
    return gulp.src(paths.less)
        .pipe(debug({
            title: '3. Less file:'
        }))
        .pipe(less())
        .pipe(cssnano())
        .pipe(gulp.dest(paths.dest))
});

// Static asset revisioning by appending content hash to filenames
gulp.task('rev', ['libs', 'js', 'css'], function () {
    return gulp.src(paths.finalFiles)
        .pipe(debug({
            title: '4. Rev file:'
        }))
        .pipe(rev())
        .pipe(gulp.dest(paths.dest))
        .pipe(rev.manifest())
        .pipe(revDel({ dest: paths.dest }))
        .pipe(gulp.dest(paths.dest));
});

// Rewrite index.html with revisioned files
gulp.task('revreplace', ['rev'], function () {
    var manifest = gulp.src('./' + paths.dest + '/rev-manifest.json');

    return gulp.src('../index.html')
        .pipe(revReplace({ manifest: manifest }))
        .pipe(gulp.dest(paths.dest));
});

// Rerun the task when a file changes
gulp.task('watch', ['build'], function () {
    gulp.watch(paths.libs, ['libs', 'rev', 'revreplace']);
    gulp.watch(paths.scripts, ['js', 'rev', 'revreplace']);
    gulp.watch(paths.less, ['css', 'rev', 'revreplace']);
});

// The deployment task (no need for watch)
gulp.task('build', ['libs', 'js', 'css', 'rev', 'revreplace']);

// The default task (called when you run `gulp` from cli)
gulp.task('default', ['build', 'watch']);