//Problem 3 Maximal sequence
//Write a script that finds the maximal sequence of equal elements in an array.

function findMaxSubSequence(inputSequence){
    var i, len,
        prevElement,
        currentElement,
        currentCount = 0,
        maxCount = 0,
        currentSubSequence = [],
        maxSubSequence = [];
         
    if (!inputSequence.length) {
        return 'Input sequence is empty';
    }
    
    prevElement = inputSequence[0];
     
    for (i = 0, len = inputSequence.length; i < len; i += 1) {
        currentElement = inputSequence[i];
        if (prevElement !== currentElement) {            
            //if we have more than one subsequences with the same length, it will show only the first one
            if (maxCount < currentCount) {
                maxCount = currentCount;
                maxSubSequence = currentSubSequence.slice(0);
            }
            currentSubSequence = [];
            currentCount = 0;
        }
        currentSubSequence.push(currentElement);
        currentCount += 1;
        prevElement = currentElement;
    }

    return (currentCount <= maxCount ? maxSubSequence : currentSubSequence);
}

// tests

var sequenceArray = [[2, 1, 1, 1, 2, 3, 3, 2, 2, 2, 3, 3, 3],
                     [5, 5, 5, 6, 5, 4, 4, 6, 6, 6, 6],
                     [1, 1, 1, 2, 2, 3]];

for (i = 0, len = sequenceArray.length; i < len; i += 1) {
    console.log('The sequence is: ' + sequenceArray[i] +
            '. where the max subsequence is: ' + findMaxSubSequence(sequenceArray[i]));
}