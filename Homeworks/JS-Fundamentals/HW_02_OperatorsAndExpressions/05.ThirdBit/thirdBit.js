//Problem 5. Third bit
//Write a boolean expression for finding if the bit # 3(counting from 0) of a given integer.
//The bits are counted from right to left, starting from bit #0.
//The result of the expression should be either 1 or 0.

function findThirdBit(num){   
    return (num & 4) === 4 ? 1 : 0;
}

//another solution. 32bit numbers with leading zeros
function findThirdBit2(num) {
    num = '00000000000000000000000000000000'.substr(num.toString(2).length) + num.toString(2);
    return num[29];
}
 

//Test

var testArray = [5, 8, 0, 15, 5343, 62241];

for (var i = 0; i < testArray.length; i++) {
    console.log('The bit #3 (counting from 0) of the number ' + testArray[i] + ' is ' + findThirdBit(testArray[i]));
}