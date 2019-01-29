<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <%--
        <%
          String name = request.getAttribute("label").toString();
          out.println(name);

        %>
        --%>
        <%-- ${label} <!-- Expression Language --> 
        
        <c:out value="${student.name}" /> 
        <c:out value="${student.rollno}" /> --%>
        
        <c:forEach items="${students}" var="s">
            ${s.name} ${s.rollno}</br>
        </c:forEach>
    </body>
</html>
