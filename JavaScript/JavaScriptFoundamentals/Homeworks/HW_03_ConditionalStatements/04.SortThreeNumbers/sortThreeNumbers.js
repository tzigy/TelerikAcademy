//Problem 4. Sort 3 numbers
//Sort 3 real values in descending order.
//Use nested if statements.
//Note: Don’t use arrays and the built-in sorting functionality.

function sortThreeNumbersDescending(a, b, c) {
    var output,
        minNum,
        middleNum,
        maxNum;
    
    if (a < b) {
        if (b < c) {            
            minNum = a;
            middleNum = b;
            maxNum = c;
        } else if (a < c) {
            minNum = a;
            middleNum = c;
            maxNum = b;
        } else {
            minNum = c;
            middleNum = a;
            maxNum = b;
        }
    } else {
        if (a < c) {
            minNum = b;
            middleNum = a;
            maxNum = c;
        } else if (b < c) {
            minNum = b;
            middleNum = c;
            maxNum = a;
        } else {
            minNum = b;
            middleNum = b;
            maxNum = a;
        }
    }

    return  maxNum + ' ' + middleNum + ' ' + minNum;
}

//Some help function

function onOrderNumbersBtnClick() {
    var a, b, c;
    
    a = jsConsole.readFloat('#first-number');
    b = jsConsole.readFloat('#second-number');
    c = jsConsole.readFloat('#third-number');
    
    jsConsole.writeLine('Numbers sorted in descending order: ' + sortThreeNumbersDescending(a, b, c));
}

//tests!!! You can use node.js to start the apolication. Or you can start the index.html file

function ThreeNumbersCollection(a, b, c) {
    this.firstNum = a,
    this.secondNum = b,
    this.thirdNum = c
};

var coll_1,
    coll_2,
    coll_3,
    coll_4,
    coll_5,
    coll_6,
    coll_7,
    testArray,
    i, len,
    a, b, c;

coll_1 = new ThreeNumbersCollection(5, 1, 2);
coll_2 = new ThreeNumbersCollection(-2, -2, 1);
coll_3 = new ThreeNumbersCollection(-2, 4, 3);
coll_4 = new ThreeNumbersCollection(0, -2.5, 5);
coll_5 = new ThreeNumbersCollection(-1.1, -0.5, -0.1);
coll_6 = new ThreeNumbersCollection(10, 20, 30);
coll_7 = new ThreeNumbersCollection(1, 1, 1);


testArray = [coll_1, coll_2, coll_3, coll_4, coll_5, coll_6, coll_7];


for (i = 0, len = testArray.length; i < len; i += 1) {
    a = testArray[i].firstNum;
    b = testArray[i].secondNum;
    c = testArray[i].thirdNum;
    console.log('Numbers a=' + a + ', b=' + b + ', c=' + c + ' sorted in descending order: ' + sortThreeNumbersDescending(a, b, c));
}
