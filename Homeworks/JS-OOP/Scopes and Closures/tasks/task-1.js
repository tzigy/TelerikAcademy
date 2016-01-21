/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
    var library = (function () {

        var books = [];
        var categories = [];
        var result;

        function listBooks() {
            var args,
                result = [];
            args = [].slice.apply(arguments);

            if (args.length === 0) {
                result = books;
            }
            else if (args[0].hasOwnProperty('category') || args[0].hasOwnProperty('author')) {
                result = books.filter(function (book) {
                    return book.category == args[0].category || book.author == args[0].author;
                });
            }

            return result;
        }

        function checkIfBookIsValid(book) {
            var result;

            result = (book.title === undefined ||
                    book.author === undefined ||
                    book.isbn === undefined ||
                    book.category === undefined) ? false : true;

            return result;
        }

        function checkIfTitleIsValid(title) {
            var result, len;
            title = title || '';
            len = title.length;
            result = ((2 <= len || len < 100)) ? true : false;
            return result;
        }

        function checkIfCategoryIsValid(category) {
            var result, len;
            category = category || '';
            len = category.length;
            result = ((2 <= len || len < 100)) ? true : false;
            return result;
        }

        function checkIfIsbnIsValid(isbn) {
            var result;
            isbn = isbn || '';
            result = ((isbn.length == 10 || isbn.length == 13) &&
                       isFinite((isbn))) ? true : false;
            return result;
        }

        function checkIfAuthorIsValid(author) {
            author = author || '';
            if (author.length === 0 || (typeof author != 'string')) {
                return false;
            }
            return true;
        }

        function checkIfBookExist(book) {
            var i, len;
            for (i = 0, len = books.length; i < len; i += 1) {
                if (books[i].title === book.title || books[i].isbn === book.isbn) {
                    return true;
                }
            }
            return false;
        }

        function checkIfCategoryExist(category) {
            if (categories.indexOf(category) === -1) {
                return false;
            }
            return true;
        }

        function addBook(book) {
            book.ID = books.length + 1;

            if (!checkIfBookIsValid(book)) {
                throw 'Invalid book input! Book has missing fields!';
            }

            if (!checkIfTitleIsValid(book.title)) {
                throw 'Book has incorrect title!';
            }

            if (!checkIfAuthorIsValid(book.author)) {
                throw 'Book has incorrect author!';
            }

            if (!checkIfIsbnIsValid(book.isbn)) {
                throw 'Book has incorrect isbn!';
            }

            if (!checkIfCategoryIsValid(book.category)) {
                throw 'Book has incorrect category!';
            }

            if (checkIfBookExist(book)) {
                throw 'Book exist!';
            }

            if (!checkIfCategoryExist(book.category)) {
                categories.push(book.category);
            }

            books.push(book);
            return book;
        }

        function listCategories() {
            return categories;
        }

        result = {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
        return result;
    }());

    //var book1 = {
    //    title : 'First title',
    //    author : 'Some author',
    //    isbn : '1234567890',
    //    category : 'First Category'
    //};

    //console.log(library.books.add(book1));

    return library;
}
module.exports = solve;

