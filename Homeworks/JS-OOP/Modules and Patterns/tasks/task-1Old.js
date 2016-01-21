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

    var Course = {
        init: function(title, presentations) {
            this.title = title;
            this.presentations = presentations;
            this.students = [];
            this.examResults = [];
            return this;
        },
        addStudent: function(name) {
            var fname, lname,
                studentId,
                names = [],
                student = {};

            name = name || '';
            names = name.split(' ');
            fname = names[0];
            lname = names[1];

            if (2 < names.length ||
                !isValidName(fname) ||
                !isValidName(lname)) {
                throw new Error('Invalid student name');
            }

            studentId = this.students.length + 1;
            student = {
                firstname: fname,
                lastname: lname,
                id: studentId
            };
            this.students.push(student);
            return studentId;
        },
        getAllStudents: function() {
            return this.students.slice();
        },
        submitHomework: function(studentID, homeworkID) {
            if (!isValidStudentId(studentID, this.students)) {
                throw new Error('Invalid student ID!');
            }

            if (!isValidHomeworkId(homeworkID, this.presentations)) {
                throw new Error('Invalid homework ID!');
            }
            return this;
        },
        pushExamResults: function(results) {
            if (!isValidExamResults(results)) {
                throw new Error('Function has no arguments!');
            }

            if (!isValidStudentId(results[0].StudentID, this.students)) {
                throw new Error('Exam results: invalis student id!');
            }
            this.examResults.push(results);
            return this;
        },
        getTopStudents: function() {
            return this;
        }
    };

    Object.defineProperty(Course, 'title', {
        get: function() {
            return this._title;
        },
        set: function(value) {
            if (!isValidTitle(value)) {
                throw new Error('Invalid cource title!');
            }
            this._title = value;
        }
    });

    Object.defineProperty(Course, 'presentations', {
        get: function() {
            return this._presentations;
        },
        set: function(value) {
            var i, len;
            value = value || [];

            if (value.length === 0) {
                throw new Error('Invalid presentations! List is empty!');
            }
            for (i = 0, len = value.length; i < len; i += 1) {
                if (!isValidTitle(value[i])) {
                    throw new Error('Invalid presentation title!');
                }
            }
            this._presentations = value.slice();
        }
    });

    return Course;
}
module.exports = solve;

// var c = Object.create(Course);
// c.init('New Course', ['Peres 1', 'Pres 2']);
// c.addStudent('Ivan Ivanov');
// c.addStudent('Dragan Ivanov');
// //
// console.log(c.students);
