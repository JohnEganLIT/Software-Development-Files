<%@ include file="includes/header.jsp" %>

<form name="searchForm" class="center" id="propertyForm" action="${pageContext.request.contextPath}/PropertyServlet" method="post">
    <table cellspacing="1" cellpadding="1">
        <tr>
            <td><label for="minPrice">Minimum Price</label></td>
            <td><input class="propertyField" id="minPrice" type="text" name="minPrice" required="required"/></td>
            <shiro:user><td><a style="margin-left:50px;" href="newProperty.jsp">Add New Property</a></td></shiro:user>
        </tr>
        <tr>
            <td><label for="maxPrice">Maximum Price</label></td>
            <td><input class="propertyField" id="price" type="text" name="maxPrice" required="required"/></td>
            <shiro:user><td><a style="margin-left:50px;" href="<%=request.getContextPath()%>/PropertyServlet?requestType=agentProperties&username=${sessionScope.username}">View My Properties</a></td></shiro:user>
        </tr>
        <tr>
            <td><label for="city">City</label></td>
            <td><input class="propertyField" id="city" type="text" name="city" required="required"/></td>
            <shiro:user><td><a style="margin-left:50px;" href="<%=request.getContextPath()%>/PropertyServlet?requestType=archivedProperties">View Archived Properties</a></td></shiro:user>
        </tr>
        <tr>
            <td></td>
        </tr>
        <input type="hidden" name="requestType" value="search"/>
        <tr>
            <td colspan="2">
                <input type="submit" id="submitBtn" value="Filter"/>
            </td>
        </tr> 
    </table>
</form>
    <br><br><br>
    
<div class="center">
    <shiro:user>
        <table id="userProperties" class="display" style="width:100%;">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Street</th>
                    <th>City</th>
                    <th>Bedrooms</th>
                    <th>Bathrooms</th>
                    <th>Square Feet</th>
                    <th>BER</th>
                    <th>Lot Size</th>
                    <th>Price</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <c:forEach items="${properties}" var="property">
                    <c:if test="${property.archived == 0}">
                        <tr>
                        <td>${property.id}</td>
                        <td>${property.street}</td>
                        <td>${property.city}</td>
                        <td>${property.bedrooms}</td>
                        <td>${property.bathrooms}</td>
                        <td>${property.squareFeet}</td>
                        <td><img id="berPic" src="images/BER/${property.berRating}.png"></td>
                        <td>${property.lotSize}</td>
                        <td>&euro;${property.price}</td>
                        <td><a href="<%=request.getContextPath()%>/PropertyServlet?id=${property.id}&requestType=edit">Edit</a></td>
                        <td><a href="<%=request.getContextPath()%>/PropertyServlet?id=${property.id}&requestType=archive" onclick='confirmUser()' title="Archive">-></a></td>
                        <td><a href="<%=request.getContextPath()%>/PropertyServlet?id=${property.id}&requestType=property"><img src="images/properties/thumbs/${property.photo}.jpg" height="50" width="75"></a></td>
                    </tr>
                    </c:if>
                </c:forEach>
            </tbody>
        </table>
    </shiro:user>    
    <shiro:guest>
        <table id="guestProperties" class="display" style="width:100%;">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Street</th>
                    <th>City</th>
                    <th>Bedrooms</th>
                    <th>Bathrooms</th>
                    <th>Square Feet</th>
                    <th>BER</th>
                    <th>Lot Size</th>
                    <th>Price</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <c:forEach items="${properties}" var="property">
                    <c:if test="${property.archived == 0}">
                        <tr>
                        <td>${property.id}</td>
                        <td>${property.street}</td>
                        <td>${property.city}</td>
                        <td>${property.bedrooms}</td>
                        <td>${property.bathrooms}</td>
                        <td>${property.squareFeet}</td>
                        <td><img id="berPic" src="images/BER/${property.berRating}.png"></td>
                        <td>${property.lotSize}</td>
                        <td>&euro;${property.price}</td>
                        <td><a href="<%=request.getContextPath()%>/PropertyServlet?id=${property.id}&requestType=property"><img src="images/properties/thumbs/${property.photo}.jpg" height="50" width="75"></a></td>
                    </tr>
                    </c:if>
                </c:forEach>
            </tbody>
        </table>
    </shiro:guest>  
</div>
                
<%@ include file="includes/footer.jsp" %>