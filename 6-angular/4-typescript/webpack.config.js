var path = require('path');

module.exports = {
    mode: 'development',
    entry: './out/index.js',
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: 'index.bundle.js'
    }
};
