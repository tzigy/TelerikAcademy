//Problem 3. Sub-string in text
//Write a JavaScript function that finds how many times a substring is contained in a given text(perform case insensitive search) .

function subStringInText(text, subString, caseSensitive){
    var i,
        currentSubString = '', 
        count = 0, 
        subStringLength = 0;
    subStringLength = subString.length;
    caseSensitive = caseSensitive || false;

    if (!caseSensitive) {
        text = text.toLowerCase();
        subString = subString.toLowerCase();
    }

    for (i = 0; i < text.length; i += 1) {
        currentSubString = text.substr(i, subStringLength);
        
        if (currentSubString === subString) {
            count += 1;
            i = i + subStringLength;
        }
    }

    return count;
}


// tests

var text, subString;

text = "The text is as follows: We are living In an yellow submarine.We don 't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it In 5 days.";
subString = 'In';

console.log('Case insensitive search:')
console.log('The text is as follows: ' + text + '\n Searched substring: ' + subString + '\n Number of Occurences: ' + subStringInText(text, subString));


console.log('\nCase sensitive search:')
console.log('The text is as follows: ' + text + '\n Searched substring: ' + subString + '\n Number of Occurences: ' + subStringInText(text, subString, subString));
