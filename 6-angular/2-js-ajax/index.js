'use strict';

document.addEventListener('DOMContentLoaded', () => {
    const button = document.getElementById('get-joke-button');
    const jokeText = document.getElementById('joke-display');

    button.addEventListener('click', () => {
        // when i click the button, i want to send a request
        // to the API, and when he response comes back, put part of it
        // on the page.
        // makeAjaxRequest('https://api.icndb.com/jokes/random', response => {
        //     jokeText.textContent = response.value.joke;
        // }, error => {
        //     jokeText.textContent = 'error: ' + error;
        // });
        makeAjaxRequestWithFetch('https://api.icndb.com/jokes/random', response => {
            jokeText.textContent = response.value.joke;
        }, error => {
            jokeText.textContent = 'error: ' + error;
        });
    });
});

function makeAjaxRequest(url, handleResponse, handleError) {
    // common boilerplate code
    // create the object
    const xhr = new XMLHttpRequest();

    // set up what will happen when the response comes back
    xhr.addEventListener('readystatechange', () => {
        // handle the response

        if (xhr.readyState === XMLHttpRequest.DONE) {
            // http success
            if (xhr.status >= 200 && xhr.status < 300) {
                console.log(xhr.response); // deserializes based on responseType

                // how do i let the callers of this function
                // decide what to do with the response?
                // callback function
                handleResponse(xhr.response);
            } else {
                // http non-success
                handleError('HTTP problem: ' + xhr.statusText);
            }
        }
    });

    xhr.timeout = 5000; // 5 second timeout on request
    xhr.addEventListener('timeout', () => {
        handleError('timeout');
    });

    // set up part 2
    xhr.open('GET', url);
    // lets us get the objectdirectly from xhr.response property
    // instead of doing JSON.parse(xhr.responseText)
    xhr.responseType = 'json';

    // actually send the request.
    xhr.send();
    // at this point, the request is maybe not even sent yet
    // this object is asynchronous
}

function makeAjaxRequestWithFetch(url, handleResponse, handleError) {
    // the fetch function returns a Promise of the response.
    fetch(url, { method: 'GET' })
        .then(response => response.json())
        .then(handleResponse) // this callback will get the object parsed from JSON
        .catch(handleError); // this callback will get some error object

    // if you return a Promise in a .then callback...
    // you can chain the next aciton to take in _another_ .then
    // out at the same level

    // the Response object that the Promise resolves with
    // doesn't have the whole body yet, just the response headers
}
