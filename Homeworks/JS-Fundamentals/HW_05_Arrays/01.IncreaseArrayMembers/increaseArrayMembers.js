//Problem 1. Increase array members
//Write a script that allocates array of 20 integers and initializes each element by its index multiplied by 5.
//Print the obtained array on the console.

function increaseArrayMembers() {
    var i, len,
        outputArray = [];
    
    // we can also write outputArray.length = 20;     
    outputArray[19] = undefined;
   
    for (i = 0, len = outputArray.length; i < len; i += 1) {        
        outputArray[i] = i * 5;
    }
    return outputArray;
}

console.log(increaseArrayMembers());
