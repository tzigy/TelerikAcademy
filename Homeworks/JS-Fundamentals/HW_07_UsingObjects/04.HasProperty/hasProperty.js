//Problem 4. Has property
//Write a function that checks if a given object contains a given property.


//this function find only direct properties
function hasDirectProperty(obj, prop) {
    // two possible solutions. They do the same thing
    //    return obj.hasOwnProperty(prop);
    return Object.prototype.hasOwnProperty.call(obj, prop);
}

//this function is onother possible solution
function hasProperty1(obj, prop) {
    var key;
    
    for (key in obj) {
        if (key === prop) {
            return true;
        }
    }
    return false;
}



//This function find also inherited properties
function hasInheritedProperty(obj, prop) {
    var key;
    if (prop in obj) {
        return true;
    }
    return false;
}

//tests

var testObj = {
    num : 6,
    str : 'this is a string',
    arr : [1, 2, 3],
    innerObj : {
        innerNum : 9,
        innerStr : 'inner string'
    }
};


console.log();
console.log('Using hasDirectProperty function');
console.log('Prop: "innerObj" --> ' + hasDirectProperty(testObj, 'innerObj'));
console.log('Prop: "toString" --> ' + hasDirectProperty(testObj, 'toString'));
console.log('');
console.log('Using hasInheritedProperty function');
console.log('Prop: "innerObj" --> ' + hasInheritedProperty(testObj, 'innerObj'));
console.log('Prop: "toString" --> ' + hasInheritedProperty(testObj, 'toString'));

