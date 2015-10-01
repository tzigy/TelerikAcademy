//Problem 4. Third digit
//Write an expression that checks for given integer if its third digit(right - to - left) is 7.

function isThirdDigitSeven(num){
    var output = false,
        numAsString = num.toString(),
        numLength = numAsString.length;

    if ((numLength >= 3) && 
        (numAsString[numLength - 3] == 7)) {
        output = true;
    }
    return output;
}

//Test

var testArray = [5, 701, 1732, 9703, 877, 777877, 9999799];

for (var i = 0; i < testArray.length; i++) {
    console.log('The third digit of number ' + testArray[i] + ' is 7: ' + isThirdDigitSeven(testArray[i]));
}
