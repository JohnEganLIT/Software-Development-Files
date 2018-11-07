package assignment.pkg4;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class DBConnection {
    
    public DBConnection()
    {
        try{
        Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/litrealty", "root", "");
        }
        catch(SQLException e)
        {
            displayMessage(e.toString());
        }     
    }
    
    private void displayMessage(String message)
    {
        JFrame frame = new JFrame();
        //frame.setTitle("dhfakjlsdhfkldshf");
        //JOptionPane.setTitle("Error");
        JOptionPane.showMessageDialog(frame, message, "Error", JOptionPane.INFORMATION_MESSAGE);
    }
}
