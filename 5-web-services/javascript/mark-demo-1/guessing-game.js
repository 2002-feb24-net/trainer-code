'use strict';

const heading = document.getElementById('heading');
const guessField = document.getElementById('guess-field');
const guessSubmit = document.getElementById('guess-submit');
const guessForm = document.getElementById('guess-form');
const guesses = document.getElementById('guesses');
const lastResult = document.getElementById('last-result');
const lowOrHi = document.getElementById('low-or-hi');

const randomNumber = Math.floor(Math.random() * 100) + 1;

// how many tries has the user had
let guessCount = 0;

let gameOver = false;

guessForm.addEventListener('submit', checkGuess);

function checkGuess(event) {
  event.preventDefault();

  if (gameOver) return false;

  guessCount++;

  // the number guessed by the user
  const userGuess = Number(guessField.value);

  guessField.value = '';

  if (guessCount === 1) {
    guesses.textContent = 'Previous Guesses:';
  }

  guesses.textContent += ' ' + userGuess;

  // evaluate the user's guess number
  if (userGuess === randomNumber || guessCount === 10) {
    gameOver = true;
    guessField.disabled = true;
    guessSubmit.disabled = true;
    lowOrHi.textContent = '';
    if (userGuess === randomNumber) {
      // correct guess
      lastResult.textContent = 'Congratulations! You got the right number!';
      lastResult.style.backgroundColor = 'green';
      heading.textContent = 'You guessed it!';
    } else {
      lastResult.textContent = 'Game Over!';
      lastResult.style.backgroundColor = 'red';
    }
  } else {
    lastResult.textContent = 'Wrong number';
    lastResult.style.backgroundColor = 'red';
    if (userGuess < randomNumber) {
      lowOrHi.textContent = 'That guess was too low.';
    } else {
      lowOrHi.textContent = 'That guess was too high.';
    }
  }
}
