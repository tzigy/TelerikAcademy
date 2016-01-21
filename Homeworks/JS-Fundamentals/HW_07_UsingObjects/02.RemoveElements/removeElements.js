//Problem 2. Remove elements
//Write a function that removes all elements with a given value.
//Attach it to the array type.

Array.prototype.remove = function (value) {
    
    while (this.indexOf(value) >= 0) {
        this.splice(this.indexOf(value), 1);
    }
    return this;
}

//Another possible solution using for construction
Array.prototype.remove2 = function (value){
    var i, len,
        possitions = [];

    for (i = 0, len = this.length; i < len; i += 1) {
        if (value === this[i]) {
            possitions.push(i);
        }
    }

    for (i = possitions.length - 1; 0 <= i; i -= 1) {
        this.splice(possitions[i], 1);
    }
    return this;
}

//test
var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
console.log('Original array: ' + arr);
console.log('Array after removing 1: ' + arr.remove(1));
console.log('NOTE that the last "1" is a string, therefore is not removed');
