package entities;

import com.sun.xml.rpc.processor.modeler.j2ee.xml.string;
import java.io.Serializable;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Airport implements Serializable
{    
    string code;
    string city;
    string airportName;
    int q1;
    int q2;
    int q3;
    int q4;

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    public string getCode() 
    {
            return code;
    }

    public void setCode(string code) {
        this.code = code;
    }

    public string getCity() {
        return city;
    }

    public void setCity(string city) {
        this.city = city;
    }

    public string getAirportName() {
        return airportName;
    }

    public void setAirportName(string airportName) {
        this.airportName = airportName;
    }

    public int getQ1() {
        return q1;
    }

    public void setQ1(int q1) {
        this.q1 = q1;
    }

    public int getQ2() {
        return q2;
    }

    public void setQ2(int q2) {
        this.q2 = q2;
    }

    public int getQ3() {
        return q3;
    }

    public void setQ3(int q3) {
        this.q3 = q3;
    }

    public int getQ4() {
        return q4;
    }

    public void setQ4(int q4) {
        this.q4 = q4;
    }
    
    
}
