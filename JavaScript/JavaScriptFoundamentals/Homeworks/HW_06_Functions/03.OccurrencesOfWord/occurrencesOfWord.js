//Problem 3. Occurrences of word
//Write a function that finds all the occurrences of word in a text.
//The search can be case sensitive or case insensitive.
//Use function overloading.

function countWordOccurrences(text, word, caseSensitiv){
    var i, len,
        caseSensitiv,   
        currentWord,
        count = 0,
        textAsArray = [];
    
    caseSensitiv = caseSensitiv || false;
    
    if (!caseSensitiv) {
        word = word.toLowerCase();
        text = text.toLowerCase();
    }
    
    //May be there is a better regex, but I think here is enougth
    textAsArray = text.replace(/\.\s*/g, '|').replace(/\?/g, '|').replace(/\!/g, '|').replace(/\s+/g, '|').split("|");

    for (i = 0, len = textAsArray.length; i < len; i += 1) {
        currentWord = textAsArray[i];
        if (word === currentWord) {
            count += 1;
        }
    }

    return count;
}

//Test

text = 'The BBC has updated its cookie policy. We use cookies to ensure that we give you the best experience on our website. This includes cookies from third party social media websites if you visit a page which contains embedded content from social media. Such third party cookies may track your use of the BBC website. We and our partners also use cookies to ensure we show you advertising that is relevant to you. If you continue without changing your settings, we will assume that you are happy to receive all cookies on the BBC website.However, you can change your Cookies settings at any time.';

console.log(text);
console.log();
console.log('Serching for "Cookies" using case sensitive search:');
console.log('--> ' + countWordOccurrences(text, 'Cookies', true) + ' occurrences!');
console.log();
console.log('Serching for "Cookies" using case unsensitive search:');
console.log('--> ' + countWordOccurrences(text, 'Cookies') + ' occurrences!');
