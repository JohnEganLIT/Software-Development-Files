/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sd4.agentsgui;

/**
 *
 * @author K00208079
 */
 public class Agent {
    
    private int id;
    private String name;
    private String fax;
    private String phone;
    private String email;
    private String password;

    public Agent(int id, String name, String fax, String phone, String email, String password) {
        this.id = id;
        this.name = name;
        this.fax = fax;
        this.phone = phone;
        this.email = email;
        this.password = password;
    }


	//generate getters/setters and constructors
	//possibly override toString()

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getFax() {
        return fax;
    }

    public void setFax(String fax) {
        this.fax = fax;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
	
    public String getPassword()
    {
        return password;
    }
    
    public void setPassword(String password)
    {
        this.password = password;
    }
}