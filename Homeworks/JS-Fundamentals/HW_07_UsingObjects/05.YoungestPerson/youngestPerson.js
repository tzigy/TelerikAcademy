//Problem 5. Youngest person
//Write a function that finds the youngest person in a given array of people and prints his/hers full name
//Each person has properties firstname, lastname and age.

function findYoungest(people) {
    var i, len,
        current,
        youngest;
    
    youngest = people[0];
    
    for (i = 1, len = people.length; i < len; i += 1) {
        current = people[i];
        if (current.isYounger(youngest)) {
            youngest = current;
        }
    }
    return youngest.fullName();
}

function Person(firstName, lastName, age) {
    this.firstname = firstName;
    this.lastname = lastName;
    this.age = age;
    
    this.fullName = function () {
        return this.firstname + ' ' + this.lastname;
    };
    
    this.isYounger = function (person) {
        return this.age < person.age;
    };
}


//tests

var person1, person2, person3, people, i, len;

person1 = new Person('Ivan', 'Ivanov', 45);
person2 = new Person('Pesho', 'Peshev', 23);
person3 = new Person('Gosho', 'Goshev', 24);

people = [person1, person2, person3];

console.log(people);
console.log();
console.log('The youngest is ' + findYoungest(people));
