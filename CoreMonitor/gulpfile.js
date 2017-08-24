/// <binding BeforeBuild='concat:libjs' />
var gulp = require('gulp');
var less = require('gulp-less');
var typescript = require('gulp-typescript');
var concat = require('gulp-concat');

var libJsPaths = [
    "node_modules/core-js/client/shim.min.js",
    "node_modules/zone.js/dist/zone.js",
    "node_modules/systemjs/dist/system.src.js",
    "node_modules/jquery/dist/jquery.js",
    "node_modules/bootstrap/dist/js/bootstrap.js",
    "src/systemjs.config.js"
]

var libCssPaths = [
    "node_modules\bootstrap\dist\css\bootstrap.css"
];


gulp.task("concat:libjs", function () {
    return gulp.src(libJsPaths)
    .pipe(concat("lib.js"))
    .pipe(gulp.dest("JS"));
});



// Rerun the task when a file changes
gulp.task('watch', function () {
    gulp.watch(libJsPaths, ['scripts']);
    gulp.watch(libCssPaths, ['csses']);
});

// The default task (called when you run `gulp` from cli)
gulp.task('default', ['watch', 'scripts', 'csses']);