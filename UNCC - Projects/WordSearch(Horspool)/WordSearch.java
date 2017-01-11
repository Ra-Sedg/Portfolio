import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Class: WordSearch - Implements the horspool algorithm to search a String for a pattern.
 * @author Robert Adam Sedgwick
 * @version Extra credit assignment, Horspool implementation 4/29/16.
 */
public class WordSearch {

    // Fields
    //==================================================================================================================
    private String pattern;                     // Word to be searched for.
    private String text;                        // Text to be searched.
    private boolean caseSensitive;              // true: case sensitive, false: case insensitive.
    private int patternLength;                  // Length of word to be searched for.
    private int textLength;                     // Length of text to be searched.
    private int defaultShift;                   // Default shift value for characters not in shift table.
    private Map<Character, Integer> shiftMap;   // Hash of character and shift values.
    private ArrayList<Integer> results;         // Holds index locations of positive search results.
    //==================================================================================================================



    //Constructors
    //==================================================================================================================
    
    /**
     * Method: No-Args constructor - Sets parameters to default values.
     */
    public WordSearch() {
        this("Test", "Test", false);
    }


    /**
     * Method Augmented constructor - Takes arguments for parameters. 
     * @param inPattern(String) Word to be searched for.
     * @param inText(String) Text to be searched.
     * @param inCase(boolean) true: case sensitive search, false: case insensitive search.
     */
    public WordSearch(String inPattern, String inText, boolean inCase) {

        // Set text and pattern based on case sensitive, covert to all lowercase if case insensitive.
        caseSensitive = inCase;
        text = (caseSensitive) ? inText : inText.toLowerCase();
        pattern = (caseSensitive) ? inPattern : inPattern.toLowerCase();

        patternLength = pattern.length();
        textLength = text.length();
        defaultShift = pattern.length();
        results = new ArrayList<Integer>();
        shiftMap = new HashMap<Character, Integer>();

        preprocessShiftMap(); // Method populates shift table to be used by matching algorithm.
        horspoolMatching();   // Populates results list with positive matches.
    }
    //==================================================================================================================



    // Methods
    //==================================================================================================================

    /**
     * Method: getMatches() - Returns the ArrayList holding search results.
     * @return (ArrayList) - Search results.
     */
    public ArrayList<Integer> getMatches() {
        return results;
    }


    /**
     * Method preprocessShiftMap() - Populates hash with characters and there corresponding shift values.
     * Pseudo-code: Parses the search word from the next to last character to the first, determines shift value base
     *            on horspool algorithm and assigns the character and shift value to the hash.
     */
    private void preprocessShiftMap() {
        char key;
        int shiftValue;

        // Loop over search word from right to left starting at the next to last character.
        for (int i = (patternLength - 2); i >= 0; i--) {
            key = pattern.charAt(i);
            if (!shiftMap.containsKey(key)) {
                shiftValue = (patternLength - 1) - i;
                shiftMap.put(key, shiftValue);
            }
        }
    }


    /**
     * Method horspoolMatching() - Implementation of the horspool algorithm for string matching.
     * Pseudo-code: Searches text for pattern match, when a positive result is found the index of the first matching
     *              character is appended to the results ArrayList.
     */
    private void horspoolMatching() {
        int matches = 0;                // Holds count of matching characters, reset to 0 at each iteration.
        int index = patternLength - 1;  // Start search at this index.

        while (index <= textLength-1) {
            matches = 0;

            // Check text against pattern for matches
            while (matches <= patternLength-1 && pattern.charAt(patternLength-1-matches) == text.charAt(index-matches)) {
                matches++;
            }

            // If a match was found, add index location of match to results array.
            // else if a match was not found, look for character in shift table.
            //      if found, add shift value to index.
            //      else use, add default shift value to index.
            if (matches == patternLength) {
                results.add(index - patternLength + 1);
                index += patternLength;
            } else {
                if (shiftMap.containsKey(text.charAt(index)))
                    index += shiftMap.get(text.charAt(index));
                else
                    index += defaultShift;
            }
        }
    }

    public String toString() {
        return  "Pattern:        " + pattern + "\n" +
                "Case sensitive: " + caseSensitive + "\n" +
                "Matches found:  " + results.size();
    }

    public String hashToString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Pattern: " + pattern + "\n");
        for (Map.Entry<Character, Integer> entry : shiftMap.entrySet())
            sb.append("Key = " + entry.getKey().toString() + " : Value = " + entry.getValue().toString() + "\n");
        sb.append("Key = " + pattern.charAt(patternLength-1) + " : Value = " + patternLength + "\n" +
                  "Key = All other ASCII characters : Value = " + patternLength);

        return sb.toString();
    }
    //==================================================================================================================
}// End of Class
