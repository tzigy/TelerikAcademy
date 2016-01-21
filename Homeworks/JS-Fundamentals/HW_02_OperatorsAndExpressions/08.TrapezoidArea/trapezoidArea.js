//Problem 8. Trapezoid area
//Write an expression that calculates trapezoid 's area by given sides a and b and height h.

function calculateTrapezoidArea(sideA, sideB, height){
    return ((sideA + sideB) * height) / 2;
}

//test

var trapezoid_1 = {
    sideA : 5,
    sideB : 7,
    height : 12
};

var trapezoid_2 = {
    sideA : 2,
    sideB : 1,
    height : 33
};

var trapezoid_3 = {
    sideA : 8.5,
    sideB : 4.3,
    height : 2.7
};

var trapezoid_4 = {
    sideA : 100,
    sideB : 200,
    height : 300
};

var trapezoid_5 = {
    sideA : 0.222,
    sideB : 0.333,
    height : 0.555
};

var testArray = [trapezoid_1, trapezoid_2, trapezoid_3, trapezoid_4, trapezoid_5];

for (var i = 0; i < testArray.length; i++) {
    var sideA = testArray[i].sideA,
        sideB = testArray[i].sideB,
        height = testArray[i].height;

    console.log("Trapezoid with a=" + sideA + ' b=' + sideB + ' and h=' + height + ' has area=' + calculateTrapezoidArea(sideA, sideB, height));
}