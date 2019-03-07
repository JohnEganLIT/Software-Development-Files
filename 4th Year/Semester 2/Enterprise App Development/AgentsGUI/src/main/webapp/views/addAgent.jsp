<%-- 
    Document   : addAgent
    Created on : 14-Feb-2019, 11:40:49
    Author     : K00208079
--%>

<%@ page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>


<!DOCTYPE html>
<html>
       
    <head>
    </head>
  
        <h3>Enter The Agent Details!</h3>
        
        <form method="POST" action="/AgentsGUI/addAgent">
                   
            <table>
                <tr>
                    <td><label name="id">ID</label></td>
                    <td><input name="id"/></td>
                </tr>
                <tr>
                    <td><label name="name">Name</label></td>
                    <td><input name="name"/></td>
                </tr>
                 <tr>
                    <td><label name="phone">Phone</label></td>
                    <td><input name="phone"/></td>
                </tr>
                <tr>
                    <td><label name="fax">Fax</label></td>
                    <td><input name="fax"/></td>
                </tr>
                <tr>
                    <td><label name="email">Email</label></td>
                    <td><input name="email"/></td>
                </tr>
                <tr>
                    <td><input type="submit" value="Submit!"</td>
                </tr>
            </table>
        </form>

</html>