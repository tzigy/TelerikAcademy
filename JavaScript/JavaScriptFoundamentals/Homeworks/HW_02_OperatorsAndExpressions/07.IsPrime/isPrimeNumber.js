//Problem 7. Is prime
//Write an expression that checks if given positive integer number n(n ≤ 100) is prime.

function isPrimeNumber(number){
    if (number > 100) {
        return 'Invalid input';
    }
    var output = (number < 2) ? false : true;
    for (var devisor = 2; devisor <= Math.sqrt(number); devisor++) {
        if (number % devisor == 0) {
            output = false;
        }
    }
    return output;
}

//Test

var testArray = [1, 2, 3, 4, 9, 37, 97, 51, -3, 0];

for (var i = 0; i < testArray.length; i++) {
    console.log('The number '+ testArray[i] + ' is prime: ' + isPrimeNumber(testArray[i]));
}

