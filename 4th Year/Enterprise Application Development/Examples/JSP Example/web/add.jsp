<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.util.Date" %> <!-- Directive tag -->

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body bgcolor="cyan">
        <%! // Declaration tag. Gets put into servlet class.
            int num = 1;
        %>
        
        <% // Scriplet tag. Gets converted to Servlet function.
            int num1 = Integer.parseInt(request.getParameter("num1"));
            int num2 = Integer.parseInt(request.getParameter("num2"));

            int result = num1 + num2;

            out.println("Output: " + result);
        %>
        
        <%= result %> <!-- Expression Tag. It will out.print(result) --> 
    </body>
</html>
