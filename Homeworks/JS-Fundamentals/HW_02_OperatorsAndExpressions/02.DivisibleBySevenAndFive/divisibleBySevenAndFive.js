//Problem 2. Divisible by 7 and 5
//Write a boolean expression that checks for given integer if it can be divided(without remainder) by 7 and 5 in the same time.

function isDivisibleBySevenAndFive(num) {
    return ((num % 5 === 0) && (num % 7 === 0));
}

//test
var testArray = [3, 0, 5, 7, 35, 140];

for (var i = 0; i < testArray.length; i++) {
    console.log('The number ' + testArray[i] + ' is devisible by 5 and 7: ' + isDivisibleBySevenAndFive(testArray[i]));
}