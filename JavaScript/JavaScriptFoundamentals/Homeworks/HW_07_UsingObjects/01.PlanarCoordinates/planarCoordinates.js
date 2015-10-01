//Problem 1. Planar coordinates
//Write functions for working with shapes in standard Planar coordinate system.
//Points are represented by coordinates P(X, Y)
//Lines are represented by two points, marking their beginning and ending L(P1(X1, Y1), P2(X2, Y2))
//Calculate the distance between two points.
//Check if threesegment lines can form a triangle.

//point constructor
function Point(coordX, coordY){
    this.x = coordX;
    this.y = coordY;
    
    //validate a point
    this.isPoint = function () {
        return (!isNaN(this.x) && !isNaN(this.y));
    };

    //check if two points are equivalent
    this.isEqual = function (point) {
        return (this.x === point.x && this.y === point.y);
    };
    // calculate the distance between two points
    this.distanceTo = function (point) {
        return (Math.sqrt((this.x - point.x) * (this.x - point.x) + (this.y - point.y) * (this.y - point.y)));
    };
    // return the point coordinates as string
    this.toString = function () {
        return '(' + this.x + ', ' + this.y + ')';
    };
}

// Line constructor
function Line(point1, point2) {
    this.p1 = new Point(point1.x, point1.y);
    this.p2 = new Point(point2.x, point2.y);
    
    //the length ot the line
    this.length = function () {
        return this.p1.distanceTo(this.p2);
    };
    //check if two lines are equal
    this.isEqual = function (line) {
        return (this.p1.isEqual(line.p1) && this.p2.isEqual(line.p2) ||
               this.p1.isEqual(line.p2) && this.p2.isEqual(line.p1));
    };
    //check if two points have only one common point. 
    this.hasOneCommonPoint = function (line) {
        return ((this.p1.isEqual(line.p1) && !this.p2.isEqual(line.p2)) ||
                (this.p1.isEqual(line.p2) && !this.p2.isEqual(line.p1)) ||
                (this.p2.isEqual(line.p1) && !this.p1.isEqual(line.p2)) ||
                (this.p2.isEqual(line.p2) && !this.p1.isEqual(line.p1)));
    };
    
    //Line Object as string
    this.toString = function (){
        return '(' + this.p1.toString() + ', ' + this.p2.toString() + ')';
    }
}

// 
function calculateDistance(point1, point2){
    //return (Math.sqrt((point1.x - point2.x) * (point1.x - point2.x) + (point1.y - point2.y) * (point1.y - point2.y)));
    return point1.distanceTo(point2);
}

function canMakeTriangle(line1, line2, line3){
    //using Triangle Inequality Theorem. It is possible to use the coordinate of the lines and to check if they make triangle, but too many if-s :)
    return ((line1.length() + line2.length()) > line3.length() &&
            (line1.length() + line3.length()) > line2.length() &&
            (line2.length() + line3.length()) > line1.length());
}

//tests

var point1, poin2, poin3, poin4,
    line1, line2, line3, line4;

point1 = new Point(1, 2);
point2 = new Point(5, 2);
point3 = new Point(3, 6);
point4 = new Point(8, 12);

line1 = new Line(point1, point2);
line2 = new Line(point1, point3);
line3 = new Line(point2, point3);
line4 = new Line(point2, point4);

console.log('The distance between point ' + point1.toString() + ' and point ' + point2.toString() + ' is ' + calculateDistance(point1, point2));

console.log('\nLines L1' + line1.toString() + ', L2' + line2.toString() + ' and L3' + line3.toString() + (canMakeTriangle(line1, line2, line3) ? ' can' : ' can NOT') + ' make a triangle!');

console.log('\nLines L1' + line1.toString() + ', L2' + line2.toString() + ' and L3' + line4.toString() + (canMakeTriangle(line1, line2, line4) ? ' can' : ' can NOT') + ' make a triangle!');
