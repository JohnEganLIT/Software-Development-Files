/*
Colin Maher
k00186813
Used this tutorial as a guide: https://www.youtube.com/watch?v=apDL78MFR3o

 */

package com.colin.tictactoe;

import android.graphics.Color;
import android.graphics.PorterDuff;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity implements View.OnClickListener
{
    private Button[][] buttons = new Button[3][3];
    private boolean player1Turn = true;
    private int roundCount;
    private boolean gameOver = false;

    private TextView statusTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        statusTextView = findViewById(R.id.statusTxtView);

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                String buttonID = "button_" + row + col;
                int resID = getResources().getIdentifier(buttonID, "id", getPackageName());
                buttons[row][col] = findViewById(resID);
                buttons[row][col].setOnClickListener(this);
            }
        }

        Button buttonNewGame = findViewById(R.id.newGameBtn);
        buttonNewGame.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                resetGame();
            }
        });
    }

    @Override
    public void onClick(View v)
    {
        // Prevents further entries when game is over.
        if (!gameOver)
        {
            // Checks if clicked button contains an empty string.
            if (!((Button) v).getText().toString().equals(""))
            {
                // Button has been used already. Returns without doing anything.
                return;
            }

            if (player1Turn)
            {
                ((Button) v).setText("X");
            }

            else
            {
                ((Button) v).setText("O");
            }

            roundCount++;

            if (checkForWin())
            {
                if (player1Turn)
                {
                    player1Wins();
                    gameOver = true;
                }
                else
                {
                    player2Wins();
                    gameOver = true;
                }
            }

            else if (roundCount == 9)
            {
                draw();
                gameOver = true;
            }

            else
                {
                // Switches turns. Sets player1Turn to its opposite.
                player1Turn = !player1Turn;

                if (player1Turn)
                {
                    statusTextView.setText("Player X's Turn");
                }
                else
                {
                    statusTextView.setText("Player O's Turn");
                }
            }
        }
    }

    private boolean checkForWin()
    {
        String[][] field = new String[3][3];

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                field[row][col] = buttons[row][col].getText().toString();
            }
        }

        // Checks rows for win.
        for (int row = 0; row < 3; row++)
        {
            // Returns true if any row has matching non blank cells.
            if (field[row][0].equals(field[row][1]) && field[row][0].equals(field[row][2]) && !field[row][0].equals(""))
            {
                return true;
            }
        }

        // Checks columns for win.
        for (int col = 0; col < 3; col++)
        {
            // Returns true if any column has matching non blank cells.
            if (field[0][col].equals(field[1][col]) && field[0][col].equals(field[2][col]) && !field[0][col].equals(""))
            {
                return true;
            }
        }

        // Checks 1st diagonal for win.
        if (field[0][0].equals(field[1][1]) && field[0][0].equals(field[2][2]) && !field[0][0].equals(""))
        {
            return true;
        }

        // Checks 2nd diagonal for win.
        if (field[0][2].equals(field[1][1]) && field[0][2].equals(field[2][0]) && !field[0][2].equals(""))
        {
            return true;
        }

        return false;
    }

    private void player1Wins() {
        statusTextView.setText("Player X wins!");
    }

    private void player2Wins() {
        statusTextView.setText("Player O wins!");
    }

    private void draw() {
        statusTextView.setText("Draw");
    }

    private void resetGame()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                buttons[row][col].setText("");
            }
        }

        roundCount = 0;
        player1Turn = true;
        gameOver = false;
        statusTextView.setText("Player X's Turn");
    }

    // Saves the state of variables on orientation change.
    @Override
    protected void onSaveInstanceState(Bundle outState)
    {
        super.onSaveInstanceState(outState);

        outState.putInt("roundCount", roundCount);
        outState.putBoolean("player1Turn", player1Turn);
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState)
    {
        super.onRestoreInstanceState(savedInstanceState);

        roundCount = savedInstanceState.getInt("roundCount");
        player1Turn = savedInstanceState.getBoolean("player1Turn");
    }
}
