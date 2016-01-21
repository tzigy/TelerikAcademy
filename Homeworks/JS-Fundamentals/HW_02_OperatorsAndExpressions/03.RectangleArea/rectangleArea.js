//Problem 3. Rectangle area
//Write an expression that calculates rectangle’ s area by given width and height.

function calculateRectangleArea(width, height){
    return (width > 0 && height > 0) ? (width * height) : 'Incorect input!';
}

//test

var rectangleOne = {
    width : 3,
    height : 4
};

var rectangleTwo = {
    width : 2.5,
    height : 3
};

var rectangleTree = {
    width : 5,
    height : 5
};

var rectangleArray = [rectangleOne, rectangleTwo, rectangleTree];

for (var i = 0; i < rectangleArray.length; i++) {
    var width = rectangleArray[i].width,
        height = rectangleArray[i].height,
        area = calculateRectangleArea(width, height);
    console.log('The area of rectanle with width=' + width + ' and height=' + height + ' is ' + area + '!');
}