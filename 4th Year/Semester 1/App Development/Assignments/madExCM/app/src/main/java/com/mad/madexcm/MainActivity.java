/*
Colin Maher
k00186813
SD4
 */

package com.mad.madexcm;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import java.text.DecimalFormat;
import java.text.NumberFormat;

public class MainActivity extends AppCompatActivity
{
    private EditText currencyTxtBox1;
    private EditText currencyTxtBox2;
    private Spinner currencyDropDown1;
    private Spinner currencyDropDown2;
    private Button convertButton;

    // https://www.mkyong.com/java/java-display-double-in-2-decimal-points/
    private static DecimalFormat df2 = new DecimalFormat(".##");

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        currencyTxtBox1 = findViewById(R.id.currencyTxtBox1);
        currencyTxtBox2 = findViewById(R.id.currencyTxtBox2);
        currencyDropDown1 = findViewById(R.id.currencyDropDown1);
        currencyDropDown2 = findViewById(R.id.currencyDropDown2);

        convertButton = findViewById(R.id.convertButton);
        convertButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                CalculateAndDisplay();
            }
        });
    }

    public void CalculateAndDisplay()
    {

        double currency1Amt, currency2Amt, euro = 0, pound = 0, dollar = 0, result1 = 0, result2 = 0;
        String currency1, currency2;

        if(currencyTxtBox1.getText().toString().matches("") )
        {
            currency1Amt = 0;
        }

        else
        {
            currency1Amt = Float.parseFloat(currencyTxtBox1.getText().toString());
        }

        if(currencyTxtBox2.getText().toString().matches(""))
        {
            currency2Amt = 0;
        }

        else
        {
            currency2Amt = Float.parseFloat(currencyTxtBox2.getText().toString());
        }

        currency1 = currencyDropDown1.getSelectedItem().toString();
        currency2 = currencyDropDown2.getSelectedItem().toString();

        if(currency1.equals("Euro"))
        {
            euro = result1 = currency1Amt;
            pound = currency1Amt * 0.89;
            dollar = currency1Amt * 0.14;
        }

        else if(currency1.equals("Pound"))
        {
            pound = result1 = currency1Amt;
            euro = currency1Amt * 1.12;
            dollar = currency1Amt * 1.28;
        }

        if(currency1.equals("Dollar"))
        {
            dollar = result1 = currency1Amt;
            euro = currency1Amt * 0.88;
            pound = currency1Amt * 0.78;
        }

        if(currency2.equals("Euro"))
        {
            result2 = euro;
        }

        if(currency2.equals("Pound"))
        {
            result2 = pound;
        }

        if(currency2.equals("Dollar"))
        {
            result2 = dollar;
        }

        currencyTxtBox1.setText(String.format("%.2f", result1));
        currencyTxtBox2.setText(String.format("%.2f", result2));
    }
}
