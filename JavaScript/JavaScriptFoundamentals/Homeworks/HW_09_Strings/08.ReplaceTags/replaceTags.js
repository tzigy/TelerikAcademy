//Problem 8. Replace tags
//Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

function replaceAnchorTags(input){
    var i, len,
        startPos,
        endPos, 
        url = '', 
        output = '';

    for (i = 0, len = input.length; i < len; i += 1) {
        if (input[i] == '<' && input[i + 1] == 'a') {
            startPos = input.indexOf('"', i) +1;
            endPos = input.indexOf('"', startPos + 2);
            url = input.substring(startPos, endPos);

            output += '[URL=' + url + ']';
            i = endPos + 1;
        } else if(input[i] == '<' && input[i + 1] == '/' && input[i + 2] == 'a'){
            output += '[/URL]';
            i = i + 2;
        } else {
            output += input[i];
        }
    }
    return output;
}

var input = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

//console.log('Original text:');
//console.log(input);
//console.log('\nNew text:');
//console.log(replaceAnchorTags(input));

var re = /(\w+)\s(\w+)/;
var str = "John Smith";
var newstr = str.replace(re, "$1,,, $1");
console.log(newstr);