//Problem 11. String format
//Write a function that formats a string using placeholders.
//The function should work with up to 30 placeholders and all types.

function formatString(string){
    var args, index;

    args = [].slice.apply(arguments);

    string = string.replace(/{(\d+)}/g, function (match, number) {
        index = Number(number) + 1;                
        return typeof args[index] != 'undefined'
          ? args[index]
          : match;
    });

    return string;
}


// solution without Regex. We have the same result
function formatStringNoRegex(input) {
    var i, len, 
        args, 
        index,
        currentChar, 
        output = '';
    
    input = input || '';
    args = [].slice.apply(arguments);
    
    for (i = 0, len = input.length; i < len; i += 1) {
        currentChar = input[i];
        if (currentChar !== '{') {
            output += currentChar;            
        } else {
            index = Number(input[i + 1]) + 1; //in out args array at first position we have the input string => args start from first position
            output += (typeof args[index] != 'undefined' ? args[index] : ('{' + (index - 1) + '}'));
            i += 2;
        }
    }
       
    return output;
}

var str, str1;
str = '{0}, {1}, {0} text {2}';
str1 = 'Hello {0}!';

console.log('Solution without Regex!');
console.log(str);
console.log(formatStringNoRegex(str, 1, 'Pesho', 'Gosho'));
console.log();

console.log(str1);
console.log(formatStringNoRegex(str1, 'Peter'));


console.log('\nSolution with Regex!')
console.log(str);
console.log(formatString(str, 1, 'Pesho', 'Gosho'));
console.log();

console.log(str1);
console.log(formatString(str1, 'Peter'));