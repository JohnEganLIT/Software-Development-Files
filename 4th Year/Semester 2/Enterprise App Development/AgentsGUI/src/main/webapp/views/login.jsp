<%-- 
    Document   : authentication
    Created on : 26-Feb-2019, 11:35:31
    Author     : Colin
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <form method="POST" action="/AgentsGUI/login">                  
            <table>
                <tr>
                    <td><label name="id">ID</label></td>
                    <td><input name="id"/></td>
                </tr>
                <tr>
                    <td><label name="password">Password</label></td>
                    <td><input name="password"/></td>
                </tr>
                <tr>
                    <td><input type="submit" value="Login"</td>
                </tr>
            </table>
        </form>
    </body>
</html>
