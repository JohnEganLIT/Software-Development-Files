package com.mad.lab2_temperatureconverter;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity
{
    private EditText text;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        text = (EditText) findViewById(R.id.inputValue);
    }

    public void onClick(View view)
    {
        switch(view.getId())
        {
            case R.id.button:
                RadioButton celciusButton = (RadioButton) findViewById(R.id.radio1);
                RadioButton fahrenheitButton = (RadioButton) findViewById(R.id.radio2);

            if(text.getText().length() == 0)
            {
                Toast.makeText(this, "Please Enter Valid Number!", Toast.LENGTH_LONG).show();
                return;
            }

            float inputValue = Float.parseFloat(text.getText().toString());

            if(celciusButton.isChecked())
            {
                text.setText(String.valueOf(ConverterUtil.convertFahrenheitToCelsius(inputValue)));
                celciusButton.setChecked(false);
                fahrenheitButton.setChecked(true);
            }

            else
            {
                text.setText(String.valueOf(ConverterUtil.convertCelsiusToFahrenheit(inputValue)));
                fahrenheitButton.setChecked(false);
                celciusButton.setChecked(true);
            }
        }
    }
}
