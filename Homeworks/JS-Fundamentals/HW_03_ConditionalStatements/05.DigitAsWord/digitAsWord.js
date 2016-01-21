//Problem 5. Digit as word
//Write a script that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
//Print “not a digit” in case of invalid input.
//Use a switch statement.

function returnDigitAsWord(digit){

    var digitAsWord = 'not a digit';

    switch (digit) {
        case 0:
            digitAsWord = 'Zero';
            break;
        case 1:
            digitAsWord = 'One';
            break;
        case 2:
            digitAsWord = 'Two';
            break;
        case 3:
            digitAsWord = 'Three';
            break;
        case 4:
            digitAsWord = 'Four';
            break;
        case 5:
            digitAsWord = 'Five';
            break;
        case 6:
            digitAsWord = 'Six';
            break;
        case 7:
            digitAsWord = 'Seven';
            break;
        case 8:
            digitAsWord = 'Eight';
            break;
        case 9:
            digitAsWord = 'Nine';
            break;
    }

    return digitAsWord;
}

// Tests -> these tests you can test with node.js. You can start an index.html file to test in browser and to give own numbers.

var testArray,
    i, len,
    digit;

testArray = [2, 1, 0, 5, -0.1, 'hi', 9, 10];

for (i = 0, len = testArray.length; i < len; i += 1) {
    digit = testArray[i];
    console.log("Digit: " + digit + ' as word -> ' + returnDigitAsWord(digit));
}

//helper function

function onDigitAsWordBtnClick(){
    var digit;

    digit = jsConsole.readFloat('#digit');

    jsConsole.writeLine("Digit: " + digit + ' as word -> ' + returnDigitAsWord(digit));
}