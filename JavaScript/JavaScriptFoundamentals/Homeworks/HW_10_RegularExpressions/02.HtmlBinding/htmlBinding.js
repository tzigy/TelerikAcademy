//Problem 2. HTML binding
//Write a function that puts the value of an object into the content/attributes of HTML tags.
//Add the function to the String.prototype

(function () {
    if (!String.prototype.bind) {
        String.prototype.bind = function (str, options) {
            var i, len, prop, value, re, arr = [], matches = [];
            re = /data\-bind\-(\w+)="(\w+)"/g;
            matches = str.match(re);
            
            for (i = 0, len = matches.length; i < len; i += 1) {
                
                arr = (re.exec(matches));
                prop = arr[1];
                value = arr[2];
                
                if (prop == 'content') {
                    str = str.replace(/><\//, ('>' + options[value] + '<\/'));
                } else if (prop == 'href') {
                    str = str.replace(/">/, '" href="' + options[value] + '">');
                } else if (prop == 'class') {
                    str = str.replace(/">/, '" class="' + options[value] + '">');
                }
            }
            
            return str;
        }
    }
})();

//tests

var str, options;
str = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></a>'
options = { name: 'Elena', link: 'http://telerikacademy.com' };

console.log('Original string:');
console.log(str);
console.log('After binding:');
console.log(str.bind(str, options));
console.log();

str = '<div data-bind-content="name"></div>';
options = { name: 'Steven' };

console.log('Original string:');
console.log(str);
console.log('After binding:');
console.log(str.bind(str, options));