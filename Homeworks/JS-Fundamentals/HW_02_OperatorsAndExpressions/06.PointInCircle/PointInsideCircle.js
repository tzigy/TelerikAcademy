//Problem 6. Point in Circle
//Write an expression that checks if givenpoint P(x, y) is within a circle K({0,0}, 5).//{0,0} is the centre and 5 is the radius

function isInCircle(point) {
    var coordX = point.coordX,
        coordY = point.coordY,
        distance = Math.sqrt((coordX * coordX) + (coordY * coordY));
    return distance <= 5;
}

// Test

var point_1 = {
    coordX : 0,
    coordY : 1
};

var point_2 = {
    coordX : -5,
    coordY : 0
};

var point_3 = {
    coordX : -4,
    coordY : 5
};

var point_4 = {
    coordX : 1.5,
    coordY : -3
};

var point_5 = {
    coordX : -4,
    coordY : 3.5
};

var point_6 = {
    coordX : 100,
    coordY : -30
};

var point_7 = {
    coordX : 0,
    coordY : 0
};


var point_8 = {
    coordX : 0.2,
    coordY : -0.8
};

var point_9 = {
    coordX : 0.9,
    coordY : -4.93
};

var point_10 = {
    coordX : 2,
    coordY : -2.655
};

var testArray = [point_1, point_2, point_3, point_4, point_5, point_6, point_7, point_8, point_9, point_10];

for (var i = 0; i < testArray.length; i++) {
    var point = testArray[i];
    console.log('P(' + point.coordX + ', ' + point.coordY + ') is inside: ' + isInCircle(point));
}