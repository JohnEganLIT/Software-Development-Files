package Assignment2;

import java.awt.*;
import java.awt.event.*;
import java.util.*;
import javax.swing.*;
import javax.swing.border.*;

public class FlagQuiz extends JFrame
{
    //String array for storing country names
    private String[] countries = {"Australia", "Brazil", "China", "Italy", "Russia", "South Africa", "Spain", "United States"};

    //Boolean array for saving used flags
    private boolean[] flagsUsed = new boolean[countries.length];

    //Contains the index of current flag
    private int currentIndex; 

    //Tracks the number of flags that have been displayed
    private int count = 1;
    
    //Tracks the number of correct answers
    private int numCorrect = 0;
    
    //Bool stores id restart has been pressed
    boolean restart = false;
    
    //Flag Panel
    private JLabel flagImgJLabel;
    private JPanel flagJPanel;

    //Select Country Panel
    private JLabel selectCountryJLabel;
    private JComboBox selectCountryJComboBox; 

    //Feedback Panel
    private JTextField feedbackJTextField;

    //Submit Button
    private JButton submitJBtn; 

    //Next Flag Button
    private JButton nextFlagJBtn; 
    
    //Restart Button
    private JButton restartJBtn;
    
    //Constructor
    public FlagQuiz()
    {      
        createInterface();      
    }
    
    private void createInterface()
    {
        //Sets up Jpane for attaching components
        Container contentPane = getContentPane();
        
        //Enable explicit positioning of GUI components 
        contentPane.setLayout( null );
        
        //Sets up flag panel 
        flagJPanel = new JPanel();
        flagJPanel.setBounds(15, 10, 100, 90);
        flagJPanel.setBorder(new TitledBorder("Flag"));
        contentPane.add(flagJPanel);
        
        //Sets up flag label
        flagImgJLabel = new JLabel();
        flagImgJLabel.setBounds(12, 15, 80, 80);
        flagImgJLabel.setHorizontalAlignment(JLabel.CENTER);
        flagJPanel.add(flagImgJLabel);

        //Sets up Select Country label
        selectCountryJLabel = new JLabel();
        selectCountryJLabel.setBounds(135, 10, 100, 25);
        selectCountryJLabel.setText("Select country:");
        contentPane.add(selectCountryJLabel);

        Arrays.sort(countries); //Sort the array

        //Sets up select country dropdown menu
        selectCountryJComboBox = new JComboBox(countries);
        selectCountryJComboBox.setBounds(135, 30, 135, 25);
        selectCountryJComboBox.setMaximumRowCount(3);
        contentPane.add(selectCountryJComboBox);

        displayFlag(); //Display first flag

        //Sets up feedback text field
        feedbackJTextField = new JTextField();
        feedbackJTextField.setBounds(135, 60, 135, 35);
        feedbackJTextField.setHorizontalAlignment(JTextField.CENTER);
        feedbackJTextField.setEditable(false);
        contentPane.add(feedbackJTextField);
        
        //Sets up submit button
        submitJBtn = new JButton();
        submitJBtn.setBounds(285, 5, 90, 30);
        submitJBtn.setText("Submit");
        contentPane.add(submitJBtn);
        submitJBtn.addActionListener
        (
            new ActionListener() 
            {
               public void actionPerformed(ActionEvent event)
               {
                    submitAction(event);
               }    
            } 
        ); 

        //Sets up next flag button
        nextFlagJBtn = new JButton();
        nextFlagJBtn.setBounds(285, 40, 90, 30);
        nextFlagJBtn.setText("Next Flag");
        nextFlagJBtn.setEnabled(false);
        contentPane.add(nextFlagJBtn);
        nextFlagJBtn.addActionListener
        (
            new ActionListener() 
            {
               public void actionPerformed(ActionEvent event)
               {
                    nextFlagAction(event);
               }
            } 
        ); 
        
        //Sets up restart button
        restartJBtn = new JButton();
        restartJBtn.setBounds(285, 75, 90, 30);
        restartJBtn.setText("Restart");
        contentPane.add(restartJBtn);
        restartJBtn.addActionListener
        (
            new ActionListener() 
            {
               public void actionPerformed(ActionEvent event)
               {
                    restartAction(event);
               }    
            } 
        );

        //Sets properties of JFrame pane
        setTitle("Flag Quiz"); //Sets title bar string
        setSize(400, 160);     //Sets pane size
        setVisible(true);      //Display pane

    } //End createInterface Function
    
    //Return an unused random number
    private int getUniqueRandomNumber()
    {
        Random generator = new Random();
        int randomNumber;

        do
        {
            //Generates a number between 0-7
            randomNumber = generator.nextInt(8);
        }
        while (flagsUsed[randomNumber] == true);

        //Indicates that flag has been used`
        flagsUsed[randomNumber] = true;

        return randomNumber;  
   } //End getUniqueRandomNumber function
   
    //Chooses a flag and display it in the JLabel
    private void displayFlag()
    {
       //Get an unused flag
       currentIndex = getUniqueRandomNumber(); 

       //Creates the path for that flag
       String country = (String) selectCountryJComboBox.getItemAt(currentIndex);
       String countryPath = "src/images/" + country + ".png";
       System.out.println(countryPath);

       //Sets the flagJLabel to display the flag
       flagImgJLabel.setIcon(new ImageIcon(countryPath));

    } //End displayFlag function
   
    //Checks the answer and updates the quiz
    private void submitAction(ActionEvent event)
    {
       //Determines whether the answer was correct
       if(selectCountryJComboBox.getSelectedIndex() == currentIndex)
       {
          feedbackJTextField.setText("Correct!");
          numCorrect++;
       }

       else //If an incorrect answer is given
       {
          feedbackJTextField.setText("Sorry, incorrect.");
       }

       //Inform user if quiz is over
       if(count == 5)
       {
             feedbackJTextField.setText("You Score = " + numCorrect + "/" + "5");

             //Sets the flagJLabel to display a Game Over image
             flagImgJLabel.setIcon(new ImageIcon("src/images/GameOver.png"));

             //Disables submit button, next flag button and the country dropdown menu
             nextFlagJBtn.setEnabled(false);
             submitJBtn.setEnabled(false);
             selectCountryJComboBox.setEnabled(false);
       }

       else // if less than 5 flags have been displayed
       {
          submitJBtn.setEnabled(false);
          nextFlagJBtn.setEnabled(true);
       }   
    } //End submitJBtnActionPerformed function
   
    //Displays next flag in the quiz
    private void nextFlagAction(ActionEvent event)
    {
       displayFlag(); // display next flag
       count++;

       // reset GUI components to initial states
       feedbackJTextField.setText("");
       selectCountryJComboBox.setSelectedIndex(0);
       submitJBtn.setEnabled(true);
       nextFlagJBtn.setEnabled(false);

    } // end method nextFlagJBtnActionPerformed
    
    //Displays next flag in the quiz
    private void restartAction(ActionEvent event)
    {
        dispose();
        
        login.show();
        
    } // end method nextFlagJBtnActionPerformed
    
    public static void main(String[] args) 
    {
        launcher();
        
    } //End main function 
    
    public static void launcher()
    {     
        FlagQuiz application = new FlagQuiz();
        application.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
  
    }
}
