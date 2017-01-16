

    

// Circle class
class Circle {

    constructor(x, y, radius) {
        this.x = x;
        this.y = y;
        this.dx = 2;
        this.dy = -2;
        this.radius = radius;
        this.startAngle = 0;
        this.endAngle = Math.PI * 2;
        this.anticlockwise = false;
    }

    render(context, color) {
        context.beginPath();
        console.log(this.x + ", " + this.y + ", " + this.radius);
        context.arc(this.x, this.y, this.radius,
                    this.startAngle, this.endAngle, this.anticlockwise);
        context.fillStyle = color;
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

// Add Canvas

var canvasHeight = 300;
var canvasWidth = 600;
var blue = "#0095DD";

var canvas = document.createElement('canvas');
canvas.id = "myCanvas";
canvas.width = canvasWidth;
canvas.height = canvasHeight;
    
var context = canvas.getContext("2d");
var ball = new Circle(canvasWidth/2, canvasHeight/2, 6);
    
document.body.appendChild(canvas);

//================================================

function draw() {
    context.clearRect(0, 0, canvasWidth, canvasHeight);
    ball.render(context, blue);
}

setInterval(draw, 10);
