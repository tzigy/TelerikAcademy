//Problem 1. Make person
//Write a function for creating persons.
//Each person must have firstname, lastname, age and gender(true is female, false is male) G
//enerate    an array with tenperson with differentnames, ages and genders

function Person(fname, lname, age, gender){
    this.firstname = fname;
    this.lastname = lname;
    this.age = age;
    this.gender = gender;

    this.isFemale = function () {
        return (this.gender);
    };

    this.isMale = function () {
        return !this.gender;
    };

    this.isYounger = function (person) {
        return this.age < person.age;
    };

    this.fullName = function () {
        return (this.firstname + ' ' + this.lastname);
    };

    this.printPersonInfo = function () {
        return (this.fullName() + ', Age: ' + this.age + ', Gender: ' + (this.isFemale() ? 'female' : 'male'));
    };
}

var person1, person2, person3, person4, person5, person6, person7, person8, person9, person10, people;

person1 = new Person('Ivan', 'Ivanov', 23, false);
person2 = new Person('Petar', 'Petrov', 46, false);
person3 = new Person('Pesho', 'Peshev', 31, false);
person4 = new Person('Georgy', 'Georgiev', 15, false);
person5 = new Person('Anton', 'Antonov', 17, false);
person6 = new Person('Stefka', 'Stefanova', 45, true);
person7 = new Person('Maria', 'Staneva', 21, true);
person8 = new Person('Petia', 'Petrova', 13, true);
person9 = new Person('Iskra', 'Popova', 56, true);
person10 = new Person('Emilia', 'Ivanova', 18, true);

people = [person1, person2, person3, person4, person5, person6, person7, person8, person9, person10];

console.log('Start PROBLEM 1: List of 10 persons');
people.forEach(function (person) { 
    console.log('\t' + person.printPersonInfo());
});

console.log('End PROBLEM 1\n');

//Problem 2. People of age
//Write a function that checks if an array of person contains only people of age (with age 18 or greater)
//Use only array methods and no regular loops (for, while)

console.log('Start PROBLEM 2: Is 18 or over?');

function isEqualOrOverEighteen(person) {
    return (person.age >= 18);
}

var result = people.every(isEqualOrOverEighteen) ? 'All person are 18 or over!' : 'NOT all person are 18 or over!';

console.log('\t' + result);
console.log('End PROBLEM 2\n');


//Problem 3. Underage people
//Write a function that prints all underaged persons of an array of person
//Use Array#filter and Array#forEach
//Use only array methods and no regular loops (for, while)

function isUnderEighteen(person){
    return person.age < 18;
}

console.log('Start PROBLEM 3: Find all under 18');
console.log('\tUsing Array#forEach');
people.forEach(function (person) {
    if(person.age < 18){
        console.log('\t\t' + person.printPersonInfo());
    }
});


console.log('\n\tUsing Array#filter');

(people.filter(isUnderEighteen)).forEach(function (person) {
    console.log('\t\t' + person.printPersonInfo()); 
});

console.log('End PROBLEM 3\n');


//Problem 4. Average age of females
//Write a function that calculates the average age of all females, extracted from an array of persons
//Use Array#filter
//Use only array methods and no regular loops (for, while)

console.log('Start PROBLEM 4: Avarage age');

var allFemales = people.filter(function (person) {
        return person.isFemale(); 
}); 


var ageSum = allFemales.reduce(function (ageSum, person) {
    return ageSum + person.age;
}, 0);
    
console.log('Womans avarage age is ' + (ageSum / allFemales.length));
console.log('End PROBLEM 4\n');


//Problem 5. Youngest person
//Write a function that finds the youngest male person in a given array of people and prints his full name
//Use only array methods and no regular loops (for, while)
//Use Array#find


console.log('Start PROBLEM 5: Youngest person');

if (!Array.prototype.find) {
    Array.prototype.find = function (predicate) {
        if (this == null) {
            throw new TypeError('Array.prototype.find called on null or undefined');
        }
        if (typeof predicate !== 'function') {
            throw new TypeError('predicate must be a function');
        }
        var list = Object(this);
        var length = list.length >>> 0;
        var thisArg = arguments[1];
        var value;
        
        for (var i = 0; i < length; i++) {
            value = list[i];
            if (predicate.call(thisArg, value, i, list)) {
                return value;
            }
        }
        return undefined;
    };
}


var peopleSorted = people.sort(function (first, second) { 
    return (first.age - second.age);
});

var youngestMale = peopleSorted.find(function(person){
    return person.isMale();
});

console.log('\tYoungest male is ' + youngestMale.printPersonInfo());

console.log('End PROBLEM 5\n');


//Problem 6. Group people
//Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
//Use Array#reduce
//Use only array methods and no regular loops (for, while)

console.log('Start PROBLEM 6: Group People');


var peopleGrouped = people.reduce(function (grouped, person) {
    var key = person.firstname[0];
    grouped[key] = grouped[key] || [];
    grouped[key].push(person);
    
    return grouped;
}, []);

//this function print only the grouped array
Object.keys(peopleGrouped).forEach(function (key) {
    console.log('\t' + key);
    peopleGrouped[key].forEach(function (person) { 
        console.log('\t\t' + person.printPersonInfo());
    });
});

console.log('End PROBLEM 6\n');