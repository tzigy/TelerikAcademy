//Problem 5. nbsp
//Write a function that replaces non breaking white-spaces in a text with &nbsp ;

String.prototype.splice = function (idx, rem, s) {
    return (this.slice(0, idx) + s + this.slice(idx + Math.abs(rem)));
};

function replaceWhiteSpace(text) {
    return (text.split(' ').join('&nbsp;'));
}

//onother possible solution
function replaceWhiteSpace2(text){
    var i, 
        possitions = [];

    for (i = 0; i < text.length; i += 1) {
        if (text[i] === ' ') {
            possitions.push(i);
        }
    }

    for (i = possitions.length - 1; i >= 0; i -= 1) {
        
        text = text.splice(possitions[i], -1, '&nbsp');
    }

    return text;
}


//tests

var text = "We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

console.log('Original text: \n' + text);
console.log();
console.log('After raplacing all white spaces: \n' + replaceWhiteSpace(text));