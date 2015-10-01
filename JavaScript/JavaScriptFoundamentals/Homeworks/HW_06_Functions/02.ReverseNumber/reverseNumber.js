//Problem 2. Reverse number
//Write a function that reverses the digits of given decimal number.


//sulution 1 
function reverseNumber1(number) {
    var i, len, 
        reversedNumber = '';

    number = number.toString();
    for (i = (number.length -1); i >= 0; i -= 1) {
        reversedNumber += number[i];
    }
    return parseFloat(reversedNumber);
}

//sulution 2
function reverseNumber2(number) {
    var numberAsArray, 
        reversedNumberAsString = '';
    
    numberAsArray = number.toString().split('');
    reversedNumberAsString = numberAsArray.reverse().join('')

    return parseFloat(reversedNumberAsString);
}

//solution 3 Working only for integer numbers
function reverseInt(number) {
    
    var r = 0;
    while (number != 0) {
        r *= 10;
        r += number % 10;
        number = Math.floor(number / 10);
    }
    return r;
}

//Tests

var i, len, number, testArray;

testArray = [123, 98765, 4567.8899, 256, 123.45];

for (i = 0, len = testArray.length; i < len; i += 1) {
    number = testArray[i];
    console.log(number + ' -----> ' + reverseNumber1(number));
}