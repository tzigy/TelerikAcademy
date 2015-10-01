//Problem 6. Quadratic equation
//Write a script that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
//Calculates and prints its real roots.
//Note: Quadratic equations may have 0, 1 or 2 real roots.

function calculateQuadraticEquationRoots(a, b, c){
    var x1,
        x2, 
        discriminant,
        output;
    
    output = 'The quadratic equation: ' + a + 'x*x + ' + b + 'x + ' + c + ' has ';

    discriminant = Math.sqrt(b * b - 4 * a * c);    

    if (isNaN(discriminant)) {
        output += 'no real roots';        
    } else if (discriminant === 0) {        
        x1 = -b / (2 * a);
        output += 'one real root: x1=x2=' + x1;
    } else {
        x1 = (-b - discriminant) / (2 * a);
        x2 = (-b + discriminant) / (2 * a);
        output += 'two real roots: x1=' + x1 + ', x2=' + x2;
    }
    return output;
}

function onCalculateQuadraticEquationBtnClick(){
    var a, b, c;

    a = jsConsole.readFloat('#a_number');
    b = jsConsole.readFloat('#b_number');
    c = jsConsole.readFloat('#c_number');

    jsConsole.writeLine(calculateQuadraticEquationRoots(a, b, c));
}



console.log(calculateQuadraticEquationRoots(5, 2, 8));