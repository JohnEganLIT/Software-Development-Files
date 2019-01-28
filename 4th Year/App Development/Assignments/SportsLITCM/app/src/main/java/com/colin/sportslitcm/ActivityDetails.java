package com.colin.sportslitcm;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

public class ActivityDetails extends AppCompatActivity
{
    DatabaseHelper activitiesDb;

    EditText nameTxtBox;
    EditText dateTxtBox;
    EditText timeTxtBox;
    EditText locationTxtBox;
    EditText campusTxtBox;
    EditText detailsTxtBox;
    Button updateButton;
    Button deleteButton;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_details);

        // Title Bar
        ActionBar actionBar = getSupportActionBar();
        if (actionBar != null)
        {
            // Sets text.
            actionBar.setTitle(getString(R.string.activity_details_title));

            // Adds back button.
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
        updateButton = findViewById(R.id.updateButton);
        deleteButton = findViewById(R.id.deleteButton);

        // Gets intent sent from Activities.
        Intent intent = this.getIntent();

        // Gets activity id from Activities.
        final String id = Integer.toString((Integer.parseInt(intent.getStringExtra("activityId"))));

        // Gets activity details and sets text box values.
        Cursor data = activitiesDb.getActivity(id);
        while(data.moveToNext())
        {
            nameTxtBox.setText(data.getString(1));
            dateTxtBox.setText(data.getString(2));
            timeTxtBox.setText(data.getString(3));
            locationTxtBox.setText(data.getString(4));
            campusTxtBox.setText(data.getString(5));
            detailsTxtBox.setText(data.getString(6));
        }

        // Listeners.
        updateButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                if(activitiesDb.updateActivity(id, nameTxtBox.getText().toString(), dateTxtBox.getText().toString(), timeTxtBox.getText().toString(), locationTxtBox.getText().toString(), campusTxtBox.getText().toString(), detailsTxtBox.getText().toString()))
                {
                    Toast.makeText(ActivityDetails.this, "Update Successful!", Toast.LENGTH_SHORT).show();
                    killActivity();
                }
                else
                {
                    Toast.makeText(ActivityDetails.this, "Update Failed!", Toast.LENGTH_SHORT).show();
                }
            }
        });

        deleteButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View w)
            {
                if(activitiesDb.deleteActivity(id))
                {
                    Toast.makeText(ActivityDetails.this, "Activity Deleted Successfully!", Toast.LENGTH_SHORT).show();
                    killActivity();
                }
                else
                {
                    Toast.makeText(ActivityDetails.this, "Activity Deletion Failed!", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    private void killActivity()
    {
        finish();
    }

    // On click code for back button.
    public boolean onOptionsItemSelected(MenuItem item)
    {
        switch (item.getItemId())
        {
            case android.R.id.home:
                finish();
                return true;
        }
        return super.onOptionsItemSelected(item);
    }
}