//Problem 3. The biggest of Three
//Write a script that finds the biggest of three numbers.
//Use nested if statements.


// The main function
function takeBiggestOfThreeNumbers(firstNum, secondNum, thirdNum) {
    var result = firstNum;

    if (result < secondNum) {
        result = secondNum;
        if (result < thirdNum) {
            result = thirdNum;
        }
    } else if (result < thirdNum) {
        result = thirdNum;
    }

    return result;
};

//Some help function

function onTakeBiggestBtnClick() {
    var a, b, c;

    a = jsConsole.readFloat('#first-number');
    b = jsConsole.readFloat('#second-number');
    c = jsConsole.readFloat('#third-number');

    jsConsole.writeLine('The biggest number is: ' + takeBiggestOfThreeNumbers(a, b, c));
}


//tests!!! You can use node.js to start the apolication. Or you can start the index.html file

function ThreeNumbersCollection(a, b, c) {
    this.firstNum = a,
    this.secondNum = b,
    this.thirdNum = c
};

var numCollectionOne,
    numCollectionTwo,
    numCollectionThree,
    numCollectionFour,
    numCollectionFive,
    testArray,
    i, len,
    a, b, c;

numCollectionOne = new ThreeNumbersCollection(5, 2, 2);
numCollectionTwo = new ThreeNumbersCollection(-2, -2, 1);
numCollectionThree = new ThreeNumbersCollection(-2, 4, 3);
numCollectionFour = new ThreeNumbersCollection(0, -2.5, 5);
numCollectionFive = new ThreeNumbersCollection(-0.1, -0.5, -1.1);

testArray = [numCollectionOne, numCollectionTwo, numCollectionThree, numCollectionFour, numCollectionFive];


for (i = 0, len = testArray.length; i < len; i += 1) {
    a = testArray[i].firstNum;
    b = testArray[i].secondNum;
    c = testArray[i].thirdNum;
    console.log('a=' + a + ', b=' + b + ', c=' + c + ': => the biggest of them is: ' + takeBiggestOfThreeNumbers(a, b, c));
}
