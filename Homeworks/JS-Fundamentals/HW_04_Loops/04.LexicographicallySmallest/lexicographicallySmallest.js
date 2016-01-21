//Problem 4. Lexicographically smallest
//Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects.

function findLexicographicallySmallestAndLargest(element) {
    var props = [];
    
    for (var propName in element) {        
        props.push(propName);
    }
    props.sort();
    
    
    jsConsole.writeLine('Object: ' + element);
    jsConsole.writeLine("---> lexicographically smallest: " + props[0]);
    jsConsole.writeLine("---> lexicographically largest: " + props[props.length - 1]);
    jsConsole.writeLine();
}