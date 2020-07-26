/* global OT API_KEY TOKEN SESSION_ID SAMPLE_SERVER_BASE_URL */

var apiKey = String;
var sessionId = String;
var token = String;

// Assuming you have referenced jQuery
$(function () {
    debugger;
    $.ajax({
        url: 'session_attributes.asmx/GetSession_id',
        method: 'post',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            apiKey = response.apiKey;
            sessionId = response.sessionId;
            token = response.token;
            alert(apiKey);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
});


//var apiKey = '46850414';
//var sessionId = '2_MX40Njg1MDQxNH5-MTU5NTczNTY3Mjc2Nn4zdlh2NGQ4bzRpQVNlQTR0RkdwcnhKY21-fg';
//var token = 'T1==cGFydG5lcl9pZD00Njg1MDQxNCZzaWc9MmRkYWZmYzJlZGI1ZTgwYjkyOWVhZTY4ZDQwNjhiZDZhM2IwMGUwMzpzZXNzaW9uX2lkPTJfTVg0ME5qZzFNRFF4Tkg1LU1UVTVOVGN6TlRZM01qYzJObjR6ZGxoMk5HUTRielJwUVZObFFUUjBSa2R3Y25oS1kyMS1mZyZjcmVhdGVfdGltZT0xNTk1NzM1NzQ1Jm5vbmNlPTAuNzYwMjA1ODEyNTA0NzI0MiZyb2xlPXB1Ymxpc2hlciZleHBpcmVfdGltZT0xNTk1NzM5MzQ0JmluaXRpYWxfbGF5b3V0X2NsYXNzX2xpc3Q9';

function handleError(error) {
    if (error) {
        console.error(error);
    }
}

function initializeSession() {
    var session = OT.initSession(apiKey, sessionId);

    // Subscribe to a newly created stream
    session.on('streamCreated', function streamCreated(event) {
        var subscriberOptions = {
            insertMode: 'append',
            width: '100%',
            height: '100%'
        };
        session.subscribe(event.stream, 'subscriber', subscriberOptions, handleError);
    });

    session.on('sessionDisconnected', function sessionDisconnected(event) {
        console.log('You were disconnected from the session.', event.reason);
    });

    // initialize the publisher
    var publisherOptions = {
        insertMode: 'append',
        width: '100%',
        height: '100%'
    };
    var publisher = OT.initPublisher('publisher', publisherOptions, handleError);

    // Connect to the session
    session.connect(token, function callback(error) {
        if (error) {
            handleError(error);
        } else {
            // If the connection is successful, publish the publisher to the session
            session.publish(publisher, handleError);
        }
    });
}

// See the config.js file.
//if (API_KEY && TOKEN && SESSION_ID) {
//    apiKey = API_KEY;
//    sessionId = SESSION_ID;
//    token = TOKEN;
//    initializeSession();
//} else if (SAMPLE_SERVER_BASE_URL) {
//    // Make an Ajax request to get the OpenTok API key, session ID, and token from the server
//    fetch(SAMPLE_SERVER_BASE_URL + '/session').then(function fetch(res) {
//        return res.json();
//    }).then(function fetchJson(json) {
//        apiKey = json.apiKey;
//        sessionId = json.sessionId;
//        token = json.token;

//        initializeSession();
//    }).catch(function catchErr(error) {
//        handleError(error);
//        alert('Failed to get opentok sessionId and token. Make sure you have updated the config.js file.');
//    });
//}