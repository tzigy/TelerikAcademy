//Problem 1. Format with placeholders
//Write a function that formats a string. The function should have placeholders, as shown in the example
//Add the function to the String.prototype


(function () { 

    //if (!String.prototype.format) {
    //    String.prototype.format = function (){
    //        var args;            
    //        args = [].slice.apply(arguments)[0];            
    //        return this.replace(/#{(\w+)}/g, function (match, prop) {                
    //            return typeof args[prop] != 'undefined' ? args[prop] : match;
    //        });
    //    }
    //}


    if (!String.prototype.format) {
        String.prototype.format = function (options) {
            
            return this.replace(/#{(\w+)}/g, function (match, prop) {
                return typeof options[prop] != 'undefined' ? options[prop] : match;
            });
        }
    }

})();

//tests
var options, str;

options = { name: 'John' };
str = 'Hello, there! Are you #{name}?'
console.log(str.format(options));

options = { name: 'John', age: 13 };
console.log('My name is #{name} and I am #{age}-years-old'.format(options));