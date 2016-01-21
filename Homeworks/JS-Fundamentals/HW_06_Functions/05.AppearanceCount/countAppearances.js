//Problem 5. Appearance count
//Write a function that counts how many times given number appears in given array.
//Write a test function to check if the function is working correctly.


function countAppearances(inputArray, number){
    var i, len,
        currentNumber, 
        count = 0;

    inputArray = inputArray || [];

    for (i = 0, len = inputArray.length; i < len; i += 1) {
        currentNumber = inputArray[i];
        if (number === currentNumber) {
            count += 1;
        }
    }
    return count;
}

function testCountAppearances(inputArray, number, expectedResult){
  
    return countAppearances(inputArray, number) === expectedResult;
}

//Tests

var i, 
    array,
    number,
    expectedResult,
    currentObj,
    funcResult,
    testObjects;

testObjects = {
    firstObj : {
        array : [1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 1, 3, 6, 8, 6],
        number: 6,
        expectedResult : 3
    },

    secondObj : {
        array : [1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 1, 3, 6, 8, 6, 1, 1],
        number: 1,
        expectedResult : 5
    },

    thirdObj : {
        array : [9, 9, 9, 9, 9, 5, 56, 34, 78],
        number: 3,
        expectedResult : 0
    },
};

for (i in testObjects) {
    currentObj = testObjects[i];
    array = currentObj.array;
    number = currentObj.number;
    expectedResult = currentObj.expectedResult;
    
    funcResult = countAppearances(array, number);
    console.log('Function result is ' + funcResult);
    console.log('Expected result is ' + expectedResult);
    console.log('=> Function is ' + (testCountAppearances(array, number, expectedResult) ? 'working correctly!\n' : 'NOT working correctly!\n'));
}

