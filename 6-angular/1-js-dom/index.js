'use strict';

// older less flexible way to do
// the 'load' event fires on any element when it and all its children
// are fully done being loaded by the browser.

// window.onload = function () {
// window.addEventListener('load', function () {
document.addEventListener('DOMContentLoaded', function () {
    // for (const element1 of document.body.children) {
    //     console.log(element1);

    //     for (const element2 of element1.children) {
    //         console.log(element2);
    //     }
    // }

    // const list = document.querySelector('#list');
    // const list = document.getElementById('list');
    // for (const item of list.children) {
    //     // if the user clicks on it, it will duplicate itself
    //     item.addEventListener('click', event => {
    //         const newItem = document.createElement('li');
    //         // now the object exists but it's not on the page
    //         list.appendChild(newItem);
    //         // now it's on the page
    //         newItem.textContent = item.textContent;
    //         // now it has the same text as the one clicked.
    //     });
    // }

    const list = document.getElementById('list');
    // if the user clicks on an item, it will duplicate itself
    list.addEventListener('click', event => {
        console.log(event);
        // console.log(event.currentTarget);
        if (event.target.parentElement === list) {
            // event.target is the *actual target of the event*
            // event.currentTarget is the element that this handler is attached to
            const newItem = document.createElement('li');
            // now the object exists but it's not on the page
            list.appendChild(newItem);
            // now it's on the page
            newItem.textContent = event.target.textContent;
            // now it has the same text as the one clicked.
        }
    });

    document.getElementById('link').addEventListener('click', event => {
        event.preventDefault();
        // the browser has default event handling to do things like
        // follow links onclick, and submit forms onsubmit.
        const newItem = document.createElement('li');
        // now the object exists but it's not on the page
        list.appendChild(newItem);
        // now it's on the page
        newItem.innerHTML = 'from <em>other</em> event handler';

        // make a table
        // backtick string in JS allows multi-line
        const div = document.createElement('div');
        div.innerHTML = `
            <table>
                <tr>
                    <td>data 1
                <tr>
                    <td>data 2
        `;
        document.body.appendChild(div);
        // now it's on the page
    });

    // all my code that needs the DOM to fully exist, needs to be
    // in here, not out there.
    console.log('this runs second');
});

// the 'load' event doesnt fire until e.g. all the images are downloaded
// the DOMContentLoaded event doesnt wait nearly that long, only until
//    all the DOM elements exist.


console.log('this runs first');
