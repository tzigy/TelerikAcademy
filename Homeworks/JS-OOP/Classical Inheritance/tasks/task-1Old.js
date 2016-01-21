/* Task Description */
/*
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
    var Person = (function () {
        function Person(fname, lname, age) {
            this.firstname = fname;
            this.lastname = lname;
            this.age = age;
            this.fullname = this.firstname + ' ' + this.lastname;
        }

        function isValidName(name) {
            //console.log('Name ' + name);
            if (typeof name == 'string' &&
               (3 <= name.length && name.length <= 20) &&
               (/^[a-zA-Z]+$/.test(name))) {

                return true;
            }
            return false;
        }

        Object.defineProperty(Person.prototype, 'firstname', {
            get: function () {
                return this._firstname;
            },

            set: function (value) {
                if (!isValidName(value)) {
                    throw 'Invalid first name!';
                }
                this._firstname = value;

            }
        });

        Object.defineProperty(Person.prototype, 'lastname', {
            get: function () {
                return this._lastname;
            },

            set: function (value) {
                if (!isValidName(value)) {
                    throw 'Invalid last name!';
                }
                this._lastname = value;

            }
        });

        Object.defineProperty(Person.prototype, 'fullname', {
            get: function () {
                return this._firstname + ' ' + this._lastname;
            },

            set: function (value) {
                var names = value.split(' ');
                this.firstname = names[0];
                this.lastname = names[1];
            }
        });

        Object.defineProperty(Person.prototype, 'age', {
            get: function () {
                return this._age;
            },

            set: function (value) {
                value = Number(value);
                if (value < 1 || 150 < value) {
                    throw 'Invalid age. It must be between (0, 150)!';
                }
                this._age = value;

            }
        });

        Person.prototype.introduce = function () {
            var output;
            output = 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';

            return output;
        };

        return Person;
    }());

    //var p = new Person('Ff', 'Petrov', 23);
    //console.log(p);

    return Person;
}
module.exports = solve;
