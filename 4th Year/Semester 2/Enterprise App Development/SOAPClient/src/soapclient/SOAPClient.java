package soapclient;

import src.Calculator;
import src.Calculator_Service;

public class SOAPClient 
{
    public static void main(String[] args) 
    {
        Calculator_Service service = new Calculator_Service(); 
        
        Calculator proxy = service.getCalculatorPort(); 
        
        System.out.println(proxy.add(4, 5));
        System.out.println(proxy.multiply(4, 5));
    }
}
