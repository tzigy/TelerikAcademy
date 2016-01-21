//Problem 7. The biggest of five numbers
//Write a script that finds the greatest of given 5 variables.
//Use nested if statements.

function findTheBiggestOfFiveNumbers(a, b, c, d, e) {
    var biggestNumber;
    
    
    if (a <= b) {
        biggestNumber = b;
        if (b <= c) {
            biggestNumber = c;
            if (c <= d) {
                biggestNumber = d;
                if (d <= e) {
                    biggestNumber = e;
                }
            } else {
                if (c <= e) {
                    biggestNumber = e;
                }
            }
        } else {
            if (b <= d) {         
                biggestNumber = d;
                if (d <= e) {
                    biggestNumber = e;
                }
            } else {
                if (b <= e) {
                    biggestNumber = e;
                }
            }
        }
    } else {
        biggestNumber = a;
        if (a <= c) {
            biggestNumber = c;
            if (c <= d) {
                biggestNumber = d;
                if (d <= e) {
                    biggestNumber = e;
                }
            }
        } else {
            if (a <= d) {
                biggestNumber = d;
                if (d <= e) {
                    biggestNumber = e;
                }
            } else if (a <= e) {
                biggestNumber = e;
            }
        }
    }
    
    return biggestNumber;
}

//tests

var numColl_1,
    numColl_2,
    numColl_3,
    numColl_4,
    numColl_5,
    testArray,
    i, len,
    a, b, c, d, e;

function FiveNumberCollection(a, b, c, d, e) {
    this.a = a;
    this.b = b;
    this.c = c;
    this.d = d;
    this.e = e;
}

numColl_1 = new FiveNumberCollection(5, 2, 2, 4, 1);
numColl_2 = new FiveNumberCollection(-2, -22, 1, 0, 0);
numColl_3 = new FiveNumberCollection(-2, 4, 3, 2, 0);
numColl_4 = new FiveNumberCollection(0, -2.5, 0, 5, 5);
numColl_5 = new FiveNumberCollection(-3, -0.5, -1.1, -2, 10);

testArray = [numColl_1, numColl_2, numColl_3, numColl_4, numColl_5];

//console.log(findTheBiggestOfFiveNumbers(1, 4, 2, 1, 5));

for (i = 0, len = testArray.length; i < len; i += 1) {
    a = testArray[i].a;    
    b = testArray[i].b;
    c = testArray[i].c;
    d = testArray[i].d;
    e = testArray[i].e;
    
    console.log('a=' + a + ', b=' + b + ', c=' + c + ', d=' + d + ', e=' + e + '-> the biggest of them is: ' + findTheBiggestOfFiveNumbers(a, b, c, d, e));
}
