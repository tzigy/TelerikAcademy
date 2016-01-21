/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  

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
      
      selector = selector.substring(1, selector.length);
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