

    
// Classes
//===============================================================================================
class Circle {

    constructor(x, y, radius, color) {
        this.x = x;
        this.y = y;
        this.dx = 2;
        this.dy = -2;
        this.radius = radius;
        this.color = color;
        this.startAngle = 0;
        this.endAngle = Math.PI * 2;
        this.anticlockwise = false;
    }

    render(context) {

        // Draw ball.
        context.beginPath();
        context.arc(this.x, this.y, this.radius,
                    this.startAngle, this.endAngle, this.anticlockwise);
        context.fillStyle = this.color;
        context.fill();
        context.closePath();

        // Top and bottom collision
        if (this.y + this.dx < this.radius || this.y + this.dy > canvasHeight - this.radius){
            this.dy = -(this.dy);
        }

        // Left and right collision
        if (this.x + this.dx < this.radius || this.x + this.dx > canvasWidth - this.radius) {
            this.dx = -(this.dx);
        }

        this.x += this.dx;
        this.y += this.dy;

    }
}

class Square {

    constructor(x, y, width, height, color) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.color = color
    }

    renderPlayer(context, upPressed, downPressed) {

        if (upPressed && (this.y > 0)) {
            this.y -= 3;
        }
        else if (downPressed && (this.y < canvasHeight - paddleHeight)) {
            this.y += 3;
        }

        context.beginPath();
        context.rect(this.x, this.y, this.width, this.height);
        context.fillStyle = this.color; 
        context.fill();
        context.closePath();
    }

    renderAi(context, ball) {

        if (this.y > ball.y && (this.y > 0)) {
            this.y -= 1.5;
        }
        else if (this.y < ball.y && (this.y < canvasHeight - paddleHeight)) {
            this.y += 1.5;
        }

        context.beginPath();
        context.rect(this.x, this.y, this.width, this.height);
        context.fillStyle = this.color;
        context.fill();
        context.closePath();
    }
}
//===============================================================================================

// Game Board
//===============================================================================================
var canvasHeight = 300;
var canvasWidth = 600;

var canvas = document.createElement('canvas');
    canvas.id = "myCanvas";
    canvas.width = canvasWidth;
    canvas.height = canvasHeight;
    
    var context = canvas.getContext("2d");
//===============================================================================================


// Game Tokens
//===============================================================================================
var blue = "#0095DD";
var paddleHeight = canvasHeight / 6;
var paddleWidth = canvasWidth / 60;
var paddleY = (canvasHeight - paddleHeight) / 2;


var ball = new Circle(canvasWidth / 2, canvasHeight / 2, 6, blue);

var playerPaddle = new Square(
    0,
    paddleY,
    paddleWidth,
    paddleHeight,
    blue
    );

var aiPaddle = new Square(
    canvasWidth - paddleWidth,
    paddleY,
    paddleWidth,
    paddleHeight,
    blue
    );
//===============================================================================================

// Controlls
//===============================================================================================
var downPressed = false;
var upPressed = false;

function keyDownHandler(e) {
    if (e.keyCode == 83) {
        downPressed = true;
    }
    else if (e.keyCode == 87) {
        upPressed = true;
    }
}

function keyUpHandler(e) {
    if (e.keyCode == 83) {
        downPressed = false;
    }
    else if (e.keyCode == 87) {
        upPressed = false;
    }
}
//===============================================================================================


// Execute Game
//===============================================================================================
document.body.appendChild(canvas);



function draw() {
    context.clearRect(0, 0, canvasWidth, canvasHeight);
    ball.render(context);
    playerPaddle.renderPlayer(context, upPressed, downPressed);
    aiPaddle.renderAi(context, ball);
    
}

document.addEventListener("keydown", keyDownHandler, false);
document.addEventListener("keyup", keyUpHandler, false);
setInterval(draw, 10);
//===============================================================================================
