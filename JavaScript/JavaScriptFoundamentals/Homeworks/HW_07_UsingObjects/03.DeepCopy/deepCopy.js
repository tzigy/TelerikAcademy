//Problem 3. Deep copy
//Write a function that makes a deep copy of an object.
//The function should work for both primitive and reference types.

//function deepCopy(object){
//    var prop,
//        newObject = {};
//    console.log(typeof object);
//    switch (typeof object) {        
//        case 'number': newObject = object; break;
//        case 'string': newObject = object; break;
//        case 'boolean': newObject = object; break;
//        case 'null': newObject = object; break;
//        case 'undefined': newObject = object; break;
//        case 'object': newObject = function (object) {
//                for (prop in object) {
//                    console.log(prop);
//                    console.log(object[prop]);
//                }
//            }; break;
//    }

//    return newObject;
//}

function deepCopy(obj) {
    if (obj === null || typeof (obj) !== 'object'){
        return obj;
}
    
    var temp = obj.constructor(); // changed
    
    for (var key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
            temp[key] = deepCopy(obj[key]);
        }
    }
    return temp;
}


//console.log(deepCopy(true));

var testObj,
    clonedObject,
    output = '',
    level = '';

testObj = {
    num : 6,
    str : 'this is a string',
    arr : [1, 2, 3],
    innerObj : {
        innerNum : 9,
        innerStr : 'inner string'
    }
};

clonedObject = deepCopy(testObj);

console.log('Original object: ');
readProperties(testObj);

console.log();
console.log('Cloned object: ');
readProperties(clonedObject);

console.log();
console.log('Changing the original object');

testObj.num = 25;
testObj.str = 'new string';

console.log('New original object: ');
readProperties(testObj);

console.log();
console.log('Cloned object is still the same: ');
readProperties(clonedObject);

//this function help me to print all propertis 
function readProperties(val) {
    if (Object.prototype.toString.call(val) === '[object Object]') {
        for (var propertyName in val) {
            if (val.hasOwnProperty(propertyName)) {
                console.log(level + propertyName + ':');
                level += '  ';
                readProperties(val[propertyName]);
            }
        }
    }
    else {
        console.log(level + val);
        level = level.substring(0, level.length - 2);
    }
}