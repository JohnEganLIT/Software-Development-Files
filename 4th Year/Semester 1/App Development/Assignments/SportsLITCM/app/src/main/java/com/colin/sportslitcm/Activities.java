package com.colin.sportslitcm;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class Activities extends AppCompatActivity
{
    DatabaseHelper activitiesDb;

    private ListView activitiesList;
    private View.OnClickListener itemClickListener;
    private List<String> idList;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activities_);

        // Changes title text to "LIT Sports".
        android.app.ActionBar actionBar = getActionBar();
        if (actionBar != null)
        {
            getActionBar().setDisplayShowTitleEnabled(true);
            getActionBar().setTitle(R.string.app_title);
        }

        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        activitiesList = findViewById(R.id.activitiesList);
        activitiesDb = DatabaseHelper.getInstance(getApplicationContext());
        idList = new ArrayList<>();

        populateListView();

        activitiesList.setOnItemClickListener(new OnItemClickListener()
        {
            public void onItemClick(AdapterView<?> parent, View view, int position, long id)
            {
                // Prepares ActivityDetails activity.
                Intent intent = new Intent(view.getContext(), ActivityDetails.class);

                // Passes selected activityId.
                intent.putExtra("activityId", idList.get(position));

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
        Intent intent;

        switch(item.getItemId())
        {
            case R.id.add_menu_option:
                // Opens new activity form.
                intent = new Intent(this, NewActivity.class);
                startActivity(intent);
                break;
            case R.id.contacts_menu_option:
                // Opens Facilities activity.
                intent = new Intent(this, Contacts.class);
                startActivity(intent);
                break;
            case R.id.facilities_menu_option:
                // Opens Contacts activity.
                intent = new Intent(this, Facilities.class);
                startActivity(intent);
                break;
            case R.id.reset_menu_option:
                activitiesDb.reset();
                Toast.makeText(this, "App Reset", Toast.LENGTH_SHORT).show();
                populateListView();
                break;
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onResume()
    {
        super.onResume();
        populateListView();
    }

    public void populateListView()
    {
        idList.clear();

        Cursor data = activitiesDb.getActivities();

        ArrayList<String> listData = new ArrayList<>();
        while(data.moveToNext())
        {
            String activity = data.getString(2) + " | " + data.getString(1) + " | " + data.getString(3);
            listData.add(activity);
            idList.add(data.getString(0));
        }

        ListAdapter adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, listData);
        activitiesList.setAdapter(adapter);
    }
}