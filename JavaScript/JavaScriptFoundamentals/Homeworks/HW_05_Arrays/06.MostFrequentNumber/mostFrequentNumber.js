//Problem 6. Most frequent number
//Write a script that finds the most frequent number in an array.

function findMostFrequentNumber(inputArray){
    var i, len,
        args,                
        currentNumber,        
        mostFrequentNumber,        
        maxCount,
        count = 0,
        positions = [];
    
    //taking arguments from recursion call
    args = [].slice.apply(arguments);
    mostFrequentNumber = args[1] || inputArray[0];
    maxCount = args[2] || 0;
    
    //the stop condition for the recursion 
    if (!inputArray.length) {
        return (mostFrequentNumber + ' (' + maxCount + ' times)');
    }

    currentNumber = inputArray[0];
    inputArray.splice(0, 1);
    count = 1;
    
    //counting the current number and taking the positions ot equal elements
    for (i = 0, len = inputArray.length; i < len; i += 1) {        
        if (currentNumber === inputArray[i]) {
            count += 1;
            positions.push(i);
        }        
    }
    //deleting all occurrences of current number
    for (i = 0, len = positions.length; i < len; i += 1) {
        inputArray.splice(positions[i], 1);       
    }
    
    if(maxCount < count){     
        maxCount = count;
        mostFrequentNumber = currentNumber;
    } 

    return findMostFrequentNumber(inputArray, mostFrequentNumber, maxCount);
}

console.log(findMostFrequentNumber([4, 1, 1, 4, 4, 4, 2, 3, 4, 4, 1, 2, 4, 9, 1, 1, 3]));


//function findMostFrequentNumber(inputArray) {
//    var i, len,
//        prevNumber,
//        currentNumber,        
//        mostFrequentNumber,
//        count = 0,
//        maxCount = 0;
    
//    inputArray.sort();
//    prevNumber = inputArray[0];
    
//    for (i = 0, len = inputArray.length; i < len; i += 1) {
//        currentNumber = inputArray[i];
//        if (prevNumber !== currentNumber) {
//            if (maxCount < count) {
//                maxCount = count;
//                mostFrequentNumber = prevNumber;
//            }
//            prevNumber = currentNumber;
//            count = 0;
//        }
//        count += 1;
//    }
//    console.log(inputArray);
//    return (count <= maxCount) ? (mostFrequentNumber + ' (' + maxCount + ' times)') : (currentNumber + ' (' + count + ' times)');
//}