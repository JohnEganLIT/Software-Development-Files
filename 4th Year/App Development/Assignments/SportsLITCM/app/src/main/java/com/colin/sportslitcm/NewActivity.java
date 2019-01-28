package com.colin.sportslitcm;

import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class NewActivity extends AppCompatActivity
{
    DatabaseHelper activitiesDb;

    EditText nameTxtBox;
    EditText dateTxtBox;
    EditText timeTxtBox;
    EditText locationTxtBox;
    EditText campusTxtBox;
    EditText detailsTxtBox;
    Button addNewButton;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_new);

        // Changes title text to "New Activity".
        ActionBar actionBar = getSupportActionBar();
        if (actionBar != null)
        {
            actionBar.setTitle(getString(R.string.new_activity));
            actionBar.setDisplayHomeAsUpEnabled(true);
        }

        // Gets the current instance of DatabaseHelper.
        activitiesDb = DatabaseHelper.getInstance(getApplicationContext());

        // References for textboxes and buttons.
        nameTxtBox = findViewById(R.id.nameTxtBox);
        dateTxtBox = findViewById(R.id.dateTxtBox);
        timeTxtBox = findViewById(R.id.timeTxtBox);
        locationTxtBox = findViewById(R.id.locationTxtBox);
        campusTxtBox = findViewById(R.id.campusTxtBox);
        detailsTxtBox = findViewById(R.id.detailsTxtBox);
        addNewButton = findViewById(R.id.addNewButton);

        // Listeners.
        addNewButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                if(activitiesDb.addActivity(nameTxtBox.getText().toString(), dateTxtBox.getText().toString(), timeTxtBox.getText().toString(), locationTxtBox.getText().toString(), campusTxtBox.getText().toString(), detailsTxtBox.getText().toString()))
                {
                    Toast.makeText(NewActivity.this, "Activity Added Successfully!", Toast.LENGTH_SHORT).show();
                    killActivity();
                }
                else
                {
                    Toast.makeText(NewActivity.this, "Activity Added Failed!", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    private void killActivity()
    {
        finish();
    }
}
