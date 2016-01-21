//Problem 5. Selection sort
//Sorting an array means to arrange its elements in increasing order.
//Write a script to sort an array.
//Use the selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
//Hint: Use a second array


//For my solution I use recursive method
function selectionSort(inputArray) {
    var i, len, min,
        args,
        sortedArray, 
        position = 0;
    
        //I make sortedArray to put 
    args = [].slice.apply(arguments);
    sortedArray = args[1] || [];
    
    //The termination condition
    if (!inputArray.length) {
        return sortedArray;
    }
    
    min = inputArray[0];
    for (i = 1, len = inputArray.length; i < len; i += 1) {
        if (inputArray[i] < min) {
            min = inputArray[i];
            position = i;
        }
    }
    
    sortedArray.push(min);
    inputArray.splice(position, 1);
    
    return selectionSort(inputArray, sortedArray);
}

//tests
console.log(selectionSort([3, 1, 2, 9, 9, 9, 4, 6, 3, 12, 8, 15, 12]));