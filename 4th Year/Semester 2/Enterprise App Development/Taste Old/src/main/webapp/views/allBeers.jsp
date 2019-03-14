<%@ taglib uri = "http://java.sun.com/jsp/jstl/core" prefix = "c" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>All Beers</title>
    </head>
    <body>
        <table style="width:100%">
            <tr>
             <th align="left">ID</th>
             <th align="left">Name</th>
             <th align="left">Description</th>
             <th align="left">image</th>
            </tr>
            <c:forEach items="${agentList}" var="agent"> 
                <tr>
                    <td>${beer.Id}</td>
                    <td>${beer.name}</td>
                    <td>${beer.description}</td>
                    <td>${beer.image}</td>
            </c:forEach>
        </table>
    </body>
</html>