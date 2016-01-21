function solve() {
    //'use strict';

    function isValidTitle(title) {
        title = title || '';

        if (typeof title !== 'string' ||
            title === '' ||
            title.trim().length !== title.length ||
            /\s\s/.test(title)) {
                return false;
        }
        return true;
    }

    function isValidName(name) {
        var result;

        name = name || '';

        if (name.length === 0) {
            result = false;
        } else {
            result = (name[0].toUpperCase() + name.slice(1).toLowerCase()) === name;
        }

        return result;
    }

    function isValidStudentId(id, students) {
        var i, len;

        if (id < 1 || id !== parseInt(id)) {
            return false;
        }

        for (i = 0, len = students.length; i < len; i += 1) {
            if (id === students[i].id) {
                return true;
            }
        }
        return false;
    }

    function isValidHomeworkId(id, presentations) {
        if (id < 1 ||
            id !== parseInt(id) ||
            presentations.length < id) {
            return false;
        }
        return true;
    }

    function isValidExamResults(results) {
        var i, len;

        if (results === undefined || !Array.isArray(results)) {
            return false;
        }

        for (i = 0, len = results.length; i < len; i += 1) {

            if (results[i].score === undefined || isNaN(results[i].score)) {
                return false;
            }
        }

        return true;
    }

    var course = (function() {
        var course = {
            init: function(title, presentations) {
                this.title = title;
                this.presentations = presentations;
                this.students = [];
                this.homeworks = [];
                return this;
            },
            get title() {
                return this._title;
            },
            set title(value) {
                if (!isValidTitle(value)) {
                    throw new Error ('Invalid title');
                }
                this._title = value;
            },
            get presentations() {
                return this._presentations;
            },
            set presentations(value) {
                if (!Array.isArray(value) || value.length < 1) {
                    throw '';
                }
                this._presentations = value;
            },
            get students() {
                return this._students;
            },
            set students(value){
                this._students = value;
            },
            addStudent: function(student) {
                var studentRecord = {},
                    studentId = this.students.length + 1,
                    names = student.split(' ');

                if (!isValidName(names[0]) || !isValidName(names[1]) || names.length > 2) {
                    throw new Error('Invalid student name!');
                }
                studentRecord = {
                    firstname: names[0],
                    lastname: names[1],
                    id: studentId
                };
                this.students.push(studentRecord);
                return studentId;
            },
            getAllStudents: function() {
                return this.students;
            },
            submitHomework: function(studentID, homeworkID) {
                if(!isValidStudentId(studentID)){
                    throw '';
                }
                if(!isValidHomeworkId(homeworkID)){
                    throw '';
                }

                this.homeworks.push({studentID : studentID, homeworkID : homeworkID});

            },
            pushExamResults: function(results) {

            },
            getTopStudents : function(){

            }
        };
        return course;
    }());

    return course;
}
module.exports = solve;

// var mod = solve();
//
// var c = Object.create(mod);
// c.init('New Course', ['Peres 1', 'Pres 2']);
// c.addStudent('Ivan Ivanov');
// c.addStudent('Dragan Ivanov');
// //
// console.log(c.students);
