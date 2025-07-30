const gulp = require('gulp');
const concat = require('gulp-concat');
const cleanCSS = require('gulp-clean-css');
const fs = require('fs');
const path = require('path');

// Caminho base dos arquivos CSS
const base = './wwwroot/';

// Lê o styles.css para obter a ordem dos imports
function getCssFiles() {
    const files = [path.join(base, 'yasamen.min.css')];
    const mainCss = fs.readFileSync(path.join(base, 'styles.css'), 'utf-8');
    const importRegex = /@import url\(["']?(.+?\.css)["']?\);/g;
    let match;
    while ((match = importRegex.exec(mainCss)) !== null) {
        files.push(path.join(base, match[1]));
    }
    return files;
}

gulp.task('bundle-css', function () {
    const cssFiles = getCssFiles();
    // Inclui o próprio styles.css no início, se desejar
    // cssFiles.unshift(path.join(base, 'styles.css'));
    return gulp.src(cssFiles)
        .pipe(concat('styles.bundle.css'))
        //.pipe(cleanCSS())
        .pipe(gulp.dest(base));
});