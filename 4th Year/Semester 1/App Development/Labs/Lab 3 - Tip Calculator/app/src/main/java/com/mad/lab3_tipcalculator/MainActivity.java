package com.mad.lab3_tipcalculator;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.inputmethod.EditorInfo;
import android.widget.Button;
import android.widget.EditText;
import android.widget.SeekBar;
import android.widget.TextView;

import java.io.Console;
import java.text.NumberFormat;

public class MainActivity extends AppCompatActivity
{
    private EditText billAmountEditText;
    private TextView percentTextView;
    private TextView tipTextView;
    private TextView totalTextView;
    private SeekBar percentSeekBar;
    private Button applyButton;
    private TextView discountTextView;

    private String billAmountString = "";
    private float tipPercent = .15f;

    private String subtotal = "0";

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        billAmountEditText = findViewById(R.id.billAmountEditText);
        percentTextView = findViewById(R.id.percentTextView);
        tipTextView = findViewById(R.id.tipTextView);
        totalTextView = findViewById(R.id.totalTextView);
        percentSeekBar = findViewById(R.id.percentSeekBar);
        applyButton = findViewById(R.id.applyButton);
        discountTextView = findViewById(R.id.discountTextView);

        percentSeekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser)
            {
                percentTextView.setText(String.valueOf(progress) + "%");
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });
        //billAmountEditText.setOnEditorActionListener((TextView.OnEditorActionListener) this);


    }

    public void calculateAndDisplay()
    {
        // Get bill amount.
        billAmountString = billAmountEditText.getText().toString();
        float billAmount;
        float discountAmount = 0;
        float totalAmount;
        float tipAmount;

        if(billAmountString.equals(""))
        {
            billAmount = 0;
        }
        else
        {
            billAmount = Float.parseFloat(billAmountString);
        }

        // 20 percent discount.
        if(billAmount >= 200)
        {
            discountAmount = billAmount * 20 / 100;
        }
        // 10 percent discount.
        else if(billAmount >= 100)
        {
            discountAmount = billAmount * 10 / 100;
        }

        tipPercent = percentSeekBar.getProgress();

        // Calculate tip and total.
        tipAmount = billAmount * tipPercent / 100;
        totalAmount = billAmount + tipAmount;

        // Display the other results with formatting.
        NumberFormat currency = NumberFormat.getCurrencyInstance();
        tipTextView.setText(currency.format(tipAmount));
        discountTextView.setText(currency.format(discountAmount));
        totalTextView.setText(currency.format(totalAmount));
        totalTextView.setText(currency.format(totalAmount));
    }

    public void onClick(View v)
    {
        calculateAndDisplay();
    }

    @Override
    public void onPause() {

        super.onPause();
        subtotal = String.valueOf(billAmountEditText.getText());
    }

    @Override
    public void onResume() {

        super.onResume();
        billAmountEditText.setText(subtotal);
        calculateAndDisplay();

    }


/*    public boolean onEditorAction(TextView v, int actionId, KeyEvent event)
    {
        if(actionId == EditorInfo.IME_ACTION_DONE || actionId == EditorInfo.IME_ACTION_UNSPECIFIED)
        {
            calculateAndDisplay();
        }
        return false;
    }*/
}
