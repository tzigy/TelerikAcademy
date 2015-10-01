//Problem 9. Point in Circle and outside Rectangle
//Write an expression that checks for given point P(x, y) if it is within the circle K((1, 1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

function isInsideCircleOutsideRectangle(point) {
    return (isInsideCircle(point) && isOutsideRectangle(point)) ? 'yes' : 'no';
}

function isInsideCircle(point){
    var coordX = point.coordX,
        coordY = point.coordY,
        distance = Math.sqrt(((coordX -1) * (coordX - 1)) + ((coordY - 1) * (coordY - 1)));
    return distance <= 3; 
}

function isOutsideRectangle(point){
    var coordX = point.coordX,
        coordY = point.coordY,
        top = 1,
        bottom = -1,
        left = -1,
        right = 5,
        insideRectangle = (coordX >= left && coordX <= right && coordY >= bottom && coordY <= top);

    return !insideRectangle;
}

//Test

var point_1 = {
    coordX : 1,
    coordY : 2
};

var point_2 = {
    coordX : 2.5,
    coordY : 2
};

var point_3 = {
    coordX : 0,
    coordY : 1
};

var point_4 = {
    coordX : 2.5,
    coordY : 1
};

var point_5 = {
    coordX : 2,
    coordY : 0
};

var point_6 = {
    coordX : 4,
    coordY : 0
};

var point_7 = {
    coordX : 2.5,
    coordY : 1.5
};

var point_8 = {
    coordX : 2,
    coordY : 1.5
};

var point_9 = {
    coordX : 1,
    coordY : 2.5
};

var point_10 = {
    coordX : -100,
    coordY : -100
};

var testArray = [point_1, point_2, point_3, point_4, point_5, point_6, point_7, point_8, point_9, point_10];

for (var i = 0; i < testArray.length; i++) {
    var point = testArray[i];
    console.log('P(' + point.coordX + ', ' + point.coordY + ') is inside K & outside of R: ' + isInsideCircleOutsideRectangle(point));
}