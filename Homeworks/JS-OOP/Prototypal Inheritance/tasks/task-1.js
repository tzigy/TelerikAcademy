function solve() {
    'use strict';
    var domElement = (function () {
        function isValidType(type) {
            if (typeof type === 'string' &&
                    /^[A-Za-z0-9]+$/.test(type)) {
                return true;
            }
            return false;
        }

        function isValidAttributeName(name) {
            if (typeof name === 'string' &&
                    (/^[A-Za-z0-9\-]+$/.test(name))) {
                return true;
            }
            return false;
        }

        function isEmptyObject(obj) {
            var prop;
            for (prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    return false;
                }
            }

            return true;
        }

        function buildAttributes(attributes) {
            var i, len,
                attributeName,
                attributeValue,
                attributeNames = [],
                output = '';

            for (attributeName in attributes) {
                if (attributes.hasOwnProperty(attributeName)) {
                    attributeNames.push(attributeName);
                }
            }
            attributeNames.sort();
            for (i = 0, len = attributeNames.length; i < len; i += 1) {
                attributeName = attributeNames[i];
                attributeValue = attributes[attributeName];
                output += ' ' + attributeName + '="' + attributeValue + '"';
            }
            return output;
        }

        function parseHTML(domElement) {
            var i, len,
                //type = this.getType(),
                children = domElement.getChildren(),
                attributes = domElement.getAttributes(),
               // content,
                output = '';

            output += '<' + domElement.type;

            if (!isEmptyObject(attributes)) {
                output += buildAttributes(attributes);
            }
            //console.log(children);

            output += '>';
            if (0 < children.length) {

                for (i = 0, len = children.length; i < len; i += 1) {
                    if (typeof children[i] === 'string') {
                        output += children[i];
                    } else {
                        output += children[i].innerHTML;
                    }
                }
            } else if (domElement.content !== '') {
                output += domElement.content;
            }

            output += '</' + domElement.type + '>';
            return output;
        }

        var domElement = {
            init: function (type) {
                this.type = type;
                this.parent = {};
                this.children = [];
                this._attributes = {};
                this.content = '';
                return this;

            },
            get type() {
                return this._type;
            },
            set type (value) {
                if (!isValidType(value)) {
                    throw 'Invalid type!';
                }
                this._type = value;
            },
            getChildren: function () {
                return this.children;
            },
            getAttributes: function () {
                return this._attributes;
            },
            setParent: function (value) {
                this.parent = value;
            },
            appendChild: function (child) {
                if (typeof child !== 'string') {
                    child.parent = this;
                }
                this.children.push(child);
                return this;
            },
            addAttribute: function (name, value) {
                if (!isValidAttributeName(name)) {
                    throw 'Invalid attribute name!';
                }
                this._attributes[name] = value;
                return this;
            },
            removeAttribute: function (attribute) {
                var flag = false,
                    attributeName,
                    attributes = this.getAttributes();

                if (isEmptyObject(attributes)) {
                    throw new Error('Attribute list is empty!');
                }

                for (attributeName in attributes) {
                    if (attributes.hasOwnProperty(attributeName)) {
                        if (attributeName === attribute) {
                            delete attributes[attributeName];
                            flag = true;
                        }
                    }
                }
                if (!flag) {
                    throw new Error('No such attribute');
                }

                return this;
            },
            get innerHTML() {
                return parseHTML(this);
            }
        };
        return domElement;
    }());

     return domElement;
}

module.exports = solve;



//var meta = Object.create(domElement)
//    .init('meta')
//    .addAttribute('charset', 'utf-8')
//    .addAttribute('acharset1', 'utf-81');

//var head = Object.create(domElement)
//  .init('head')
//  .appendChild(meta)

//var div = Object.create(domElement)
//  .init('div')
//  .addAttribute('style', 'font-size: 42px');

////div.content = 'Hello, world!';
//var text = 'Some text here, Ehooooooooooooo.';
//var p = Object.create(domElement)
//    .init('p')
//	.appendChild(text);
//div.appendChild(p);

//var body = Object.create(domElement)
//  .init('body')
//  .appendChild(div)
//  .addAttribute('id', 'cuki')
//  .addAttribute('bgcolor', '#012345');

//var root = Object.create(domElement)
//  .init('html')
//  .appendChild(head)
//  .appendChild(body);

//console.log(root.innerHTML);
