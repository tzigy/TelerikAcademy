//Problem 4. Maximal increasing sequence
//Write a script that finds the maximal increasing sequence in an array.

function finfMaxIncreasingSequence(inputSequence){
    var i, len,
        prevElement, 
        currentElement,
        currentCount = 0,
        currentSequence = [],
        maxCount = 0,
        maxSequence = [];
    
    if (!inputSequence.length) {
        return 'Input sequence is empty';
    }

    prevElement = inputSequence[0];
    currentSequence.push(prevElement);
    currentCount = 1;

    for (i = 1, len = inputSequence.length; i < len; i += 1) {
        currentElement = inputSequence[i];
        if (currentElement <= prevElement) {
            if (maxCount < currentCount) {
                maxCount = currentCount;
                maxSequence = currentSequence.slice(0);
            }
            currentSequence = [];
            currentCount = 0;
        }
        currentSequence.push(currentElement);
        currentCount += 1;
        prevElement = currentElement;        
    }    

    return (currentCount <= maxCount) ? maxSequence : currentSequence;
}

// Tests

var sequence = [3, 2, 3, 4, 7, 8, 2, 2, 4, 5, 7, 8, 9, 11, 14, 35];

console.log('The seqience is: ' + sequence +
            '. The max increasing sequence is: ' + finfMaxIncreasingSequence(sequence));