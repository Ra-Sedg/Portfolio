import java.util.*;
import java.io.*;

/**
 * Class Driver: Driver for WordSearch class, searches a .txt file for given words.
 * @author Robert Sedgwick
 * @version Extra credit assignment, Horspool implementation 4/29/16.
 */
public class Driver {
    public static void main(String[] args) throws IOException {

        // Local Variables
        ArrayList<Integer> patternMatches = new ArrayList<Integer>();       // Holds matches found by WordSearch
        String pattern;                 // Pattern to be searched for.
        String filePath;                // Path to .txt file to be search.
        String fileText;                // Holds contents of .txt file as a String.
        boolean caseSensitive;          // true: case sensitive, false: case insensitive.
        boolean running = true;         // true: continue program. false: quit program.
        WordSearch search;              // Reference variable for WordSearch object.

        // I don't see a need to comment this out, method names are self explanatory; see method comments for details.
        while (running) {
            filePath = getFilePath();
            fileText = readInText(filePath);
            pattern = getPattern();
            caseSensitive = getCaseSensitivity();
            search = new WordSearch(pattern, fileText, caseSensitive);
            patternMatches = search.getMatches();
            printResults(patternMatches);
            printShiftTable(search);
            running = searchAgain();
        }

    }


    // Static Methods
    //==================================================================================================================

    /**
     * Static Method: getFilePath() - Get path to .txt file from user, then returns it.
     * @return (String) path to .txt file.
     */
    public static String getFilePath() {
        int count = 0;
        String filePath = "";
        Scanner kb = new Scanner(System.in);

        // Loops until valid file path is given
        while (!new File(filePath).exists()) {
            if (count < 1)
                System.out.println("Enter to path to the file you would like to search");
            else
                System.out.println("Invalid file path, try again.");
            filePath = kb.next();
            count++;
        }

        return filePath;
    }


    /**
     * Static Method: readInText() - Reads in data from .txt file and returns it as a string.
     * @param filePath(String) Path to text file to be searched.
     * @return (String) Contents of text file.
     * @throws IOException
     */
    public static String readInText(String filePath) throws IOException {
        StringBuilder textBuilder = new StringBuilder();
        Scanner fileInput = new Scanner(new File(filePath));

        while (fileInput.hasNext())
            textBuilder.append(fileInput.nextLine());

        fileInput.close();                  // Close file.

        return textBuilder.toString();      // Convert StringBuilder object to a String and return.
    }


    /**
     * Static Method: getPattern() Gets search pattern from user.
     * @return (String) Pattern to be searched against.
     */
    public static String getPattern() {
        Scanner kb = new Scanner(System.in);

        System.out.println("What word would you like to search for?");

        return  kb.next();
    }


    /**
     * Static Method getCaseSensitivity() - Determines if user would like the search to be case sensitive.
     * @return (boolean) true: case sensitive, false: case insensitive.
     */
    public static boolean getCaseSensitivity() {
        int choice;
        Scanner kb = new Scanner(System.in);

        System.out.println("Would you like a case sensitive search, enter 1 for yes or 0 for no.");
        choice = kb.nextInt();

        return (choice == 1);
    }


    /**
     * Static Method: printResults() - Prints results of search.
     * @param patternMatches(ArrayList) Holds index number of positive results.
     */
    public static void printResults(ArrayList<Integer> patternMatches) {

        System.out.println("Matches found: " + patternMatches.size());
        System.out.print("Found at indexes: " );

        if ( !patternMatches.isEmpty() ) {
            for (int i : patternMatches)
                System.out.print(i + ", ");
            System.out.println();
        }
    }

    public static void printShiftTable(WordSearch inSearch) {
        Scanner kb = new Scanner(System.in);
        int choice = -1;

        System.out.println("\nWould you like to view the shift table used in this search, enter 1 for yes or 0 for no.");
        choice = kb.nextInt();

        if (choice == 1)
            System.out.println(inSearch.hashToString());
    }

    /**
     * Static Method: searchAgain() - Determines if user would like to run another search.
     * @return (boolean) true: search again, false: end program.
     */
    public static boolean searchAgain() {
        Scanner kb = new Scanner(System.in);
        int choice = -1;
        System.out.println("\nWould you like another search? Enter 1 for another search or 0 to exit.");
        choice = kb.nextInt();
        return (choice == 1);
    }
    //==================================================================================================================
}// End Class
