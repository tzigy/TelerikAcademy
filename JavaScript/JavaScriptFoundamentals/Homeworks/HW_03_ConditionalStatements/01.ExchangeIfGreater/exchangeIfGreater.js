//Problem 1. Exchange if greater
//Write an if statementthat takes two double variables a and b and exchanges their values if thefirst one is greater than the second.
//As a result print the values a and b, separated by a space.

function returnSmallerFirst(a, b) {
    var output = a + ' ' + b;
    if (a > b) {
        output = b + ' ' + a;
    }
    return output;
}

//test
var pair_1,
    pair_2,
    pair_3,
    a,
    b,
    i,
    len,
    testArray;


pair_1 = {
    a: 5,
    b: 2
};

pair_2 = {
    a: 3,
    b: 4
};

pair_3 = {
    a: 5.5,
    b: 4.5
};

testArray = [pair_1, pair_2, pair_3];

for (i = 0, len = testArray.length; i < len; i += 1) {
    a = testArray[i].a;
    b = testArray[i].b;
    console.log('a=' + a + ' b=' + b + ' result=' + returnSmallerFirst(a, b));
}