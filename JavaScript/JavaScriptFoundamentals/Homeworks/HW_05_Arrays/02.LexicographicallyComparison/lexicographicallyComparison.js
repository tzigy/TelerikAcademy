//Problem 2. Lexicographically comparison
//Write a script that compares two char arrays lexicographically (letter by letter).

function compareLexicographically(charArray1, charArray2) {
    var i, len, output, currentChar1, currentChar2;
    
    if (charArray1.length !== charArray2.length) {
        output = 'Arrays have different length!';
    } else {
        output = 'Lexicographically comparison:\n';
        for (i = 0, len = charArray1.length; i < len; i += 1) {
            currentChar1 = charArray1[i];
            currentChar2 = charArray2[i];
            
            if (currentChar1 < currentChar2) {
                output += currentChar1 + ' < ' + currentChar2 + '\n';
            } else if (currentChar1 > currentChar2) {
                output += currentChar1 + ' > ' + currentChar2 + '\n';
            } else {
                output += currentChar1 + ' = ' + currentChar2 + '\n';
            }
        }
    }
    
    return output;
}

console.log(compareLexicographically(['a', 'b', 'c', 'd', 'e', 'f', 'a', '123', 'John', 'Naomi'], ['a', 'b', 'c', 'g', 'e', 'n', 'j', '2', 'Pesho', 'Ivan']));


