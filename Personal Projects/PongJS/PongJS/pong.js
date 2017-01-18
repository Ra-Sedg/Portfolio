

    
// Classes
//===============================================================================================
class Circle {

    constructor(x, y, radius, color) {
        this.x = x;
        this.y = y;
        this.dx = -2;
        this.dy = 0;
        this.radius = radius;
        this.color = color;
        this.startAngle = 0;
        this.endAngle = Math.PI * 2;
        this.anticlockwise = false;
    }

    render(context, leftPaddle, rightPaddle, upPressed, downPressed) {

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

        // Left Paddle collision
        if (this.x + this.dx < paddleWidth) {
            if (this.y > leftPaddle.y && this.y < leftPaddle.y + paddleHeight) {
                
                if (upPressed) {
                    this.dx -= (this.dx - 1 == 0) ? 0 : 1;
                    this.dy += -1;
                }
                else if (downPressed) {
                    this.dx -= (this.dx - 1 == 0) ? 0 : 1;
                    this.dy += 1;
                }
                else {
                    this.dx += (this.dx + 1 == 0) ? 0 : 1;
                    if (this.dy > 0) {
                        this.dy -= (this.dy == 0) ? 0 : 1;
                    }
                    else {
                        this.dy += (this.dy == 0) ? 0 : 1;
                    }
                }
                this.dx = -(this.dx);
            }
            else if (this.x + this.dx < 0 - this.radius){
                this.x = canvasWidth / 2;
                this.y = canvasHeight / 2;
                this.dx = 2;
                this.dy = 0;
                scoreRight++;
                divRigthScore.textContent = scoreRight;
            }
        }
        
        // Right Paddle collsioin
        if (this.x + this.dx > canvasWidth - paddleWidth ) {
            if (this.y > rightPaddle.y && this.y < rightPaddle.y + paddleHeight) {

                if (this.y % 3 == 0) {
                    this.dx += .5;
                    this.dy += 1;
                }
                else if (this.y % 4 == 0) {
                    this.dx += 1;
                    this.dy -= 2;
                }
                else if (this.y % 5 == 0) {
                    this.dx -= .5;
                    this.dy += 1;
                }
                this.dx = -(this.dx);

            }
            else if (this.x + this.dx > canvasWidth + this.radius) {
                this.x = canvasWidth / 2;
                this.y = canvasHeight / 2;
                this.dx = -2;
                this.dy = 0;
                scoreLeft++;
                divLeftScore.textContent = scoreLeft;
            }
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
            this.y -= 2;
        }
        else if (downPressed && (this.y < canvasHeight - paddleHeight)) {
            this.y += 2;
        }

        context.beginPath();
        context.rect(this.x, this.y, this.width, this.height);
        context.fillStyle = this.color; 
        context.fill();
        context.closePath();
    }

    renderAi(context, ball) {

        if (this.y + (paddleHeight/2) > ball.y && (this.y > 0)) {
            this.y -= 1.5;
        }
        else if (this.y + (paddleHeight/2) < ball.y && (this.y < canvasHeight - paddleHeight)) {
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

    drawCourt = function () {

        context.setLineDash([5, 3]);/*dashes are 5px and spaces are 3px*/
        context.beginPath();
        context.moveTo(canvasWidth / 2, 0);
        context.lineTo(canvasWidth / 2, canvasHeight);
        context.strokeStyle = blue;
        context.stroke();
        context.closePath();

    }
//===============================================================================================


// Game Tokens
//===============================================================================================
var blue = "#0095DD";
var paddleHeight = canvasHeight / 6;
var paddleWidth = canvasWidth / 60;
var paddleY = (canvasHeight - paddleHeight) / 2;
var scoreLeft = 0;
var scoreRight = 0;


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
var div = document.getElementById("pong");
var divLeftScore = document.getElementById("leftScore");
var divRigthScore = document.getElementById("rightScore");
divLeftScore.textContent = scoreLeft;
divRigthScore.textContent = scoreRight;
div.appendChild(canvas);



function draw() {
    context.clearRect(0, 0, canvasWidth, canvasHeight);
    drawCourt();
    ball.render(context, playerPaddle, aiPaddle, upPressed, downPressed);
    playerPaddle.renderPlayer(context, upPressed, downPressed);
    //playerPaddle.renderAi(context, ball);
    aiPaddle.renderAi(context, ball);

   
    
}

document.addEventListener("keydown", keyDownHandler, false);
document.addEventListener("keyup", keyUpHandler, false);
setInterval(draw, 10);
//===============================================================================================
