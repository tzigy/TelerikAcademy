//Problem 1. Odd or Even
//Write an expression that checks if giveninteger is odd or even.

//First solution
function oddOrEven(num) {
    if (num % 2 === 0) {
        return 'even';
    } else {
        return 'odd';
    }
}

//Second possible solution
function oddOrEven2(num){
    return (num % 2) ? 'odd' : 'even'; 
}

//Third possible solution
function oddOrEven3(num) {
    return (num & 1) ? 'odd' : 'even';
}

//another way solve the problem - return only true or false
function isOdd(num){
    return (num & 1) == true;
}

function isEven(num) {
    return !(num & 1) == true;
}

//Some test

var testArray = [3, 2, -2, -1, 0];

for (num in testArray) {
    console.log('The number ' + testArray[num] + ' is ' + oddOrEven(testArray[num]));
}

//using the isOdd function
console.log('\nusing the "isOdd" function!');
for (var i = 0; i < testArray.length; i++) {
    console.log('The number ' + testArray[i] + ' is odd: ' + isOdd(testArray[i]));
}