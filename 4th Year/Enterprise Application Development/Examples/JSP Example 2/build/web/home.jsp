<!-- Attributes -->
<%--  extends="className" import="importList" session="true/false" autoflush="true/false" 
isErrorPage="error_url" info="information" isELIIgnored="true/false" isThreadSafe="true/false" --%>
<%@page contentType="text/html" pageEncoding="UTF-8"%> 
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>Hello World!</h1>
        <%! 
            int num1 = 9;
            int num2 = 3;
        %>
                   
        <%
          out.println(num1 + num2);  
        %>
        
        My Favourite Number is: <%= num1 %>
        
    </body>
</html>
