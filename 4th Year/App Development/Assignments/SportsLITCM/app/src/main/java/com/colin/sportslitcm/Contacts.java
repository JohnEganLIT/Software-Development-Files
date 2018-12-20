package com.colin.sportslitcm;

import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class Contacts extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_contacts);

        // Changes title text to "Contacts".
        ActionBar actionBar = getSupportActionBar();
        if (actionBar != null)
        {
            actionBar.setTitle(getString(R.string.contacts_menu));
        }
    }
}
