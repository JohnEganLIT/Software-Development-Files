<%@ include file="includes/header.jsp" %>

    <%      
        RequestDispatcher rd = request.getRequestDispatcher("/PropertyServlet");
        request.setAttribute("requestType", "allProperties");
        rd.forward(request, response);
    %>    

<%@ include file="includes/footer.jsp" %>















