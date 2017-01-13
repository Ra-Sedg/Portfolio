
// requestAnimationFrame method will call the callback at 60fps, also
// allows browser to preform optimization on the call. 
var animate = window.requestAnimationFrame ||
  window.webkitRequestAnimationFrame ||
  window.mozRequestAnimationFrame ||
  function(callback) { window.setTimeout(callback, 1000/60) };


// Set up canvas for 2d.
var canvas = document.createElement('canvas');
var width = 400;
var height = 600;
canvas.width = width;
canvas.height = height;
var context = canvas.getContext('2d');

// Attach canvas when page loads
window.onload = function() {
    document.body.appendChild(canvas);
    animate(step);
};

// Step() 
// Updates all objects
// Render all objects
// uses requestAnimationFrame to call itself again
var step = function() {
    update();
    render();
    animate(step);
};

// update()
var update = function () {
};


// Object Paddle
function Paddle(x, y, width, height) {
    this.x = x;
    this.y = y;
    this.width = width;
    this.height = height;
    this.x_speed = 0;
    this.y_speed = 0;
}

// Draw Paddles
Paddle.prototype.render = function () {
    context.fillStyle = "#008ea6";
    context.fillRect(this.x, this.y, this.width, this.height);
};


function Player() {
    this.paddle = new Paddle(175, 580, 50, 10);
}

function Computer() {
    this.paddle = new Paddle(175, 10, 50, 10);
}

Player.prototype.render = function () {
    this.paddle.render();
};

Computer.prototype.render = function () {
    this.paddle.render();
};

function Ball(x, y) {
    this.x = x;
    this.y = y;
    this.x_speed = 0;
    this.y_speed = 3;
    this.radius = 5;
}

Ball.prototype.render = function () {
    context.beginPath();
    context.arc(this.x, this.y, this.radius, 2 * Math.PI, false);
    context.fillStyle = "#fe8d2d";
    context.fill();
};

var player = new Player();
var computer = new Computer();
var ball = new Ball(200, 300);

var render = function () {
    context.fillStyle = "#323291";
    context.fillRect(0, 0, width, height);
    player.render();
    computer.render();
    ball.render();
};