//Problem 1. Numbers
//Write a script that prints all the numbers from 1 to N.

function showNumbersToN(numberN){
    var output,
        i;
    
    output = '';
    //We have to order the numbers from 1 to N, This means, that N have to be greater or equal 1. 
    //It is also possible to print the numbers in reversed order, but this is not a big deal. 
    if (numberN < 1) {
        output = 'Invalid input!';
    }
        
    for (i = 1; i <= numberN; i += 1) {
        if (i === numberN) {
            output += i;
        } else {
            output += i + ', ';
        }        
    }
    return output;
}

function onShowNumbersToNBtnClick() {
    var numberN,
        output;
        
    numberN = jsConsole.readInteger('#numberN');
    output = 'Numbers from 1 to ' + numberN + ': ' + showNumbersToN(numberN);

    jsConsole.writeLine(output);
}

console.log(showNumbersToN(20));