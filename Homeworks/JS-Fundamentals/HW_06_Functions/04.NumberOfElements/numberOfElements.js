//Problem 4. Number of elements
//Write a function to count the number of div elements on the web page

function countDivTags(){
    return document.getElementsByTagName("div").length || 0;
}



function onCountDivTagsBtnClick(){
    var numberOfDivs,
        output = '';

    numberOfDivs = countDivTags();
    
    if (!numberOfDivs) {
        output = 'There is no div tags on this page!';
    } else if (numberOfDivs === 1) {
        output = 'There is only ONE div tags on this page!';
    } else {
        output = 'There are ' + numberOfDivs + ' div tags on this page!';
    }

    document.getElementById("result").innerHTML = output;
}