//Problem 3. Min/Max of sequence
//Write a script that finds the max and min number from a sequence of numbers.

function findMinAndMaxOfSequence(sequence){
    var min,
        max,
        i, len;

    min = sequence[0];
    max = sequence[0];

    for (i = 0, len = sequence.length; i < len; i += 1) {
        if (sequence[i] < min) {
            min = sequence[i];
        }

        if (max < sequence[i]) {
            max = sequence[i];
        }
    }

    return {
        sequence : sequence,
        min : min,
        max : max
    }
}

function onShowMinMaxOfSequenceBtnClick() {
    var sequence,
        seq,
        i, len,
        minMaxResult,
        output;
         
    seq = [];   
    sequence = (document.getElementById('s1').value).split(/,\s*/);
    
    for (i = 0, len = sequence.length; i < len; i += 1) {
        seq[i] = parseInt(sequence[i]);
    }
    minMaxResult = findMinAndMaxOfSequence(seq);    
    output = 'Sequence: ' + minMaxResult.sequence + ': min=' + minMaxResult.min + ', max=' + minMaxResult.max;

    jsConsole.writeLine(output);
}

//test 

console.log(findMinAndMaxOfSequence([3, 4, 6, 12, 90, 89]));