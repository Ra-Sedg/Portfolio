using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 


namespace TheCircleandTheSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int widthGrid = 20;
            int heightGrid = 20;
            int circleX = 9;
            int circleY = 6;
            int r = 5;

            int[] s1 = { 16, 14 };
            int[] s3 = { 8, 14 };

            int[] corners = GetCorners(s1, s3);
            int[] s2 = { corners[0], corners[1] };
            int[] s4 = { corners[2], corners[3] };
           
            char[,] grid = GridBuilder(heightGrid, widthGrid);
            DrawCircle(grid, circleX, circleY, r);
            printGrid(grid);
            Console.WriteLine();

            DrawSquare(grid, s1, s2, s3, s4);
            printGrid(grid);
            Console.WriteLine();


            //int[] A = { 5, 0 };
            //int[] B = { 0, 2 };
            //int[] C = { 1, 5 };
            //int[] D = { 6, 3 };
            //int[] M = { 4, 2 };
            //int[] P = { 6, 1 };

            //Console.WriteLine(InSquare(M, A, B, C, D));
            //Console.WriteLine(InSquare(P, A, B, C, D));



            Console.ReadKey();
        }

        static char[,] GridBuilder(int height, int width)
        {
            char[,] grid = new char[height, width];

            for (int row = 0; row < height; row++)
            {
                for ( int column = 0; column < width; column++)
                {
                    grid[row, column] = '.';
                }
            }
            return grid;
        }

        static void DrawCircle(char[,] grid, int x, int y, int radius)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    double distance = Distance(row, column, x, y);

                    if (distance <= radius)
                    {
                        grid[row, column] = '#';
                    }
                }
            }
        }

        static void DrawSquare(char[,] grid, int[] A, int[] B, int[] C, int[] D)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    int[] point = { row, column };
                    bool inSquare = InSquare(point, A, B, C, D);

                    if (inSquare)
                    {
                        grid[row, column] = '#';
                    }
                }
            }
        }

        static int TriangleArea(int[] A, int[] B, int[] C)
        {
            return (
                (C[0] * B[1] - B[0] * C[1]) -
                (C[0] * A[1] - A[0] * C[1]) +
                (B[0] * A[1] - A[0] * B[1])
                );
        }

        static int[] GetCorners(int[] x, int[] y)
        {
            int x1 = x[0];
            int x2 = x[1];
            int y1 = y[0];
            int y2 = y[1];
            int xc = (x1 + x2) / 2;
            int yc = (y1 + y2) / 2;    // Center point

            int xd = (x1 - x2) / 2;
            int yd = (y1 - y2) / 2;    // Half-diagonal

            int x3 = xc - yd;
            int y3 = yc + xd;    // Third corner
            int x4 = xc + yd;
            int y4 = yc - xd;    // Fourth corner
            int[] corners = { y3, x3, x4, y4 };
            return corners;
        }

        static bool InSquareAlt(int[] P, int[] A, int[] B, int[] C, int[] D)
        {
            if (TriangleArea(A, B, P) > 0 ||
                TriangleArea(B, C, P) > 0 ||
                TriangleArea(C, D, P) > 0 ||
                TriangleArea(D, A, P) > 0 )
            {
                return false;
            }
            return true;
        }

        static bool InSquare(int[] Point, int[] A, int[] B, int[] C, int[] D)
        {
            int[] AB = SubtractVectors(B, A);
            int[] AP = SubtractVectors(Point, A);
            int[] BC = SubtractVectors(C, B);
            int[] BP = SubtractVectors(Point, B);

            int dotAB_AM = DotProduct(AB, AP);
            int dotAB_AB = DotProduct(AB, AB);
            int dotBC_BP = DotProduct(BC, BP);
            int dotBC_BC = DotProduct(BC, BC);

            return (
                0 <= dotAB_AM        &&
                dotAB_AM <= dotAB_AB &&
                0 <= dotBC_BP        &&
                dotBC_BP <= dotBC_BC
                );
        }

        static int DotProduct(int[] vectorX, int[] VectorY)
        {
           
            int dotProduct = 0;

            for (int i = 0; i < vectorX.Length; i++)
            {
                dotProduct += vectorX[i] * VectorY[i];
            }

            return dotProduct;
        }


        static int[] SubtractVectors(int[] x, int[] y)
        {
            return new int[] { (x[0] - y[0]), x[1] - y[1] };
        }



        public static double Distance(int x1, int y1, int x2, int y2)
        {
           return Math.Sqrt(
                    Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)
                );
        }


        public static void printGrid(char[,] grid)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    Console.Write(grid[row, column]);
                }
                Console.WriteLine();
            }
        }
    }
}
