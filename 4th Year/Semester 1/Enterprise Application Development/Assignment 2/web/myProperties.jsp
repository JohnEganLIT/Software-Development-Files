<%@ include file="includes/header.jsp" %>

<div class="center">
    <shiro:user>
        <h2 style="color:#6D6E71">My Properties</h2>
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
</div>
<shiro:guest>
    <c:redirect url="index.jsp"/>
</shiro:guest>
                
<%@ include file="includes/footer.jsp" %>