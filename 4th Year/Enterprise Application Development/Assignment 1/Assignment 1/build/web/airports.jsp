<%@page contentType="text/html" pageEncoding="UTF-8" errorPage="error.html"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<html>
    <head><title>All Routes</title></head>
    <body>
        <h1>Routes Found: ??? </h1>
        <br><br>
        <table width='1000' border='1'>
            <c:forEach items="${airports}" var="post">
            <tr>
                <th>City</th>
                <th>Airport</th>
                <th>Code</th>
                <th>Q1</th>
                <th>Q2</th>
                <th>Q3</th>
                <th>Q4</th>
                <th>Flag</th>
                <th>Actions</th>
            </tr>
            <tr> 
               <td>${airports.City}</td>
               <td>${airports.Airport}</td>
               <td>${airports.Code}</td>
               <td>${airports.Q1}</td>
               <td>${airports.Q2}</td>
               <td>${airports.Q3}</td>
               <td>${airports.Q4}</td>
               <td><img src='resources/flags/JFK.png' width="40" height="40"></img></td>
               <td><a href="">Edit</a> </td>  
             </tr>
            </c:forEach>
        </table>
    </body>
</html>
