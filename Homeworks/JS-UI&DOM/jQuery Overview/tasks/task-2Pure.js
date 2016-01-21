/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/


function solve() {

    function toggleShowHideState(element) {

        if (element.innerHTML === 'show') {
            element.innerHTML = 'hide';
        } else if (element.innerHTML === 'hide') {
            element.innerHTML = 'show';
        } else {
            throw new Error('Invalid element!');
        }
    }

    function toggleDisplayMode(element) {
        if (element.style.display === 'none') {
            element.style.display = '';
        } else {
            element.style.display = 'none';
        }
    }

  return function (selector) {
      var selectedElement,
          buttonElements,
          i, len;


      if (typeof selector !== 'string') {
          throw new Error('Invalid input selector!');
      }
      
      //selector = selector.substring(1, selector.length);
      //console.log(selector);
      selectedElement = document.querySelector(selector);     

      if (selectedElement === null) {
          throw new Error('Invalid id selector!');
      }

      buttonElements = selectedElement.getElementsByClassName('button');
      
      for (i = 0,len = buttonElements.length; i < len; i+=1) {
          buttonElements[i].innerHTML = 'hide';
      }

      selectedElement.addEventListener('click', function (ev) {
          var currentButton = ev.target,
              nextElementSibling,
              previuosElementSibling;

          

          if (ev.target.className === 'button') {

              nextElementSibling = currentButton.nextElementSibling;
              previuosElementSibling = currentButton.previousElementSibling;

              while (previuosElementSibling) {
                  if (previuosElementSibling.className === 'button') {
                      toggleShowHideState(previuosElementSibling);
                  }

                  if (previuosElementSibling.className === 'content') {
                      break;
                  }
                  previuosElementSibling = previuosElementSibling.previousElementSibling;
              }


              while (nextElementSibling) {

                  if (nextElementSibling.className === 'button'){ 
                      toggleShowHideState(nextElementSibling);
                  }

                  if (nextElementSibling.className === 'content') {
                      toggleShowHideState(currentButton);
                      toggleDisplayMode(nextElementSibling);
                      break;
                  }

                  nextElementSibling = nextElementSibling.nextElementSibling;
              }
          }
      }, false);



      var contentElements = selectedElement.getElementsByClassName('content');

  };
};

module.exports = solve;