//Problem 1. English digit
//Write a function that returns the last digit of given integer as an English word.

function showLastDigitAsWord(number){
    var lastDigit;
    
    number = ((number < 0) ? (number * -1) : number);
    lastDigit = number % 10;
    
    //here break is not necessery, because return stop the forward execution and return value. 
    switch (lastDigit) {
        case 0: return 'Zero';
        case 1: return 'One';
        case 2: return 'Two';
        case 3: return 'Three';
        case 4: return 'Four';
        case 5: return 'Five';
        case 6: return 'Six';
        case 7: return 'Seven';
        case 8: return 'Eight';
        case 9: return 'Nine';
        default: return 'Invalid number';   
    }
    
}

//tests

var i, len,
    currentNumber,
    testArray = [-123, -56, 17, 9, 0, 1, 512, 1024, 12309];

console.log('Last digit as word:');
for (i = 0, len = testArray.length; i < len; i += 1) {
    currentNumber = testArray[i];
    console.log(currentNumber + ' -> ' + showLastDigitAsWord(currentNumber));
}