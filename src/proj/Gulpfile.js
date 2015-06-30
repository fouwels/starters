/// <binding BeforeBuild='clean' />
var gulp = require('gulp');
var merge = require('merge-stream');
var rimraf = require("rimraf");
var gutil = require('gulp-util');
var gulpIgnore = require('gulp-ignore');

gulp.task('swagger', function () {

	var swagger =
		gulp.src('./Swagger/Dist/**/*')
		.pipe(gulpIgnore.exclude('./Swagger/Dist/index.html'))
		.pipe(gulp.dest('./wwwroot/'));

	var swagfile =
		gulp.src('swagger.json')
		.pipe(gulp.dest('./wwwroot/'));


	//var swaggerIndex = 
	//	gulp.src('./Swagger/Dist/index.html')
	//	.pipe(rename('documentation.html'))
	//	.pipe(gulp.dest('/wwwroot/'));

	return merge(swagger, swagfile);
});

gulp.task('clean', function (cb){
	rimraf('./wwwroot/*', cb);
});

gulp.task('default', function () {
	gutil.log('\n\n************************************');
	gutil.log('Available actions:');
	gutil.log('clean: clean serving dir');
	gutil.log('swagger: copy swagger files from dist into serving dir.');
	gutil.log('\n*************************************');
});