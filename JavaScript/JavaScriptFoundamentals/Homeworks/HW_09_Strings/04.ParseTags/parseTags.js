//Problem 4. Parse tags
//You are given a text.Write a function that changes the text in all regions:
//<upcase>text</upcase> to uppercase.
//<lowcase>text</lowcase> to lowercase
//<mixcase>text</mixcase> to mix casing(random)


//My function allows nested tags and parse the original string only once
function parseTags(input){
    
    var i, len, 
        randomNum,
        nestedTags = [],
        upper = 'upper',
        lower = 'lower',
        mix = 'mix',
        output = '';

    input = input || [];

    for (i = 0, len = input.length; i < len; i += 1) {
        if (input[i] == '<' && input[i + 1] == 'u') {
            nestedTags.push(upper);
            i = i + 7;
        } else if (input[i] == '<' && input[i + 1] == 'l') {
            nestedTags.push(lower);
            i = i + 8;
        } else if (input[i] == '<' && input[i + 1] == 'm') {
            nestedTags.push(mix);
            i = i + 8;
        } else if (input[i] == '<' && input[i + 1] == '/' && input[i + 2] == 'u') {
            nestedTags.pop();
            i = i + 8;
        } else if (input[i] == '<' && input[i + 1] == '/' && input[i + 2] == 'l') {
            nestedTags.pop();
            i = i + 9;
        } else if (input[i] == '<' && input[i + 1] == '/' && input[i + 2] == 'm') {
            nestedTags.pop();
            i = i + 9;
        } else if (!nestedTags.length) {
            output += input[i];
        } else if (nestedTags[nestedTags.length - 1] == upper) {
            output += input[i].toUpperCase();
        } else if (nestedTags[nestedTags.length - 1] == lower) {
            output += input[i].toLowerCase();
        } else if (nestedTags[nestedTags.length - 1] == mix) {
            randomNum = Math.floor((Math.random() * 100) + 1);
            if (randomNum % 2) {
                output += input[i].toUpperCase();
            } else {
                output += input[i].toLowerCase();
            }            
        }
    }
    return output;
}


//tests

var text = "We are <mixcase>living</mixcase> in a <upcase>yellow <lowcase>sub</lowcase>marine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";

console.log('Original text');
console.log(text);

console.log();
console.log('First calling the function:')
console.log(parseTags(text));

console.log();
console.log('Second calling the function:')
console.log(parseTags(text));

console.log();
console.log('Third calling the function:')
console.log(parseTags(text));