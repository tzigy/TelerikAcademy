function solve() {
    
//(function ($){

    return function(){
        $.fn.listview = function(data){
            var $this = $(this);
            var bookItemTemplateId = $this.attr('data-template');            
            var htmlTemplate = $('#' + bookItemTemplateId).html();
            var bookTemplate = handlebars.compile(htmlTemplate);
            var $itemList = $('<ul />');

            for (var i = 0; i < data.length; i++) {
                $itemList.append(bookTemplate(data[i]));
            }

            $this.append($itemList.html());

            return this;
        };
    };
}
//}(jQuery));
module.exports = solve;