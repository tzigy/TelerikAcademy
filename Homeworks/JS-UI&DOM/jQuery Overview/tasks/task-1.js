
/* globals $ */

/* 

Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indices are zero-based
  * If the provided selector does not selects anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, [] 
*/


function solve() {
  return function (selector, count) {
     
      var currentCount;

      if (arguments.length < 2) {
          throw new Error('Invaid number of arguments!');
      }

      currentCount = parseInt(count);      

      if (isNaN(currentCount) || 
         ((typeof count === 'string') && currentCount.toString().length !== count.length)) {
            throw new Error('Count must be a number!');
      }

      if (parseInt(count) < 1) {
          throw new Error('Count cannot be less than 1!');
      }
      
      if (typeof selector !== 'string') {
          throw new Error('Invalid selector!');
      }

      var $selector = $(selector);
      var $ulElement = $('<ul/>').addClass('items-list');
              
      for (var i = 0; i < currentCount; i++) {
          var $liElement = $('<li/>').addClass('list-item').text('List item #' + i);
          $ulElement.append($liElement);
      }

      $selector.append($ulElement);

  };
}

module.exports = solve;