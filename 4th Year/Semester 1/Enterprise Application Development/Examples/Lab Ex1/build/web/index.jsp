<%@page import="business.User"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <style>
            .resizedTextBox{
                width: 365px;
            }
        </style>
    </head>
    <body>
        <h1>Please Send Us Your Details.</h1>
        <form method="POST" action="HandleForm.jsp">
            <table>
                <tr>
                    <td>Name</td> <td><input class="resizedTextBox" type="text" name="name" value="${sessionScope.user.name}"></td>
                </tr>
                <tr>
                    <td>Address</td> <td><input class="resizedTextBox" type="text" name="address" value="${user.address}"></td>
                </tr>
                <tr>
                    <td>City</td> <td><input type="text" name="city" value="${user.city}"></td>
                </tr>
                <tr>
                    <td>Country</td> <td><input type="text" name="country" value="${user.country}"></td>
                </tr>
                <tr>
                    <td>Phone</td> <td><input type="text" name="phone" value="${user.phone}"></td>
                </tr>
                <tr>
                    <td>Email</td> <td><input type="text" name="email" value="${user.email}"></td>
                </tr>
                <tr>
                    <td>Gender</td>
                    <td>
                        Male<input type="radio" name="gender" value="male">
                        Female<input type="radio" name="gender" value="female">
                    </td>
                </tr>  
                <tr>
                    <td>How Did You Hear About Us?</td>
                    <td>
                        Twitter <input type="checkbox" name="hear" value="twitter">
                        Facebook <input type="checkbox" name="hear" value="facebook">
                        Newspaper <input type="checkbox" name="hear" value="newspaper">
                        Radio <input type="checkbox" name="hear" value="radio">
                        Other <input type="checkbox" name="hear" value="twitter">
                    </td>                
                </tr>
                <tr>
                    <td>Comments</td><td><textarea name="comments" rows="5" cols="50">${user.comments}</textarea></td>
                </tr>
                <tr>
                    <td><button type="submit" value="Submit">Submit</button></td>
                    <td><input type="reset" value="Clear"></td>
                </tr>
            </table>                  
        </form>
    </body>
</html>
