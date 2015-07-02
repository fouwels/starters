/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var rimraf = require("rimraf");

gulp.task('clean', function (cb) {
	rimraf('./wwwroot/*', cb);
});

gulp.task('bootstrap', function () {
	return gulp.src('./bower_components/bootstrap/dist/**/*')
		.pipe(gulp.dest('./wwwroot/'));
});

gulp.task('jquery', function () {
	return gulp.src('./bower_components/jquery/dist/**/*')
		.pipe(gulp.dest('./wwwroot/js/'));
});

gulp.task('styles', function () {
	return gulp.src('./working/css/*')
		.pipe(gulp.dest('./wwwroot/css/'));
});

gulp.task('scripts', function () {
	return gulp.src('./working/js/*')
		.pipe(gulp.dest('./wwwroot/js/'));
});

gulp.task('pages', function () {
	return gulp.src('./working/*')
		.pipe(gulp.dest('./wwwroot/'));
});

gulp.task('build', ['clean', 'bootstrap', 'jquery', 'styles', 'scripts', 'pages']);