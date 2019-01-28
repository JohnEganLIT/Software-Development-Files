package com.colin.sportslitcm;

import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

public class Contacts extends AppCompatActivity {

    ListView contactsList;

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
            actionBar.setDisplayHomeAsUpEnabled(true);
        }

        contactsList = findViewById(R.id.contactsList);

        ArrayList<String> contactInfoList = new ArrayList<>();
        contactInfoList.add("Adrian Flaherty | Sports Officer | 061-0283579");
        contactInfoList.add("Paul Browne | Paul Brown | 061-293492");
        contactInfoList.add("Joy Neville | Rugby Officer | 061-293292");

        ListAdapter adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, contactInfoList);
        contactsList.setAdapter(adapter);

        contactsList.setOnItemClickListener(new AdapterView.OnItemClickListener()
        {
            public void onItemClick(AdapterView<?> parent, View view, int position, long id)
            {
                String phone = "0";
                if(position == 0)
                {
                    phone = "061-293579";
                }
                else if(position == 1)
                {
                    phone = "061-293492";
                }
                else if(position == 2)
                {
                    phone = "061-293292";
                }

                Intent intent = new Intent(Intent.ACTION_DIAL, Uri.fromParts("tel", phone, null));
                startActivity(intent);
            }
        });
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
