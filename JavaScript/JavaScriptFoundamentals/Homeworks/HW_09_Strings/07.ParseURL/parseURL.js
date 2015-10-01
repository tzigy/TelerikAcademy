//Problem 7. Parse URL
//Write a script that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
//Return the elements in a JSON object.

//this solution parse straight forrward the url and extract protocol, server, resorce
function parseUrl(url) {
    var i, len, 
        currentSymbol = '',
        protocol = '',
        server = '',
        resource = '',
        parseProtocol = true,
        parseServer = false,
        parseResorce = false;
    
    url = url || '';
    
    for (i = 0, len = url.length; i < len; i += 1) {
        currentSymbol = url[i];
        if (parseProtocol) {
            if (currentSymbol !== ':') {
                protocol += currentSymbol;
            } else {
                parseProtocol = false;
                parseServer = true;
                i = i + 3;
                currentSymbol = url[i];
            }
        }
        
        if (parseServer) {
            if (currentSymbol !== '/') {
                server += currentSymbol;
            } else {
                parseServer = false;
                parseResorce = true;
                i = i + 1;
            }
        }
        
        if (parseResorce) {
            resource = url.substring(i, url.length);
            break;
        }
    }
    
    return {
        protocol : protocol,
        server : server,
        resource : resource
    };
}

//another solution
function anotherParseUrl(url) {
    url = url || '';
    
    var endProtocolPossition,
        endServerPossition,
        protocol,
        server,
        resource;
    
    endProtocolPossition = url.indexOf('://');    
    protocol = url.substring(0, endProtocolPossition);    
    endServerPossition = url.indexOf('/', endProtocolPossition + 3);
    
    
    if (endProtocolPossition === -1) {
        return 'Incorrect URL!';
    } else if (endServerPossition === -1) {
        
        server = url.substring(endProtocolPossition + 3, url.length);
        return {
            protocol : protocol,
            server : server,
            resource : 'none'
        };
    } else {
        server = url.substring(endProtocolPossition + 3, endServerPossition);
        resource = url.substr(endServerPossition + 1, url.length);
           
        return {
            protocol : protocol,
            server : server,
            resource : resource
        };
    }
}


//tests

var url = 'http://telerikacademy.com/Courses/Courses/Details/239';
var url1 = 'http://telerikacademy.com';

console.log(url);
console.log(parseUrl(url));
console.log();
console.log(url1);
console.log(parseUrl(url1));

//console.log(anotherParseUrl('http://telerikacademy.com'));