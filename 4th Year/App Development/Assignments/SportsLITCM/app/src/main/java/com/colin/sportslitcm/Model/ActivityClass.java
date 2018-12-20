package com.colin.sportslitcm.Model;

public class ActivityClass
{
    private String id;
    private String name;
    private String date;
    private String time;
    private String location;
    private String campus;
    private String details;

    public ActivityClass(String id, String name, String date, String time, String location, String campus, String details)
    {
        this.id = id;
        this.name = name;
        this.date = date;
        this.time = time;
        this.location = location;
        this.campus = campus;
        this.details = details;
    }

    public String getId()
    {
        return id;
    }

    public String getName()
    {
        return name;
    }

    public String getDate()
    {
        return date;
    }

    public String getTime()
    {
        return time;
    }

    public String getLocation()
    {
        return location;
    }

    public String getCampus()
    {
        return campus;
    }

    public String getDetails()
    {
        return details;
    }
}
