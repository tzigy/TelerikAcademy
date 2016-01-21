function solve() {
    return function (selector) {

        var $selectElement,
            $dropDownListContainer,
            $currentSelection,
            $optionsContainer;

        if (selector === undefined ||
           typeof selector !== 'string') {
            throw new Error('Invalid input selector!');
        }

        $selectElement = $(selector);

        if ($selectElement.length === 0) {
            throw new Error('No such element!');
        }

        $selectElement.css('display', 'none');

        $dropDownListContainer = $('<div />')
            .addClass('dropdown-list')
            .append($selectElement);


        $currentSelection = $('<div />')
            .addClass('current')
            .attr('data-value', '')
            .text('Select a value');       
        

        $optionsContainer = $('<div />')
            .addClass('options-container')            
            .css('display', 'none')
            .css('position', 'absolute');

        $selectElement.children().each(function (index, element) {
            var $this = $(this),
                $currentDropDownItem = $('<div />')
                    .addClass('dropdown-item')
                    .attr('data-value', $this.val())
                    .attr('data-index', index)
                    .text($this.text());

            $optionsContainer.append($currentDropDownItem);
        });

        $dropDownListContainer.append($currentSelection)
            .append($optionsContainer)
            .appendTo('body');

        //$dropDownListDiv.insertAfter('body > h1');

        $currentSelection.on('click', onCurrentOptionClick);

        function onCurrentOptionClick() {
            var $this = $(this),
                $nextSiblingElement = $this.next();

            if ($nextSiblingElement.css('display') == 'none') {
                $this.text('Select a value');
                $nextSiblingElement.css('display', '');
                $nextSiblingElement.on('click', '.dropdown-item', onSelectOptionClick);
            }
        }

        function onSelectOptionClick() {
            var $this = $(this),
                $parentElement = $this.parent();

            //$parentElement.prev().attr('data-value', $this.attr('data-value')).text($this.text());
            $parentElement.prev().text($this.text());
            $selectElement.val($this.attr('data-value'));
            $parentElement.css('display', 'none');
        }
    };
}

module.exports = solve;



//function solve() {
//    return function (selector) {
//        var $selectedList = $(selector)
//            .hide();
//        var options = $selectedList.find('option');

//        var $divContainer = $('<div>')
//            .addClass('dropdown-list')
//            .append($selectedList);

//        var $currentSelection = $('<div>')
//            .addClass('current')
//            .attr('data-value', '')
//            .text('Select value');

//        var $divOptionsContainer = $('<div>')
//            .addClass('options-container')
//            .css({
//                'position': 'absolute',
//                'display': 'none'
//            });

//        $currentSelection.on('click', function () {
//            var $container = $('.options-container');
//            $container.css('display', 'inline-block');
//        });

//        $divOptionsContainer.on('click', function (ev) {
//            var $clicked = $(ev.target);
//            var $divToDisplay = $('.current');
//            $divToDisplay.text($clicked.html());
//            $selectedList.val($clicked.attr('data-value'));

//            var $container = $(this)
//                .css('display', 'none');
//        });

//        for (var i = 1; i <= options.length; i++) {
//            var newOpt = $('<div>')
//                .addClass('dropdown-item')
//                .attr('data-value', $(options[i]).val())
//                .attr('data-index', i - 1)
//                .text($(options[i]).text());

//            $divOptionsContainer.append(newOpt);
//        }

//        $divContainer.appendTo('body');
//        $currentSelection.appendTo($divContainer);
//        $divOptionsContainer.appendTo($divContainer);

//    };
//}

//module.exports = solve;