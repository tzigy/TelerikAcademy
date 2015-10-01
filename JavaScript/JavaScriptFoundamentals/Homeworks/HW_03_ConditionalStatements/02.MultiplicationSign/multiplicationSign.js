//Problem 2. Multiplication Sign
//Write a script that shows the sign(+, -or 0) of the product of three real numbers, without calculating it.
//Use a sequence of if operators.

var numbers_1,
    numbers_2,
    numbers_3,
    numbers_4,
    numbers_5,
    testArray,
    a, b, c,
    i, len;

// This is my main function
function showMultiplicationSign(a, b, c) {
    if (a === 0 || b === 0 || c === 0) {
        return 0;
    } else if ((a < 0 && b < 0 && c < 0) ||
               (a < 0 && b > 0 && c > 0) ||
               (a > 0 && b < 0 && c > 0) ||
               (a > 0 && b > 0 && c < 0)) {
        return '-';
    } else {
        return '+';
    }
}

//test
numbers_1 = {
    a: 5,
    b: 2,
    c: 2
};

numbers_2 = {
    a: -2,
    b: -2,
    c: 1
};

numbers_3 = {
    a: -2,
    b: 4,
    c: 3
};

numbers_4 = {
    a: 0,
    b: -2.5,
    c: 4
};

numbers_5 = {
    a: -1,
    b: -0.5,
    c: -5.1
};


testArray = [numbers_1, numbers_2, numbers_3, numbers_4, numbers_5];

for (i = 0, len = testArray.length; i < len; i += 1) {
    a = testArray[i].a;
    b = testArray[i].b;
    c = testArray[i].c;

    console.log('a=' + a + ', b=' + b + ', c=' + c + ' => the sign is ' + showMultiplicationSign(a, b, c));
}
