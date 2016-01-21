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

    //(function ($) {
    //    $.fn.exist = function () {
    //        return $(this).length !== 0;
    //    };

    //    $.fn.changeDisplayMode = function () {
    //        var $this = $(this);

    //        if ($this.is(':visible')) {
    //            $this.hide();
    //        } else {
    //            $this.show();
    //        }

    //        return this;
    //    };

    //    $.fn.changeShowHideState = function () {
    //        var $this = $(this);

    //        $this.each(function () {
    //            var $this = $(this);

    //            if ($this.text() === 'hide') {
    //                $this.text('show');
    //            } else if ($this.text() === 'show') {
    //                $this.text('hide');
    //            } else {
    //                //throw new Error('Element text cannot be changed!');
    //            }
    //        });
            

    //        return this;
    //    };

    //}(jQuery));

    return function (selector) {
        $.fn.exist = function () {
            return $(this).length !== 0;
        };

        $.fn.changeDisplayMode = function () {
            var $this = $(this);

            //if ($this.is(':visible')) {
            //    //$this.hide();
            //    $this.css('display', 'none');
            //} else {
            //    //$this.show();
            //    $this.css('display', '');
            //}

            if ($this.css('display') == 'none' ) {
                //$this.hide();
                $this.css('display', '');
            } else {
                //$this.show();
                $this.css('display', 'none');
            }
            
            return this;
        };

        $.fn.changeShowHideState = function () {
            var $this = $(this);

            $this.each(function () {
                var $this = $(this);

                if ($this.text() === 'hide') {
                    $this.text('show');
                } else if ($this.text() === 'show') {
                    $this.text('hide');
                } else {
                    //throw new Error('Element text cannot be changed!');
                }
            });


            return this;
        };



        var $selectedElement,
            $buttonElements;

        if (selector === undefined || (typeof selector !== 'string')) {
            throw new Error('Invalid selector!');
        }        

        $selectedElement = $(selector);               

        if ($selectedElement.length === 0) {
            throw new Error('No such selector!');
        }
        
        $buttonElements = $selectedElement.find('.button');
        $buttonElements.text('hide');

        $selectedElement.on('click', '.button', onShowHideElementClick);

        function onShowHideElementClick(ev) {
            var $this = $(this);
            $(this).changeShowHideState();
            $this.prevUntil('.content').filter('.button').changeShowHideState();
            $this.nextUntil('.content').filter('.button').changeShowHideState();            
            $this.nextAll('.content:first').changeDisplayMode();
        }        
    };
};

module.exports = solve;