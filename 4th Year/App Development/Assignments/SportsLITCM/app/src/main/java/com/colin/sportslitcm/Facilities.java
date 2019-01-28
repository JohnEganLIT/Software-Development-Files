package com.colin.sportslitcm;

import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;

import java.util.ArrayList;

public class Facilities extends AppCompatActivity
{
    ListView facilitiesList;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_facilities);

        // Changes title text to Facilities.
        ActionBar actionBar = getSupportActionBar();
        if (actionBar != null)
        {
            actionBar.setTitle(getString(R.string.facilities_menu));
            actionBar.setDisplayHomeAsUpEnabled(true);
        }

        facilitiesList = findViewById(R.id.facilitiesList);

        ArrayList<String> facilitiesInfoList = new ArrayList<>();
        facilitiesInfoList.add("Grass Pitches : GAA | Rugby | Soccer");
        facilitiesInfoList.add("All Weather Pitches : 3G Soccer Pitch | GAA Training Pitch | 5 Aside Ssoccer");
        facilitiesInfoList.add("Indoor Sports Halls : Soccer | Basketball | Fitness Classes");
        facilitiesInfoList.add("Gym");
        facilitiesInfoList.add("Strength and Conditioning Suite");
        facilitiesInfoList.add("Video Analysis: GAA | Soccer | Rugby");
        facilitiesInfoList.add("Millennium Theatre: Sports Conferences");
        facilitiesInfoList.add("Lecture Rooms: Team Meetings");

        ListAdapter adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, facilitiesInfoList);
        facilitiesList.setAdapter(adapter);
    }

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
