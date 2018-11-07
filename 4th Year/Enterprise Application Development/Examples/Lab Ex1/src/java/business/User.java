package business;

public class User 
{
    private String name;
    private String address;
    private String city;
    private String country;
    private String phone;
    private String email;
    private String gender;
    private String[] hear; // How did you hear about us? 
    private String comments;
   
    public User()
    {
        
    }
    
    public User(String name, String address, String city, String country, 
        String phone, String email, String gender, String[] hear, String comments)
    {
        this.name = name;
        this.address = address;
        this.city = city;
        this.country = country;
        this.phone = phone;
        this.email = email;
        this.gender = gender;
        this.hear = hear;
        this.comments = comments;            
    }
    
    public void setName(String name) {
        this.name = name;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    public void setHear(String[] hear) {
        this.hear = hear;
    }

    public void setComments(String comments) {
        this.comments = comments;
    }

    public String getName() {
        return name;
    }

    public String getAddress() {
        return address;
    }

    public String getCity() {
        return city;
    }

    public String getCountry() {
        return country;
    }

    public String getPhone() {
        return phone;
    }

    public String getEmail() {
        return email;
    }

    public String getGender() {
        return gender;
    }

    public String[] getHear() {
        return hear;
    }

    public String getComments() {
        return comments;
    }   
}
