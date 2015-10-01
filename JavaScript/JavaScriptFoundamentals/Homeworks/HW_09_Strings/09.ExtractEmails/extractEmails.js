//Problem 9. Extract e-mails
//Write a function for extracting all email addresses from given text.
//All sub-strings that match the format @… should be recognized as emails.
//Return the emails as array of strings.

function findEmailAddresses(text) {
    var i, len, 
        emailsArray = [],
        separateEmailsBy = "\n",
        email = "<none>"; // if no match, use this
            
    emailsArray = text.match(/([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi);
    if (emailsArray) {
        email = "";
        for (i = 0, len = emailsArray.length; i < len; i+=1) {
            if (i != 0) email += separateEmailsBy;
            email += emailsArray[i];
        }
    }
    return email;
}

//tests

var text = "Enter the phone number in the 'To' field of your email. Be sure to enter the full 10-digit number, followed by the specific carrier gateway address." +
"Here is a list of some of the most common carrier gateways: AT & T: number@txt.att.net for a normal text message(SMS), or number@mms.att.net for a multimedia message (MMS)" +
"Verizon: number@vtext.com for both SMS and MMS messages" +
"Sprint PCS: number@messaging.sprintpcs.com for both SMS and MMS messages" +
"T-Mobile: number@tmomail.net for both SMS and MMS messages" +
"Virgin Mobile: number@vmobl.com for both SMS and MMS messages";

console.log(text);
console.log('\nAll emails in the text:');
console.log(findEmailAddresses(text));