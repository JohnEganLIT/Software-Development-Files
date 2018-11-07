package assignment.pkg1;

import java.util.Random;
import javax.swing.*;

public class Assignment1 
{
    public static void main(String[] args) 
    {
        boolean exit = false;
        
        while(exit == false)
        {
            String questions[] = 
            {
                "What is the name of the largest county in Ireland?",
                "What is the capital of Norway?",
                "Who is the president of The United States of America?",
                "What is the name of the tallest mountain in the world?", 
                "What is the smallest county in Ireland?",
                "Berlin is the capital of which country?",
                "What is the largest inland county in Ireland?",
                "Who is the Taoiseach of Ireland?",
                "Paris is the capital city of which country?",
                "How many counties are there in the Republic of Ireland?"
            };

            String answers[] =
            {
                "Cork",
                "Oslo",
                "Barack Obama",
                "Everest",
                "Louth",
                "Germany",
                "Tipperary",
                "Enda Kenny",
                "France",
                "26"
            };

            boolean[] questions_asked  = new boolean[10];

            for(int i=0;i<10;i++)
            {
                questions_asked[i] = false;
            }    

           // int random = 0;
            Random rand = new Random();
            int random = rand.nextInt(10);

            int correct = 0;

            for(int i=0;i<5;i++)
            {  
                while(questions_asked[random] == true)
                {
                    random = rand.nextInt(10);
                }

                String input = JOptionPane.showInputDialog(questions[random]);

                questions_asked[random] = true;

                String answer = answers[random];

                if(input.equalsIgnoreCase(answer))
                {
                    JOptionPane.showMessageDialog(null, input + " is the CORRECT answer :)" , "Answer", JOptionPane.INFORMATION_MESSAGE);
                    correct++;
                }

                else
                {
                    JOptionPane.showMessageDialog(null, input + " is the Wrong answer :(", "Answer", JOptionPane.INFORMATION_MESSAGE);
                }
            }

            double percentage = (correct * 100) / 5;   

            JOptionPane.showMessageDialog(null, "You got " + Integer.toString(correct) + " out of 5 questions correct\n%" + Double.toString(percentage)  , "Result", JOptionPane.INFORMATION_MESSAGE);

            JFrame frame = new JFrame();
            String[] options = new String[2];
            options[0] = new String("Try again?");
            options[1] = new String("Exit");
            int option = JOptionPane.showOptionDialog(frame.getContentPane(),"Thank you for taking the quiz","Thanks", 0,JOptionPane.INFORMATION_MESSAGE,null,options,null);

            if(option == 1)
            {
                exit = true;
            }
        }    
    } 
}

