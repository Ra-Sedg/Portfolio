#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

// Global Variables
int n = 6;		// Length and height of matrix
int t = 2;	    // Number of 1's in each row and column

// Function Prototypes
int handOff(int);
int numSolutions(int [], int);
int choose(int, int);



// main()
//=============================================================================
int main()
{
   cout << "Solutions: " << handOff(n);
}
//=============================================================================



// handOff()
//=============================================================================
// Populates state vector array with values of t
// Calls numSolutions function with initial state vector and puck
// Returns number of permutations to main();
//=============================================================================
int handOff(int length)
{
    int state_vector[length];


    for(int i = 0; i < length; i++)
    {
        state_vector[i] = t;
    }

    return numSolutions(state_vector, 0);
}
//=============================================================================



// numSolutions()
//=============================================================================
// Recurses all possible iterations and returns value to handOff()
// Input:  int[] - state_vector, Represents unassigned 1's in current matrix
//		   int   - puck, Represents current row and diagonal index
// Output: int   - total, Holds perutation count
//=============================================================================
int numSolutions(int state_vector[], int puck)
{
						// Represents 1's to be added to this row of matrix
    int row[n];			// Row number is denoted by puck value
    int total = 0;		// Holds permutation count

    for(int i = 0; i < n; i++)		// Populates initial row
    {							    // Last t elements set to 1
        if(i < n-t)               	// All other elements set to 0
            row[i] = 0;
        else
            row[i] = 1;
    }

    // do while loop used in combination with next_permutation()
    // next_perutation iterates row to next permutation, returns boolean based
    // on if another permutation is possible
    // Loop will terminate once all permutations are exhausted
    do
    {
        bool working = true;	// Is current row to specification?


        // Tests if diagonal index of current row is equal to zero
        // If so, then checks if the state vector can be decremented by
        // 		current row
        // If either test fails working is set to false, and the row will be
        // 		advanced to next permutation
        if(row[puck] == 0)
        {
            for (int i = 0; i < n; i++)
            {
                if( (state_vector[i] - row[i]) < 0)
                {
                    working = false;
                }
            }
        }
        else
        {
            working = false;
        }


        // If the current row is working
        // Copy the state vector
        // Decrement state vector copy by current row
        // If on last row increment total
        // Else recursive call to numSolutions with state vector copy and
        //		incremented puck
        if(working)
        {
            int state_vector_copy[n];

            for(int i = 0; i < n; i++)	// Copy's state vector
            {
            	state_vector_copy[i] = state_vector[i] - row[i];
            }

            if( puck == (n-1) )		// On last row?
            {
                total++;			// Solution found, increment total
            }
            else	// Recursive call to numSolutions with new vector and puck
            {
                total += numSolutions(state_vector_copy, puck+1);            }
        }
    }while(next_permutation(row, row+n));

    return total;		// Total returned to handOff()

}
//=============================================================================



// choose()
//=============================================================================
// Returns possible combinations as int
//=============================================================================
int choose(int i, int j)
{
    if (j == 0)
    	return 1;
    return (i * choose(i - 1, j - 1)) / j;
}
//=============================================================================




