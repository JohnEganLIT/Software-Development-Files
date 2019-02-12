package src;

import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

@WebService(serviceName = "Calculator")
public class Calculator 
{
    @WebMethod(operationName = "add")
    public int add(@WebParam(name = "n1") int n1, @WebParam(name = "n2") int n2) 
    {
        return n1 + n2;
    }

    @WebMethod(operationName = "multiply")
    public int multiply(@WebParam(name = "n1") int n1, @WebParam(name = "n2") int n2) 
    {
        return n1 * n2;
    }
}
