//Problem 2. Correct brackets
//Write a JavaScript function to check if in a given expression the brackets are put correctly.
//Example of correct expression:((a+b) / 5 - d). Example of incorrect expression: )(a+b)).

function isCorrectBrackets(expr){
    var i,
        currentSymbol,         
        openBrackets = 0;

    for (i = 0; i < expr.length; i += 1) {
        currentSymbol = expr[i];

        if (currentSymbol === '(') {
            openBrackets += 1;
        }

        if (currentSymbol === ')') {
            if (openBrackets === 0) {
                return 'Expression is NOT correct!';
            } else {
                openBrackets -= 1;
            }
        }
    }

    return (!openBrackets ? 'Expression is correct!' : 'Expression is NOT correct!');
}

//tests
var expr1, expr2, expr3;

expr1 = '((a + b) / 5 - d)';
expr2 = '((a + b) / 5 - d';
expr3 = ')(a+b))';


console.log(expr1 + ': ' + isCorrectBrackets(expr1));
console.log(expr2 + ': ' + isCorrectBrackets(expr2));
console.log(expr3 + ': ' + isCorrectBrackets(expr3));
