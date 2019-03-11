<%@ taglib prefix="shiro" uri="http://shiro.apache.org/tags" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page import="org.apache.shiro.SecurityUtils"%>
   
<% SecurityUtils.getSubject().logout(); %>

<c:redirect url="/login.jsp"/>

