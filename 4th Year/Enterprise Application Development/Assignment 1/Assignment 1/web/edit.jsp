<%@page contentType="text/html" pageEncoding="UTF-8" errorPage="error.html"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<html>
    <head><title>Edit a Route</title></head>

    <body>
        <h1>Edit  </h1> <br>
   
    <br>
    
    <form action="">
        <table width ="500" border="0">
            <tbody>
                 <tr>
                    <td>Code</td>
                    <td><input type="text" name="code" value="${airport.Code}" readonly /></td>
                </tr>
                <tr>
                <tr>
                    <td>City</td>
                    <td><input type="text" name="city" value="${airport.City}" /></td>
                </tr>
                <tr>
                    <td>Airport</td>
                    <td><input type="text" name="airport" value="${airport.Airport}" /></td>
                </tr>
                
                    <td>Q1 Passengers</td>
                    <td><input type="text" name="q1" value="${airport.Q1}" /></td>
                </tr>
                <tr>
                    <td>Q2 Passengers</td>
                    <td><input type="text" name="q2" value="${airport.Q2}" /></td>
                </tr>
                <tr>
                    <td>Q3 Passengers</td>
                    <td><input type="text" name="q3" value="${airport.Q3}" /></td>
                </tr>
                <tr>
                    <td>Q4 Passengers</td>
                    <td><input type="text" name="q4" value="${airport.Q4}" /></td>
                </tr>
                
            </tbody>
        </table>
                <input type="submit" value="Submit" />  <input type="submit" value="Go Back" />
    </form>
    </body>
</html>
