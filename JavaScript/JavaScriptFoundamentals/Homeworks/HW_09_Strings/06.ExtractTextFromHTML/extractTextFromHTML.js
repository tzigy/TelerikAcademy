//Problem 6. Extract text from HTML
//Write a function that extracts the content of a html page given as text.
//The function should return anything that is in a tag, without the tags.

//this function is working only in browsers console
function extractTextFromHTMLBrowser(text){
    var textAsHtml = document.createElement('html');
    textAsHtml.innerHTML = text;
    return textAsHtml.textContent || textAsHtml.innerText || '';
}

function extractTextFromHTML(text) {
    var i, len, 
        currentSymbol = '',
        output = '',
        isTag = false;

    for (i = 0, len = text.length; i < len; i += 1) {
        currentSymbol = text[i];

        if (currentSymbol === '<') {
            isTag = true;
        }
        
        if (!isTag) {
            output += currentSymbol;
        }

        if (currentSymbol === '>') {
            isTag = false;
        }
    }
    return output;
}

//tests

var text = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';

console.log(extractTextFromHTML(text));