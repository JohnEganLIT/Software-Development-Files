package com.colin.sportslitcm;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.io.Serializable;
import java.util.ArrayList;

public class ActivityDetails extends AppCompatActivity
{
    DatabaseHelper activitiesDb;

    private ListView activityDetails;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_details);

        // Changes title text to "Contacts".
        ActionBar actionBar = getSupportActionBar();
        if (actionBar != null)
        {
            actionBar.setTitle(getString(R.string.activity_details_title));
        }
        activitiesDb = DatabaseHelper.getInstance(getApplicationContext());

        activityDetails = findViewById(R.id.activityDetails);

        Intent intent = this.getIntent();
        String id = intent.getStringExtra("activityId");
        Toast.makeText(this, id, Toast.LENGTH_SHORT).show();
        Cursor data = activitiesDb.getActivity(id);
        ArrayList<String> listData = new ArrayList<>();
        while(data.moveToNext())
        {
            String activity = data.getString(0) + " : " + data.getString(1) + " | " + data.getString(2) + " | " + data.getString(3) + " | " + data.getString(4) + " | " + data.getString(5) + " | " + data.getString(6);
            listData.add(activity);
        }

        ListAdapter adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, listData);
        activityDetails.setAdapter(adapter);

        /*


        Cursor data = activitiesDb.getActivity(intent.getStringExtra("activityId"));

        ArrayList<String> listData = new ArrayList<>();
        while(data.moveToNext())
        {
            String activity = data.getString(0) + " : " + data.getString(1) + " | " + data.getString(2) + " | " + data.getString(3) + " | " + data.getString(4) + " | " + data.getString(5) + " | " + data.getString(6);
            //listData.add(activity);

            Toast.makeText(this, activity, Toast.LENGTH_SHORT).show();

                Toast.makeText(this, "Empty", Toast.LENGTH_SHORT).show();

        }
        /*
        ListAdapter adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, listData);
        activityDetailsList.setAdapter(adapter);
        */
    }
}