package com.colin.sportslitcm;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.Layout;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Toast;

import java.io.Serializable;
import java.util.ArrayList;

public class Activities extends AppCompatActivity
{
    DatabaseHelper activitiesDb;

    private ListView activitiesList;
    private View.OnClickListener itemClickListener;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activities_);

        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        activitiesList = findViewById(R.id.activitiesList);
        activitiesDb = DatabaseHelper.getInstance(getApplicationContext());
        populateListView();

        activitiesList.setOnItemClickListener(new OnItemClickListener()
        {
            public void onItemClick(AdapterView<?> parent, View view, int position, long id)
            {
                String itemId = Integer.toString(position);

                // Prepares ActivityDetails activity.
                Intent intent = new Intent(view.getContext(), ActivityDetails.class);

                // Passes selected activityId.
                intent.putExtra("activityId", itemId);

                // Passes current instance of activitiesDb.
                //intent.putExtra("activitiesDb", activitiesDb);

                // Opens ActivityDetails drill down.
                startActivity(intent);
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        int id = item.getItemId();

        if (id == R.id.contacts_menu_option)
        {
            // Opens Facilities activity.
            Intent myIntent = new Intent(this, Contacts.class);
            startActivity(myIntent);
        }

        if (id == R.id.facilities_menu_option)
        {
            // Opens Contacts activity.
            Intent myIntent = new Intent(this, Facilities.class);
            startActivity(myIntent);
        }

        if(id == R.id.dummydata_menu_option)
        {
            activitiesDb.addDummyData();
            Toast.makeText(this, "Dummy Data Added", Toast.LENGTH_SHORT).show();
            populateListView();
        }

        if(id == R.id.reset_menu_option)
        {
            activitiesDb.reset();
            Toast.makeText(this, "App Reset", Toast.LENGTH_SHORT).show();
            populateListView();
        }

        return super.onOptionsItemSelected(item);
    }

    public void populateListView()
    {
        Cursor data = activitiesDb.getActivities();

        ArrayList<String> listData = new ArrayList<>();
        while(data.moveToNext())
        {
            String activity = data.getString(0) + " | " + data.getString(2) + " | " + data.getString(3);
            listData.add(activity);
        }

        ListAdapter adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, listData);
        activitiesList.setAdapter(adapter);
    }
}