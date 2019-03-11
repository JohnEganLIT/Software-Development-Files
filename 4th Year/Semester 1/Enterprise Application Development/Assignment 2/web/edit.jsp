<%@ include file="includes/header.jsp" %>

<shiro:user>
    <form name="propertyForm" class="center" id="propertyForm" action="${pageContext.request.contextPath}/PropertyServlet" method="post">
    <table cellspacing="1" cellpadding="2">
        <tr>
            <td><label for="listinNum">Listing Num</label></td>
            <td><input class="propertyField" id="listingNum" type="text" name="listingNum" required="required" value="${property.listingNum}"/></td>
        </tr>
        <tr>
            <td><label for="style">Style</label></td>
            <td>
                <select name="style" class="propertyField" id="style" type="text">
                    <option value="1" <c:if test="${property.styleId == 1}"> selected="selected"</c:if> >Bungalow</option>
                    <option value="2" <c:if test="${property.styleId == 2}"> selected="selected"</c:if>  >Semi Detached</option>
                    <option value="3" <c:if test="${property.styleId == 3}"> selected="selected"</c:if>  >Detached</option>
                    <option value="4" <c:if test="${property.styleId == 4}"> selected="selected"</c:if>  >Cottage</option>
                    <option value="5" <c:if test="${property.styleId == 5}"> selected="selected"</c:if>  >Terrace</option>
                    <option value="8" <c:if test="${property.styleId == 8}"> selected="selected"</c:if>  >Duplex</option>
                    <option value="9" <c:if test="${property.styleId == 9}"> selected="selected"</c:if>  >Condo</option>
                    <option value="10" <c:if test="${property.styleId == 10}"> selected="selected"</c:if>  >Apartment</option>
                    <option value="11" <c:if test="${property.styleId == 11}"> selected="selected"</c:if>  >Other</option>
                </select>
            </td>
        </tr>
        <tr>
            <td><label for="type">Type</label></td>
            <td>
                <select name="type" class="propertyField" id="type" type="text">
                    <option value="1" <c:if test="${property.typeId == 1}"> selected="selected"</c:if>>Residential-Single</option>
                    <option value="2" <c:if test="${property.typeId == 2}"> selected="selected"</c:if>>Residential-Multi</option>
                    <option value="3" <c:if test="${property.typeId == 3}"> selected="selected"</c:if>>Commercial</option>
                </select>
            </td>
        </tr>
        <tr>
            <td><label for="street">Street</label></td>
            <td><input class="propertyField" id="street" type="text" name="street" required="required" value="${property.street}"/></td>
        </tr>
        <tr>
            <td><label for="city">City</label></td>
            <td><input class="propertyField" id="city" type="text" name="city" required="required" value="${property.city}"/></td>
        </tr>
        <tr>
            <td><label for="bedrooms">Bedrooms</label></td>
            <td><input class="propertyField" id="bedrooms" type="text" name="bedrooms" required="required" value="${property.bedrooms}"/></td>
        </tr>
        <tr>
            <td><label for="bathrooms">Bathrooms</label></td>
            <td><input class="propertyField" id="bathrooms" type="text" name="bathrooms" required="required" value="${property.bathrooms}"/></td>
        </tr>
        <tr>
            <td><label for="squareFeet">Square Feet</label></td>
            <td><input class="propertyField" id="squareFeet" type="text" name="squareFeet" required="required" value="${property.squareFeet}"/></td>
        </tr>
        <tr>
            <td><label for="berRating">BER Rating</label></td>
            <td><input class="propertyField" id="berRating" type="text" name="berRating" required="required" value="${property.berRating}"/></td>
        </tr>
        <tr>
            <td><label for="lotSize">Lot Size</label></td>
            <td><input class="propertyField" id="lotSize" type="text" name="lotSize" required="required" value="${property.lotSize}"/></td>
        </tr>
        <tr>
            <td><label for="garage">Garage</label></td>
            <td>
                <select class="propertyField" id="garage" type="text" name="garage">
                    <option value="1">Attached</option>
                    <option value="2">Detached</option>
                    <option value="3">Carport</option>
                </select>
            </td>
        </tr>
        <tr>
            <td><label for="garageSize">Garage Size</label></td>
            <td><input class="propertyField" id="garageSize" type="text" name="garageSize" required="required" value="${property.garageSize}"/></td>
        </tr>
        <tr>
            <td><label for="price">Price</label></td>
            <td><input class="propertyField" id="price" type="text" name="price" required="required" value="${property.price}"/></td>
        </tr>
        <tr>
            <td><label for="agent">Agent</label></td>
            <td>
                <select name="agent" class="propertyField" id="agent" type="text">
                    <option value="Sue.Roberts" <c:if test="${property.agent == 'Sue.Roberts'}"> selected="selected"</c:if> >Sue Roberts</option>
                    <option value="Natasha.Watkins" <c:if test="${property.agent == 'Natasha.Watkins'}"> selected="selected"</c:if> >Natasha Watkins</option>
                    <option value="Chris.Clarkson" <c:if test="${property.agent == 'Chris.Clarkson'}"> selected="selected"</c:if> >Chris Clarkson</option>
                    <option value="Laura.Blain" <c:if test="${property.agent == 'Laura.Blain'}"> selected="selected"</c:if> >Laura Blain</option>
                    <option value="Dave.Lindale" <c:if test="${property.agent == 'Dave.Lindale'}"> selected="selected"</c:if> >Dave Lindale</option>
                </select>
            </td>
        </tr>
        <tr>
            <td><label for="photo">Photos</label></td>
            <td><input type="file" class="propertyField" name="photo" accept="image/*" multiple></td>
        </tr>
        <tr>
            <td><label for="description">Description</label></td>
            <td><textarea class="propertyField" id="description" type="text" name="description" required="required"/>${property.description}</textarea></td>
        </tr>
        <input type="hidden" name="id" value="${property.id}"/>
        <input type="hidden" name="requestType" value="update"/>
        <tr>
            <td></td>
            <td colspan="1">
                <input type="submit" id="submitBtn" value="Update"/>
            </td>
        </tr> 
    </table>
</form>
</shiro:user>
    
<shiro:guest>
    <c:redirect url="index.jsp"/>
</shiro:guest>
<%@ include file="includes/footer.jsp" %>
