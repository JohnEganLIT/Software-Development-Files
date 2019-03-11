<%-- 
    Document   : allAgents
    Created on : 14-Feb-2019, 11:40:14
    Author     : K00208079
--%>

<%@ taglib uri = "http://java.sun.com/jsp/jstl/core" prefix = "c" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>All Agents</title>
    </head>
    <body>
        <table style="width:100%">
            <tr>
             <th align="left">ID</th>
             <th align="left">Name</th>
             <th align="left">Fax</th>
             <th align="left">Phone</th>
             <th align="left">Email</th>
             <th align="left">Actions</th>
            </tr>
            <c:forEach items="${agentList}" var="agent"> 
                <tr>
                    <td>${agent.agentId}</td>
                    <td>${agent.name}</td>
                    <td>${agent.fax}</td>
                    <td>${agent.phone}</td>
                    <td>${agent.email}</td>
                    <td>
                        <a href="">Delete</a>
                        <a href="">Edit</a>
                        <a href="">Insert</a>
                    </td>
                   
                </tr>
            </c:forEach>
        </table>
    </body>
</html>