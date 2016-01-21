//Problem 6.
//Write a function that groups an array of people by age, first or last name.
//The function must return an associative array, with keys - the groups, and values - arrays with people in this groups
//Use function overloading (i.e. just one function)

function group(people, prop) {
    var i, len, current, key,
        groupedArray = [];

    for (i = 0, len = people.length; i < len; i += 1) {
        current = people[i];
        key = current[prop] + ' ';
        groupedArray[key] = groupedArray[key] || [];
        groupedArray[key].push(current);
    }
    return groupedArray;
}


function Person(firstName, lastName, age) {
    this.firstname = firstName;
    this.lastname = lastName;
    this.age = age;
    
    this.fullName = function () {
        return this.firstname + ' ' + this.lastname;
    };
}

function printPerson(person){
     return (person.fullName() + ', Age: ' + person.age);
}

//tests

var i, len, person1, person2, person3, prop, people = [], sortedByFirstName = [], sortedByLastName = [], sortedByAge = [];

person1 = new Person('Ivan', 'Ivanov', 45);
person2 = new Person('Ivan', 'Petkov', 23);
person3 = new Person('Gosho', 'Goshev', 24);
person4 = new Person('Gosho', 'Toshev', 24);
person5 = new Person('Pesho', 'Vanchev', 45);
person6 = new Person('Pesho', 'Ivanov', 24);
person7 = new Person('Pesho', 'Petkov', 23);

people = [person1, person2, person3, person4, person5, person6, person7];

sortedByFirstName = group(people, 'firstname');
sortedByLastName = group(people, 'lastname');
sortedByAge = group(people, 'age');


console.log('Sorting by first name: ');
for (prop in sortedByFirstName) {
    console.log(prop );
    for (i = 0, len = sortedByFirstName[prop].length; i < len; i += 1) {
        console.log('\t ' + printPerson(sortedByFirstName[prop][i]));
    }
}

console.log();

console.log('Sorting by last name: ');
for (prop in sortedByLastName) {
    console.log(prop);
    for (i = 0, len = sortedByLastName[prop].length; i < len; i += 1) {
        console.log('\t ' + printPerson(sortedByLastName[prop][i]));
    }
}

console.log();

console.log('Sorting by age: ');
for (prop in sortedByAge) {
    console.log(prop);
    for (i = 0, len = sortedByAge[prop].length; i < len; i += 1) {
        console.log('\t ' + printPerson(sortedByAge[prop][i]));
    }
}

