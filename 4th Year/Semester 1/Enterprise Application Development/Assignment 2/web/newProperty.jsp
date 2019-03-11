<%@ include file="includes/header.jsp" %>

<shiro:user>
    <form name="propertyForm" class="center" id="propertyForm" action="${pageContext.request.contextPath}/PropertyServlet" method="post">
    <table cellspacing="1" cellpadding="2">
        <tr>
            <td><label for="listinNum">Listing Num</label></td>
            <td><input class="propertyField" id="listingNum" type="text" name="listingNum" required="required"/></td>
        </tr>
        <tr>
            <td><label for="style">Style</label></td>
            <td>
                <select name="style" class="propertyField" id="style" type="text">
                    <option value="1">Bungalow</option>
                    <option value="2">Semi Detached</option>
                    <option value="3">Detached</option>
                    <option value="4">Cottage</option>
                    <option value="5">Terrace</option>
                    <option value="8">Duplex</option>
                    <option value="9">Condo</option>
                    <option value="10">Apartment</option>
                    <option value="11">Other</option>
                </select>
            </td>
        </tr>
        <tr>
            <td><label for="type">Type</label></td>
            <td>
                <select name="type" class="propertyField" id="type" type="text">
                    <option value="1">Residential-Single</option>
                    <option value="2">Residential-Multi</option>
                    <option value="3">Commercial</option>
                </select>
            </td>
        </tr>
        <tr>
            <td><label for="street">Street</label></td>
            <td><input class="propertyField" id="street" type="text" name="street" required="required"/></td>
        </tr>
        <tr>
            <td><label for="city">City</label></td>
            <td><input class="propertyField" id="city" type="text" name="city" required="required"/></td>
        </tr>
        <tr>
            <td><label for="bedrooms">Bedrooms</label></td>
            <td><input class="propertyField" id="bedrooms" type="text" name="bedrooms" required="required"/></td>
        </tr>
        <tr>
            <td><label for="bathrooms">Bathrooms</label></td>
            <td><input class="propertyField" id="bathrooms" type="text" name="bathrooms" required="required"/></td>
        </tr>
        <tr>
            <td><label for="squareFeet">Square Feet</label></td>
            <td><input class="propertyField" id="squareFeet" type="text" name="squareFeet" required="required"/></td>
        </tr>
        <tr>
            <td><label for="berRating">BER Rating</label></td>
            <td><input class="propertyField" id="berRating" type="text" name="berRating" required="required"/></td>
        </tr>
        <tr>
            <td><label for="lotSize">Lot Size</label></td>
            <td><input class="propertyField" id="lotSize" type="text" name="lotSize" required="required"/></td>
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
            <td><input class="propertyField" id="garageSize" type="text" name="garageSize" required="required"/></td>
        </tr>
        <tr>
            <td><label for="price">Price</label></td>
            <td><input class="propertyField" id="price" type="text" name="price" required="required"/></td>
        </tr>
        <tr>
            <td><label for="agent">Agent</label></td>
            <td>
                <select name="agent" class="propertyField" id="agent" type="text">
                    <option value="1">Sue Roberts</option>
                    <option value="2">Natasha Watkins</option>
                    <option value="3">Chris Clarkson</option>
                    <option value="4">Laura Blain</option>
                    <option value="5">Dave Lindale</option>
                </select>
            </td>
        </tr>
        <tr>
            <td><label for="photo">Photos</label></td>
            <td><input type="file" class="propertyField" name="photo" accept="image/*" multiple></td>
        </tr>
        <tr>
            <td><label for="description">Description</label></td>
            <td><textarea class="propertyField" id="description" type="text" name="description" required="required"/></textarea></td>
        </tr>
        <input type="hidden" name="requestType" value="add"/>
        <tr>
            <td></td>
            <td colspan="1">
                <input type="submit" id="submitBtn" value="Submit"/>
            </td>
        </tr> 
    </table>
</form>
</shiro:user>
    
<shiro:guest>
    <c:redirect url="index.jsp"/>
</shiro:guest>
<%@ include file="includes/footer.jsp" %>
