//Problem 1. Reverse string
//Write a JavaScript function that reverses a string and returns it.

function reverseString(input){
    var i, 
        output = '';

    for (i = input.length - 1; i >= 0; i -= 1) {
        output += input[i];
    }
    return output;
}

//Tests

console.log(reverseString('sample'));