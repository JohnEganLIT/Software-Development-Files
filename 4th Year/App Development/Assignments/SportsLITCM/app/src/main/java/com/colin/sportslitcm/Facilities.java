package com.colin.sportslitcm;

import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class Facilities extends AppCompatActivity
{
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
        }
    }
}
