package com.colin.sportslitcm;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

import java.io.Serializable;

// Reference: https://www.youtube.com/watch?v=aQAIMY-HzL8

public class DatabaseHelper extends SQLiteOpenHelper
{
    private static DatabaseHelper instance = null;
    private Context context;

    private static final String TABLE_NAME = "activities_table";
    private static final String COL_1 = "id";
    private static final String COL_2 = "name";
    private static final String COL_3 = "date";
    private static final String COL_4 = "time";
    private static final String COL_5 = "location";
    private static final String COL_6 = "campus";
    private static final String COL_7 = "details";

    private DatabaseHelper(Context context)
    {
        super(context, TABLE_NAME, null, 1);
        this.context = context;
    }

    public static DatabaseHelper getInstance(Context context)
    {
        if (instance == null)
        {
            instance = new DatabaseHelper(context.getApplicationContext());
        }
        return instance;
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {
        String createQuery = "CREATE TABLE " + TABLE_NAME + "(" + COL_1 + " INTEGER PRIMARY KEY AUTOINCREMENT, " + COL_2 + " TEXT, " + COL_3 + " TEXT, " + COL_4 + " TEXT, " + COL_5 + " TEXT, " + COL_6 + " TEXT, " + COL_7 + " TEXT)";
        db.execSQL(createQuery);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int i, int i1)
    {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME);
        onCreate(db);
    }

    public boolean addActivity(String name, String date, String time, String location, String campus, String details)
    {
        SQLiteDatabase db = this.getWritableDatabase();

        ContentValues contentValues = new ContentValues();
        contentValues.put(COL_2, name);
        contentValues.put(COL_3, date);
        contentValues.put(COL_4, time);
        contentValues.put(COL_5, location);
        contentValues.put(COL_6, campus);
        contentValues.put(COL_7, details);

        long result = db.insert(TABLE_NAME, null, contentValues);

        if (result == -1)
        {
            return false;
        }

        else
        {
            return true;
        }
    }

    public Cursor getActivities()
    {
        SQLiteDatabase db = this.getWritableDatabase();

        Cursor cursor = db.rawQuery("SELECT * FROM " + TABLE_NAME, null);
        return cursor;
    }

    public Cursor getActivity(String id)
    {
        SQLiteDatabase db = this.getWritableDatabase();

        Cursor cursor = db.rawQuery("SELECT * FROM " + TABLE_NAME + " WHERE id= " + id, null);

        return cursor;
    }

    public void deleteActivity(String id)
    {
        SQLiteDatabase db = this.getWritableDatabase();

        db.execSQL("DELETE FROM " + TABLE_NAME + " WHERE id = " + id);
    }

    public void updateActivity(String id, String name, String date, String time, String location, String campus, String details)
    {
        SQLiteDatabase db = this.getWritableDatabase();

        ContentValues contentValues = new ContentValues();
        contentValues.put(COL_2, name);
        contentValues.put(COL_3, date);
        contentValues.put(COL_4, time);
        contentValues.put(COL_5, location);
        contentValues.put(COL_6, campus);
        contentValues.put(COL_7, details);

        long result = db.update(TABLE_NAME, contentValues, "id="+ id, null);
    }

    // Adds dummy data for testing.
    public void addDummyData()
    {
        SQLiteDatabase db = this.getWritableDatabase();

        // Adds dummy data if db is empty.
        String countQuery = "SELECT count(*) FROM " + TABLE_NAME;
        Cursor cursor = db.rawQuery(countQuery, null);
        cursor.moveToFirst();
        int count = cursor.getInt(0);
        if(count == 0)
        {
            addActivity("Rugby Match", "07/01/18", "15:00", "Rugby Pitch", "Moylish", "LIT VS UCC.");
            addActivity("Soccer Training", "07/01/18", "12:00", "Soccer Pitch", "Thurles", "Practice for next weeks match.");
            addActivity("Hurling Match", "08/01/18", "16:00", "GAA Pitch", "Clonmel", "LIT VS CIT.");
            addActivity("Camogie Match", "09/01/18", "15:00", "GAA Pitch", "Moylish", "LIT VS UL.");
            addActivity("Team Meeting", "09/01/18", "15:00", "Lecture Rooms", "Moylish", "Everyone needs to attend.");
            addActivity("Basketball Match", "10/01/18", "12:30", "Rugby Pitch", "Clonmel", "Friendly vs UCD");
            addActivity("5 Aside Soccer Match", "11/01/18", "15:30", "Soccer Pitch", "Moylish", "Friendly");
        }
    }

    public void reset()
    {
        SQLiteDatabase db = this.getWritableDatabase();

        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME);
        onCreate(db);
    }
}
