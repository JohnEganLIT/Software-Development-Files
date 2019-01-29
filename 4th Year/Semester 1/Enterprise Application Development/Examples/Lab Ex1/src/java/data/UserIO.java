package data;

import business.User;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import static java.sql.DriverManager.println;

public class UserIO 
{
    public static void add(User user, String filepath) throws IOException
    {
        File file = new File(filepath);
        PrintWriter out = new PrintWriter(new FileWriter(file, true));
        out.println(user.getName() + "/" + user.getAddress() + "/" +  user.getCity() + "/" + user.getCountry() + "/" + user.getPhone()
                + "/"  + user.getEmail() + "/"  + user.getGender() + "/" + user.getHear() + "/" + user.getComments());
        out.close();
    }
}
