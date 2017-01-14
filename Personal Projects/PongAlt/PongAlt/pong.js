
class Square {
    
    constructor(x, y, width, height) {     
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    render(context, color) {
        context.fillStyle = color
        context.fillRect(this.x, this.y, this.width, this.height);
    }
}

class Circle {

    constructor(x, y) {
        this.x = x;
        this.y = y;
        this.x_speed = -3;
        this.y_speed = 0;
        this.radius = 5;
    }

    render(context, color) {
        context.beginPath();
        context.arc(this.x, this.y, this.radius, 2 * Math.PI, false);
        context.fillStyle = color;
        context.fill();
    }

    update() {
        this.x += this.x_speed;
        this.y += this.y_speed;
    }

}

var animate = window.requestAnimationFrame ||
  window.webkitRequestAnimationFrame ||
  window.mozRequestAnimationFrame ||
  function (callback) { window.setTimeout(callback, 1000 / 60) };

var canvas = document.createElement('canvas');
var width = 600;
var height = 300;
canvas.width = width;
canvas.height = height;
var context = canvas.getContext('2d');


var board = new Square(0, 0, 600, 300)
var player = new Square(0, 127.5, 10, 50);
var computer = new Square(590, 127.5, 10, 50);
var ball = new Circle(300, 150)

window.onload = function () {
    document.body.appendChild(canvas);
    animate(step);
}

var step = function () {
    update();
    draw();
    animate(step);
}

var update = function () {
    ball.update();
};


var draw = function () {

    board.render(context, "indigo");
    player.render(context, "teal");
    computer.render(context, "teal");
    ball.render(context, "orange");
    
    
};


