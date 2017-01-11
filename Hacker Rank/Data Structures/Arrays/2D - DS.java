import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int arr[][] = new int[6][6];
        for(int arr_i=0; arr_i < 6; arr_i++){
            for(int arr_j=0; arr_j < 6; arr_j++){
                arr[arr_i][arr_j] = in.nextInt();
            }
        }
        
        int maxSum = Integer.MIN_VALUE;
        int tempSum;
        int[][] hourGlass;



        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {

                hourGlass = getHourGlass(arr, i, j);
                tempSum = getHourGlassSum(hourGlass);
                maxSum = Math.max(maxSum, tempSum);
                
            }
        }

        System.out.println(maxSum);
    }


    public static int getHourGlassSum(int[][] hourGlass) {

        int sum = 0;
        hourGlass[1][0] = 0;
        hourGlass[1][2] = 0;

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                sum += hourGlass[i][j];
            }
        }

        return sum;
    }

    public static int[][] getHourGlass(int[][] array, int i, int j) {

        int[][] hourGlass = new int[3][3];

        for (int k = 0; k < 3; k++) {
            hourGlass[k] = Arrays.copyOfRange(array[j+k], i, i+3);
        }

        return hourGlass;
    }
}
