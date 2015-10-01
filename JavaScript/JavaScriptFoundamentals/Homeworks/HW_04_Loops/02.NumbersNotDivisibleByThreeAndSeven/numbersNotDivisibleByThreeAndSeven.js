//Problem 1. Numbers
//Write a script that prints all the numbers from 1 to N.

var isDivisibleByThree = function isDivisibleByThree(number) {
    return (number % 3 === 0);
}

var isDivisibleBySeven = function isDivisibleBySeven(number) {
    return (number % 7 === 0);
}


function showNumbersNotDivisibleByThreeAndSeven(numberN) {
    var output,
        i;
    
    output = '';
    
    if (numberN < 1) {
        output = 'Invalid input!';
    }
    
    for (i = 1; i <= numberN; i += 1) {        
        if (!(isDivisibleByThree(i) && isDivisibleBySeven(i))) {                    
            if (i === numberN) {
                output += i;
            } else {
                output += i + ', ';
            }
        }
    }
return output;
}

function onShowNumbersNotDivisivleByThreeAbdSevenBtnClick() {
    var numberN,
        output;
    
    numberN = jsConsole.readInteger('#numberN');
    output = 'Numbers from 1 to ' + numberN + ' NOT divisible by 3 and 7: ' + showNumbersNotDivisibleByThreeAndSeven(numberN);
    
    jsConsole.writeLine(output);
}

console.log(showNumbersNotDivisibleByThreeAndSeven(30));