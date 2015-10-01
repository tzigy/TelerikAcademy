//Problem 6. Larger than neighbours
//Write a function that checks if the element at given position in given array of integers is bigger than its two neighbours(when such exist) .


//Solution of Problem 06
function isLargerThanNeighbours(array, index) {
    var isLarger;
    //if (index < 0 || index > array.length - 1) {
    //    return 'Index out of range!'; // we can also return false
    //} else if ((index - 1) < 0) {
    //    return 'No prev neighbour!'; // we can also return false
    //} else if ((index + 1) > array.length - 1) {
    //    return 'No next neighbour!'; // we can also return false
    //}
    
    isLarger = !(index <= 0 || index >= array.length - 1) &&
                (array[index - 1] < array[index]) && 
                (array[index + 1] < array[index]);
    
    return isLarger;
}

//Solution of Problem 07
function findFirstLargerThanNeighbours(array) {
    var i, len;
    
    for (i = 0, len = array.length; i < len; i += 1) {
        if (isLargerThanNeighbours(array, i)) {
            return i;
        }
    }
    return -1;
}


//tests for Problem 06
var i, len,
    testArray = [2, 3, 1, 5, 4, 7, 9, 8, 12 , 11, 6],
    secondTestArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];

console.log('Start tests Problem 06');
console.log('Array: ' + testArray);

for (i = 0, len = testArray.length; i < len; i += 1) {
    
    console.log('The element at index ' + i + ' is bigger than its neighbors: ' + isLargerThanNeighbours(testArray, i));
}

console.log('The element at index 20 is bigger than its neighbors: ' + isLargerThanNeighbours(testArray, 20));

console.log('End tests Problem 06\n');

//tests for Problem 07

console.log('Start tests Problem 07');
console.log('Array: ' + testArray);
console.log('The first element larger than its neighbours is at index: ' + findFirstLargerThanNeighbours(testArray));
console.log('\nArray: ' + secondTestArray);
console.log('The first element larger than its neighbours is at index: ' + findFirstLargerThanNeighbours(secondTestArray));

console.log('End tests Problem 07\n');