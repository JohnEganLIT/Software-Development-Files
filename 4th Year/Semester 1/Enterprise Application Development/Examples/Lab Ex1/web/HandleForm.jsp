<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ page import="business.User, data.UserIO" %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>Thank you for submitting your details.</h1>
        <p>Click <a href="viewAgain.jsp">here</a> to view your details again</p>   
        
         <%
        String name = request.getParameter("name");
        String address = request.getParameter("address");
        String city = request.getParameter("city");
        String country = request.getParameter("country");
        String phone = request.getParameter("phone");
        String email = request.getParameter("email");
        String gender = request.getParameter("gender");
        String[] hear = request.getParameterValues("hear");
        String comments = request.getParameter("comments"); 
        
        ServletContext sc = request.getSession().getServletContext();
        
        String path = sc.getRealPath("user.txt");
        
        User user = new User(name, address, city, country, phone, email, gender, hear, comments);
        
        UserIO.add(user, path);
        
        for(String value : hear)
        {
            out.println(value);
        }
        
        out.println(comments);
        %>

    </body>
    
</html>

