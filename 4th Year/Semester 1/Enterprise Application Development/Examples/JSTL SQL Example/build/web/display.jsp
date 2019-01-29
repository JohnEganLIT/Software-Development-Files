<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib prefix="sql" uri="http://java.sun.com/jsp/jstl/sql" %>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <sql:setDataSource var="db" driver="com.mysql.jdbc.Driver" url="jdbc:mysql://localhost:3306/mario" user="root" password=""/>
        
        <sql:query var="rs" dataSource="${db}">SELECT * FROM gadgets</sql:query>
        
        <c:forEach items="${rs.rows}" var="gadget">
            <c:out value="${gadget.id}" ></c:out> : <c:out value="${gadget.name}" ></c:out> : <c:out value="${gadget.price}" ></c:out> 
        </c:forEach>
    </body>
</html>
