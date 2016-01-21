//Problem 10. Find palindromes
//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".


//this are functions that help me to extrakt only words from text
(function () {
    if (!String.prototype.trimLeftChars) {
        String.prototype.trimLeftChars = function (chars) {
            var regEx = new RegExp('^[' + chars + ']+');
            return this.replace(regEx, '');
        }
    }
    
    if (!String.prototype.trimRightChars) {
        String.prototype.trimRightChars = function (chars) {
            
            var regEx = new RegExp('[' + chars + ']+$');
            return this.replace(regEx, '');
        }
    }
    
    
    if (!String.prototype.trimChars) {
        String.prototype.trimChars = function (chars) {
            return this.trimLeftChars(chars).trimRightChars(chars);
        }
    }

})();

//this function check if a word is palindrome
function isPalindromes(str) {
    return (str.length > 1) && (str === str.split('').reverse().join(''));
}


//extract all word from a text and return an array with palindromes
function findPalindromes(text){
    var i, len,
        currentWord = '',
        words = [],
        palindromes = [];

    words = text.split(' ');
    
    for (i = 0, len = words.length; i < len; i += 1) {
        currentWord = words[i].trimChars(['!', '.', ',', '?', ':', ' ', '<', '>']);
        
        if (isPalindromes(currentWord)) {
            palindromes.push(currentWord);
        }
    }
    return palindromes;
}

//tests

var text = 'This is a text with different palindromes, e.g. tattarrattat, abba, exe, lamal and so on';

console.log(text);
console.log('Palindroms are: ' + findPalindromes(text).toString());
