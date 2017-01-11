/**
 * Date class: Used to store and manipulate dates.
 * @author Robert Adam Sedgwick
 * @version Take home test 3
 */
public class Date {

    // Fields
    //=================================================================================================================
    private int day;
    private int month;
    private int year;
    private int julianDayNumber;
    private boolean leapYear = false;
    private static final int YEAR_DAYS_COMMON = 365;
    private static final int YEAR_DAYS_LEAP = 366;
    private static final int[] MONTH_DAYS_COMMON = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
    private static final int[] MONTH_DAYS_LEAP = {0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
    private static final int[] MONTHS = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
    //=================================================================================================================


    // Methods
    //=================================================================================================================

    // Constructors
    //------------------------------------------------------------------------------------------------------------------

    /**
     * No-args constructor
     */
    public Date() {
        this(1, 1, 1);
    }


    /**
     * Argument constructor
     */
    public Date(int inDay, int inMonth, int inYear) {
        if (inDay >= 1 && inDay <= 31) {
            this.day = inDay;
        }

        if (inMonth >= 1 && inMonth <= 12) {
            this.month = inMonth;
        }

        if (inYear >= 1583) {
            this.year = inYear;
        }

        julianDayNumber = gregorianToJulian();
        this.leapYear = isLeapYear(this.year);
    }


    /**
     * Copy constructor
     */
    public Date(Date inDate) {
        this.day = inDate.getDay();
        this.month = inDate.getMonth();
        this.year = inDate.getYear();
        this.leapYear = isLeapYear(this.year);

    }


    // Getters
    //------------------------------------------------------------------------------------------------------------------

    /**
     * Method: getDay() - Returns day field.
     *
     * @return (int) Day field.
     */
    public int getDay() {
        return day;
    }


    /**
     * Method: getMonth() - Returns month field.
     *
     * @return (int) Month field.
     */
    public int getMonth() {
        return month;
    }


    /**
     * Method: getYear() - Returns year field.
     *
     * @return (int) Year Field.
     */
    public int getYear() {
        return year;
    }


    public double getJulianDayNumber() {
        return julianDayNumber;
    }


    /**
     * Method: getDate - Returns formatted string representation of Date object.
     *
     * @param format(String) "Long" = "1st of January, 1990", "Short" = "01/01/1990".
     * @return (String) Returns a formatted string representation of Date object.
     */
    public String getDate(String format) {
        return "";
    }


    // Setters
    //------------------------------------------------------------------------------------------------------------------

    /**
     * Method: setDay() - Tests and sets a new value for the day field, if appropriate.
     *
     * @param inDay(int) Incoming value for day field must be, in range: 1 <= inDay <= 31.
     */
    public void setDay(int inDay) {
        if (inDay >= 1 && inDay <= 31) {
            this.day = inDay;
        }
    }


    /**
     * Method: setMonth() - Test and sets a new value for the month field, if appropriate.
     *
     * @param inMonth(int) Incoming value for Month field, must be in range: 1 <= inMonth <= 12.
     */
    public void setMonth(int inMonth) {
        if (inMonth >= 1 && inMonth <= 12) {
            this.month = inMonth;
        }
    }


    /**
     * Method: setYear() - Test and sets a new value for the year field, if appropriate.
     *
     * @param inYear(int) Incoming value for year field, must be in range: inYear >= 1.
     */
    public void setYear(int inYear) {
        if (inYear >= 1583) {
            this.year = inYear;
        }
    }


    // Date Manipulation
    //------------------------------------------------------------------------------------------------------------------

    /**
     * Pre-test - common
     * Method: add() - Adds a given number of days to Date.
     *
     * @param numDays(int) Number of days to be added as an positive integer.
     * @return (Date) Returns a reference variable to a new date with days added.
     */
    public Date add(int numDays) {
        int[] arr = new int[2];
        int outDay = this.day;
        int outMonth = this.month;
        int outYear = this.year;

        arr = daysToYears(numDays);
        outYear += arr[0];
        numDays = arr[1];

        arr = monthsToAdd(numDays);
        outDay = arr[1];

        for (int i = arr[0]; i > 0; i--) {
            arr = incrementMonth(outMonth);
            outMonth = arr[0];
            outYear += arr[1];
        }
        return new Date(outDay, outMonth, outYear);
    }


    /**
     * pretested - common
     * Method: subtract() - Subtracts given number of days from Date.
     *
     * @param numDays(int) Number of days to be subtracted as a positive integer.
     * @return (Date) Returns a reference variable to a new date with days subtracted.
     */
    public Date subtract(int numDays) {

        int[] arr = new int[2];
        int outDay = this.day;
        int outMonth = this.month;
        int outYear = this.year;

        arr = daysToYears(numDays);
        outYear -= arr[0];
        outDay = arr[1];

        arr = monthsToSubtract(outDay);
        outDay = arr[1];

        for (int i = arr[0]; i > 0; i--) {
            arr = decrementMonth(outMonth);
            outMonth = arr[0];
            outYear += arr[1];
        }

        return new Date(outDay, outMonth, outYear);
    }


    /**
     * Method: daysToYears() - Converts days to Year & remaining days.
     *
     * @param inDays(int) Number of days to convert.
     * @return (int[]) A[0] = Years, A[1] = remaining days.
     */
    public int[] daysToYears(int inDays) {
        int[] arr = new int[2];
        int years = 0;
        int days = 1;
        if (leapYear) {
            arr[years] = inDays / YEAR_DAYS_LEAP;
            arr[days] = inDays & YEAR_DAYS_LEAP;
        } else {
            arr[years] = inDays / YEAR_DAYS_COMMON;
            arr[days] = inDays % YEAR_DAYS_COMMON;
        }
        return arr;
    }


    /**
     * Method: monthsToSubtract() - Calculates how many months can be subtracted form this.Date give a number of days.
     *
     * @param subDays(int) Number of days to be subtracted from this.Date.
     * @return (int[]) A[0] = Months, A[1] = remaining days.
     */
    public int[] monthsToSubtract(int subDays) {
        int[] arr = new int[2];
        int tempDay = this.day;
        int tempMonth = this.month;
        int monthCount = 0;

        while (subDays > 0) {
            subDays -= tempDay;
            arr = decrementMonth(tempMonth);
            tempMonth = arr[0];
            tempDay = (leapYear && tempMonth == 2) ? MONTH_DAYS_LEAP[tempMonth] : MONTH_DAYS_COMMON[tempMonth];
            if (subDays > 0) {
                monthCount++;
            }
        }
        arr[0] = monthCount;
        arr[1] = subDays * -1;
        return arr;
    }


    /**
     * Method: monthsToAdd() - Calculates the number of months that can be added to this.Date given a number of days.
     *
     * @param addDays(int) The number of days to be added to this.Date.
     * @return (int[]) A[0] = Months, A[1] = Remaining days.
     */
    public int[] monthsToAdd(int addDays) {
        int[] arr = new int[2];
        int tempDay = this.day;
        int tempMonth = this.month;
        int monthCount = 0;

        while (addDays > 1) {
            int monthDays = (leapYear && tempMonth == 2) ? MONTH_DAYS_LEAP[tempMonth] : MONTH_DAYS_COMMON[tempMonth];
            if (tempDay + addDays > monthDays) {
                addDays -= (monthDays - tempDay);
                arr = incrementMonth(tempMonth);
                tempMonth = arr[0];
                tempDay = 0;
                monthCount++;
            } else {
                tempDay += addDays;
                addDays = 0;
            }
        }
        arr[0] = monthCount;
        arr[1] = tempDay;
        return arr;
    }


    /**
     * incrementMonth() - Adds one to given month, handles rollover if needed.
     *
     * @param inMonth(int) Month to be incremented as integer; (1:Jan)...(12:Dec).
     * @return (int[]) A[0] = New month, A[1] Change in year.
     */
    public int[] incrementMonth(int inMonth) {
        int arr[] = new int[2];
        inMonth++;
        if (inMonth > 12) {
            arr[0] = 1;
            arr[1] = 1;
        } else {
            arr[0] = inMonth;
            arr[1] = 0;
        }
        return arr;

    }


    /**
     * decementMonth() - Subtracts one from given month, handles rollover if needed.
     *
     * @param inMonth(int) Month to be decremented as integer; (1:Jan)...(12:Dec).
     * @return (int[]) A[0] = New month; A[1] Change in year.
     */
    public int[] decrementMonth(int inMonth) {
        int[] arr = new int[2];
        inMonth--;
        if (inMonth < 1) {
            arr[0] = 12;
            arr[1] = -1;
        } else {
            arr[0] = inMonth;
            arr[1] = 0;
        }
        return arr;
    }


    /**
     * Method: daysBetween()- Return number of days between this.Date and inDate
     *
     * @param inDate(Date) Reference variable of incoming Date.
     * @return (int) Number of days between two dates.
     */
    public int daysBetween(Date inDate) {
        Date d2 = new Date(inDate);


        switch (this.compareTo(d2)) {
            case -1:
                System.out.println("In case -1");
                return daysThisYear(d2) - daysThisYear(this);
            case 0:
                System.out.println("In case 0");
                return 0;
            case 1:
                System.out.println("In case 1");
                return daysThisYear(this) - daysThisYear(d2);
        }
        return -1;
    }

    // pretested
    public int daysThisYear(Date inDate) {
        Date date = new Date(inDate);
        int day, month, year;
        month = (date.month + 9) % 12;
        year = date.year - (month / 10);
        return (YEAR_DAYS_COMMON * year + (year / 4) - (year / 100) + (year / 400) + ((month * 306 + 5) / 10) + (date.day - 1));

    }


    /**
     * Method: isLeapYear() - Returns a boolean indicating if input year is a leap year.
     *
     * @param inYear(int) A year as an integer.
     * @return (boolean) True if a leap year, else false.
     */
    private static boolean isLeapYear(int inYear) {
        if (inYear % 4 != 0) {
            return false;
        } else if (inYear % 400 == 0) {
            return true;
        } else if (inYear % 100 == 0) {
            return false;
        } else {
            return true;
        }
    }


    // Misc Methods
    //------------------------------------------------------------------------------------------------------------------

    /**
     * Method: equals() - Compares two objects and determines equality based on field values.
     *
     * @param inDate(Date) Reference variable of incoming Date object.
     * @return (boolean) true if objects are equal, else false.
     */
    public boolean equals(Date inDate) {
        return false;
    }


    /**
     * Method: compareTo() - Compares two objects based on value of fields.
     *
     * @param inDate(Date) Reference variable of incoming date object.
     * @return (int) 1 = greater than, 0 = equal, -1 = less than.
     */
    public int compareTo(Date inDate) {
        Date compareDate = new Date(inDate);

        if (this.year < compareDate.year)
            return -1;
        if (this.year > compareDate.year)
            return 1;

        if (this.month < compareDate.month)
            return -1;
        if (this.month > compareDate.month)
            return 1;

        if (this.day < compareDate.day)
            return -1;
        if (this.day > compareDate.day)
            return 1;

        return 0;
    }

    /**
     * Method: toString() - Returns a string representation of Date object.
     *
     * @return (String)
     */
    public String toString() {
        return "Day:   " + this.day + "\n" +
                "Month: " + this.month + "\n" +
                "Year:  " + this.year + "\n";
    }

    public Date getStuff() {
        Date d1 = julianToGregorian(julianDayNumber);
        return d1;
    }

    private int gregorianToJulian() {
        int a = (14 - this.month) / 12;
        int y = this.year + 4800 - a;
        int m = this.month + (12 * a) - 3;

        return this.day + (((153 * m) + 2) / 5) + (365 * y) + (y / 4) - (y / 100) + (y / 400) - 32045;
    }



    public Date julianToGregorian(int JDN) {
        JDN--;
        int a = JDN + 32044;
        int b = ((4*a) + 3)/(146097);
        int c = a - ((146097*b)/4);
        int d = ((4*c)+3)/1461;
        int e = c - (1461*d)/(4);
        int m = ((5*e)+2)/153;
        int tempDay = e - (((153*m)+2)/5)+1;
        int tempMonth = m + 3 - 12 * (m/10);
        int tempYear = (100*b) + d- 4800 + (m/10);
        return new Date(tempDay, tempMonth, tempYear);
    }

}