/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ws.rest.dob;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.StreamTokenizer;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.GregorianCalendar;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;

/**
 * REST Web Service
 *
 * @author Alan.Ryan
 */
@Path("DOBPopularity")
public class DOBPopularityResource {
   

    @Context
    private UriInfo context;

    FileReader frs = null;

    // Declare streamTokenizer
    StreamTokenizer in = null;

    int[] days = new int[367]; //array to store each value wich is read from the file
    //366 days in a leap year, no value stored in days[0] so array needs
    //to be sized at 367

    //store the max number of days in each month
    int[] daysInMonths = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

    //var to determine where each value which is read from the file is stored in the array
    int day = 0;

    public DOBPopularityResource() throws FileNotFoundException {

        
        // Create file input and output streams
        frs = new FileReader("days.txt");

        // Create a stream tokenizer wrapping file input stream
        in = new StreamTokenizer(frs);

        readFile(); // read contents of file into array
    }

    /**
     * Retrieves representation of an instance of
     * ws.rest.dob.DOBPopularityResource
     *
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.TEXT_PLAIN)
    public String getText() {

        return new Date().toString();
    }

    @GET
    @Path("{dd}/{mm}")
    @Produces(MediaType.TEXT_PLAIN)
    public String getText(@PathParam("dd") String dd, @PathParam("mm") String mm) throws ParseException {

        int rank;
        if (isValidDate(dd + "/" + mm)) {

            int d = getDayOfYear(dd + "/" + mm);
            //readFile();
            rank = days[d];
            return Integer.toString(rank);
        } else {
            return "-1";
        }

    }

    private void readFile() {
        try {
            for (int i = 0; i < 31; i++) {
                in.nextToken();
            }

            in.nextToken();

            while (in.ttype != StreamTokenizer.TT_EOF) {

                for (int month = 0; month < 12; month++) {
                    readDaysInMonth(month);
                    if (in.nextToken() == StreamTokenizer.TT_EOF) {
                        break;
                    }
                }

            }

        } catch (Exception ex) {
            System.out.println(ex);
            System.exit(0);
        }
    }

    private void readDaysInMonth(int month) {

        for (int i = 0; i < daysInMonths[month]; i++) {
            day++;
            try {
                in.nextToken();
            } catch (IOException ex) {
                System.out.println(ex);
            }

            int value = (int) in.nval;
            days[day] = value;

        }

    }

    private static int getDayOfYear(String dateString) throws ParseException {
        int month = 0;
        SimpleDateFormat sdf;
        Date date = null;
        try {
            month = Integer.parseInt(dateString.substring(3));

            sdf = new SimpleDateFormat("dd/MM");
            date = null;

            date = sdf.parse(dateString);
        }//end try
        catch (NumberFormatException | ParseException ex) {
            System.out.println(ex);
        }//end catch
        GregorianCalendar gCal = new GregorianCalendar();
        gCal.setTime(date);

        if (month >= 3) {
            return gCal.get(GregorianCalendar.DAY_OF_YEAR) + 1;
        } else {
            return gCal.get(GregorianCalendar.DAY_OF_YEAR);
        }
    }

    static boolean isValidDate(String dateToValidate) {

        dateToValidate += "/2016";
        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
        sdf.setLenient(false);

        try {

            //if not valid, it will throw ParseException
            sdf.parse(dateToValidate);

        } catch (ParseException e) {

            return false;
        }

        return true;

    }
}
