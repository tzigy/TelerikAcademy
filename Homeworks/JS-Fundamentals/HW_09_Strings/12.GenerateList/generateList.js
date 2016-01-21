//Problem 12. Generate list
//Write a function that creates a HTML <ul> using a template for every HTML <li>.
//The source of the list should be an array of elements.
//Replace all placeholders marked with– {… }– with thevalue of the corresponding property of the object.

//<strong>-{name}-</strong> <span>-{ age}-</span>

function formatString(string) {
    var args, index;
    
    args = [].slice.apply(arguments);
    
    string = string.replace(/{(\d+)}/g, function (match, number) {
        index = Number(number) + 1;
        return typeof args[index] != 'undefined'
          ? args[index]
          : match;
    });
    
    return string;
}

function generateList(people, template){
    var i, len, currentName, currentAge, outputList = '';
        
    template = template.replace('-{name}-', '{0}').replace('-{age}-', '{1}');

    outputList += '<ul>';
    for (i = 0, len = people.length; i < len; i += 1) {
        currentName = people[i].name;
        currentAge = people[i].age;

        outputList += '<li>';
        outputList += formatString(template, currentName, currentAge);
        outputList += '</li>';
    }     
    outputList += '</ul>';
    return outputList;
}

var people = [{ name: 'Peter', age: 14 },
              { name: 'Ivan', age: 19 },
              { name: 'Tisho', age: 21 },
              { name: 'Ivo', age: 15 },
              { name: 'Ivailo', age: 25 }];
    
function onGenerateListBtn(){
    var template, peopleList;

    template = document.getElementById('list-item').innerHTML;
    peopleList = generateList(people, template);
    document.getElementById("output").innerHTML = peopleList;
}