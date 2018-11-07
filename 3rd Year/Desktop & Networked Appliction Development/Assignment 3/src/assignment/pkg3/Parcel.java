package assignment.pkg3;

public class Parcel 
{
    //Member data
    private String parcelID;
    private String arrivalTime;
    private String name;
    private String address;
    private String city;
    private String county;
    private String contactNumber;
    private String description;
    private double price;
    private boolean prePaid;

    //Constructor
    public Parcel( String parcelID, String arrivalTime ) 
    {
        //setParcel( "", "", "", "", "", "","", 0.0, false );
        this.parcelID = parcelID;
        this.arrivalTime = arrivalTime;
    }

    //Set the parcel properties
    void setParcel( String name, String address, String city, String county, String contactNumber, String arrivalTime, String description, double price, boolean prePaid )
    {
        this.setName(name);
        this.setAddress(address);
        this.setCity(city);
        this.setCounty(county);
        this.setContactNumber(contactNumber);
        this.setArrivalTime(arrivalTime);
        this.setPrice(price);
        this.setDescription(description);
        this.setPrePaid(prePaid);
    }

    public String getName() 
    {
        return name;
    }
    
    public void setName(String name) 
    {
        this.name = name;
    }
    
    public String getAddress() 
    {
        return address;
    }

    public void setAddress(String address) 
    {
        this.address = address;
    }

    public String getCity() 
    {
        return city;
    }
 
    public void setCity(String city) 
    {
        this.city = city;
    }

    public String getCounty()
    {
        return county;
    }

    public void setCounty(String county) 
    {
        this.county = county;
    }
    
    public String getArrivalTime() 
    {
        return arrivalTime;
    }
    
    public void setArrivalTime(String arrivalTime) 
    {
        this.arrivalTime = arrivalTime;
    }

    public String getContactNumber() 
    {
        return contactNumber;
    }

    public void setContactNumber(String contactNumber) 
    {
        this.contactNumber = contactNumber;
    }

    public String getParcelID() 
    {
        return parcelID;
    }

    public void setParcelID(String parcelID) 
    {
        this.parcelID = parcelID;
    }

    public double getPrice() 
    {
        return price;
    }
    
    public void setPrice(double price) 
    {
        this.price = price;
    }

    public boolean isPrePaid() 
    {
        return prePaid;
    }

    public void setPrePaid(boolean prePaid) 
    {
        this.prePaid = prePaid;
    }

    public String getDescription() 
    {
        return description;
    }

    public void setDescription(String description) 
    {
        this.description = description;
    }

    @Override
    public String toString() 
    {
        return "Packet ID " + this.getParcelID() +
               "\nPacket Arrived at " + this.getArrivalTime() +
               "\nCustomer Name " + this.getName() +
               "\nAddress " + this.getAddress() +
               "\nCity " + this.getCity() +
               "\nCounty " + this.getCounty() +
               "\nContact Number " + this.getContactNumber() +
               "\nProduct Description " + this.getDescription() +
               "\nPrice €" + this.getPrice() +
               "\nPrepaid " + this.isPrePaid();
    }
}