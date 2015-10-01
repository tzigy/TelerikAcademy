//Problem 8. Number as words
//Write a script that converts a number in the range [0…999] to words, corresponding to its English pronunciation.


// it can be done with array. It is more compact and may be faster, bacause you can take direkt the word using the number as index.
// I use switch, because it is an homework for conditional statements
var getDigit = function getDigit(digit){
    var digitAsWord;

    digitAsWord = 'Invalid digit!';

    switch (digit) {
        case 0 : digitAsWord = 'Zero';
            break;
        case 1: digitAsWord = 'One';
            break;
        case 2: digitAsWord = 'Two';
            break;
        case 3: digitAsWord = 'Three';
            break;
        case 4: digitAsWord = 'Four';
            break;
        case 5: digitAsWord = 'Five';
            break;
        case 6: digitAsWord = 'Six';
            break;
        case 7: digitAsWord = 'Seven';
            break;
        case 8: digitAsWord = 'Eight';
            break;
        case 9: digitAsWord = 'Nine';
            break;
    }
    return digitAsWord;
}

//the same situation. You can use array and taking the element using index (number - 2)
var getTeens = function getTeens(number){
    var teensAsWord;
    
    teensAsWord = 'Invalid teen input!';
    
    switch (number) {
        case 10: teensAsWord = 'Ten';
            break;
        case 11: teensAsWord = 'Eleven';
            break;
        case 12: teensAsWord = 'Twelve';
            break;
        case 13: teensAsWord = 'Thirteen';
            break;
        case 14: teensAsWord = 'Fourteen';
            break;
        case 15: teensAsWord = 'Fifteen';
            break;
        case 16: teensAsWord = 'Sixteen';
            break;
        case 17: teensAsWord = 'Seventeen';
            break;
        case 18: teensAsWord = 'Eighteen';
            break;
        case 19: teensAsWord = 'Nineteen';
            break;           
    }
    return teensAsWord;
}

var getTens = function getTens(number){
    var tensAsWord;

    tensAsWord = 'Invalid tens input!';

    switch (number) {
        case 2: tensAsWord = 'Twenty';
            break;
        case 3: tensAsWord = 'Thirty';
            break;
        case 4: tensAsWord = 'Fourty';
            break;
        case 5: tensAsWord = 'Fifty';
            break;
        case 6: tensAsWord = 'Sixty';
            break;
        case 7: tensAsWord = 'Seventy';
            break;
        case 8: tensAsWord = 'Eighty';
            break;
        case 9: tensAsWord = 'Ninety';
            break;
    }
    
    return tensAsWord;
}

//function convertZeroToNineteen(number) {
//    var zeroToNineteenArray = ['Zero', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine', 'Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen', 'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen'];
    
//    return zeroToNineteenArray[number];
//}

function convertTens(number) {
    var output,
        tens,
        ones;
    
  //  tensArray = ['Twenty', 'Thirty', 'Fourty', 'Fifty', 'Sixty', 'Seventy', 'Eighty', 'Ninety'];
    tens = Math.floor(number / 10);
    ones = (number % 10);
    
    if (number < 10) {
        output = getDigit(number);
    } else if (number < 20) {
        output = getTeens(number);
    } else {
        output = getTens(tens);        
        if (ones !== 0) {
            output += ' ' + getDigit(ones).toLowerCase();
        }
    }
    
    return output;
}

function convertHundreds(number) {
    var hundreds,
        tens, 
        output;
    
    hundreds = Math.floor(number / 100);
    tens = (number % 100);
    
    output = getDigit(hundreds) + ' hundred';
    
    if (0 < tens) {        
            output += ' and ' + convertTens(tens).toLowerCase();        
    }
    
    return output;
}

function convertNumberAsWord(number) {
    var numberAsWord;
    
    if (number < 0 || number > 999) {
        numberAsWord = 'Number out of range!';
    } else if (number < 100) {
        numberAsWord = convertTens(number);
    } else {
        numberAsWord = convertHundreds(number);
    }
    
    return numberAsWord;
}

//helping function 
function onNumberAsWordBtnClick() {
    var number;
    
    number = jsConsole.readFloat('#number');
    
    jsConsole.writeLine("Number: " + number + ' as word -> ' + convertNumberAsWord(number));
}


//Test -> console or node.js tests

var testArray, i, len, num;

testArray = [0, 9, 10, 12, 19, 25, 98, 273, 400, 501, 617, 711, 999];

for (i = 0, len = testArray.length; i < len; i += 1) {
    num = testArray[i];
    console.log("Number: " + num + ' as word -> ' + convertNumberAsWord(num));
}
