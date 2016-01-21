/* globals $ */

/*

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed
*/

module.exports = function () {
    
    return function (element, contents) {
        //        function myFunc(element, contents) {
        var i, len,
            dFrag,
            currentContent,
            divElementToAdd,
            selectedIdElement;
        
        if (arguments.length !== 2) {
            throw new Error('Invalid number of arguments!');
        }
        
        if ((element === undefined || 
            ((typeof element !== 'string') && !(element instanceof HTMLElement)))) {
            throw new Error('First argument must be a string or DOM element!');
        }
        
        if (!Array.isArray(contents)) {
            throw new Error('Second argument must be an array!');
        }
        
        selectedIdElement = (typeof element === 'string') ? document.getElementById(element) : element;
        
        if (!!selectedIdElement) {
            
            dFrag = document.createDocumentFragment();
            
            for (i = 0, len = contents.length; i < len; i += 1) {
                currentContent = contents[i];
                
                if ((typeof currentContent !== 'string') && isNaN(parseFloat(currentContent))) {
                    throw new Error('Invalid content!');
                }
                
                divElementToAdd = document.createElement('div');
                divElementToAdd.innerHTML = currentContent;
                dFrag.appendChild(divElementToAdd);
            }
            
            selectedIdElement.innerHTML = '';
            selectedIdElement.appendChild(dFrag);

        } else {
            throw new Error('Invalid ID!');
        }
    };
};