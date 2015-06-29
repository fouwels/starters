var gulp = require('gulp');
var merge = require('merge-stream');
var rimraf = require("rimraf");


gulp.task('swagger', function () {
	var swaggerCore = 
		gulp.src('/Swagger/Dist/**/*', '!index.html')
		.pipe(gulp.dest('/wwwroot/'));

	var swaggerIndex = 
		gulp.src('/Swagger/Dist/index.html')
		.pipe(gulp.dest('/wwwroot/documentation.html'));

	return merge(swaggerCore, swaggerIndex);
});

gulp.tas('clean', function (){

	rimraff('/wwwroot');

});