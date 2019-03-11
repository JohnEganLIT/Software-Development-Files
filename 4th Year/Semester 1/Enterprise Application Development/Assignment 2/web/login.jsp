<%@ include file="includes/header.jsp" %>

<shiro:guest>
<form name="loginForm" class="center" id="loginForm" method="post">
    <c:if test="${shiroLoginFailure != null}">
        Username or password incorrect
    </c:if>
    <table cellspacing="1" cellpadding="2">
        <tr>
            <td><input class="loginField" type="text" name="username" placeholder="Username"/><td>
        </tr>
        <tr>
            <td><input class="loginField" type="password" name="password" placeholder="********"/></td>
        </tr>
        <tr>
            <td>
                <label id="rememberMeLabel" for="rememberMe">Remember Me:</label>
                <input type="checkbox" id="rememberMe" name="rememberMe" value="true" />
            </td>
        </tr>
        <tr>
            <td colspan="1">
                <input type="submit" id="loginBtn" value="Login"/>
            </td>
        </tr> 
    </table>
</form>
</shiro:guest>

<shiro:user>
    <c:redirect url="/index.jsp"/>
</shiro:user>

<%@ include file="includes/footer.jsp" %>

