//Problem 7. Binary search
//Write a script that finds the index of given element in a sorted array of integers by using the binary search algorithm.

//I implemented two solution - with and without recursion. There are tests for bouth ot them. Start with console or with node.js

//Solution without recursion
function binarySearch(sortedArray, value) {
    var start,     
        middle,
        end,
        currentElement;
    
    
    start =  0;
    end = sortedArray.length - 1;
        
    while (start <= end) {
        middle = ((start + end) / 2) | 0;
        currentElement = sortedArray[middle];
        if (value === currentElement) {
            return middle;
        } else if(value < currentElement){
            end = middle - 1;
        } else {
            start = middle + 1;
        }
    }
    //The function returns -1 if there is no such element in the array
    return -1;
}

//Sulution with recursion
function binarySearchRecursiv(sortedArray, value) {
    var start,     
        middle,
        end,
        args,
        currentValue;
    
    args = [].slice.apply(arguments);    
    start = args[2] || 0;
    end = ((args[3] == undefined) ? (sortedArray.length - 1) : args[3]);    
   
    if (end < start) {
        return -1;
    }
    
    middle = ((start + end) / 2) | 0;
    currentElement = sortedArray[middle];

    if (value === currentElement) {
        return middle;
    } else if (value < currentElement) {
        return binarySearchRecursiv(sortedArray, value, start, (middle - 1));
    } else {
        return binarySearchRecursiv(sortedArray, value, (middle + 1), end);
    }   
}


//Tests

var i, index,
    sortedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 15, 17, 20];

console.log('using NOT recursive function');
console.log(sortedArray);
for (i = 0; i <= 20; i += 1) {
    index = binarySearch(sortedArray, i);
    console.log('Value ' + i + ' is at index ' + ((index === -1) ? 'No such value!' : index));
}
console.log();
console.log('using recursive function');
console.log(sortedArray);
for (i = 0; i <= 20; i += 1) {
    index = binarySearchRecursiv(sortedArray, i);
    console.log('Value ' + i + ' is at index ' + ((index === -1) ? 'No such value!' : index));
}