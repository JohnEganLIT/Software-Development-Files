package com.Colin;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class SqServlet extends HttpServlet
{
    // Cookies
    public void doGet(HttpServletRequest req, HttpServletResponse res) throws IOException
    {
        Cookie cookies[] = req.getCookies();
        int result = 0; 
        
        for(Cookie c : cookies)
        {
            if(c.getName().equals("result"))
            {
                result = Integer.parseInt(c.getValue());
            }
        }
        
        PrintWriter out = res.getWriter();
        out.println("Result is " + result);
    }
    
    // Sessions
    public void doGet2(HttpServletRequest req, HttpServletResponse res) throws IOException
    {
        HttpSession session = req.getSession();
     
        session.removeAttribute("result"); // Removes result from session.
        
        int result = (int) session.getAttribute("result");
        
        PrintWriter out = res.getWriter();
        out.println("Result is " + result);
    }
    
    public void doGet3(HttpServletRequest req, HttpServletResponse res) throws IOException
    {
        int result = Integer.parseInt(req.getParameter("result"));
        
        PrintWriter out = res.getWriter();
        out.println("Result is " + result);
    }
    
    public void doGet4(HttpServletRequest req, HttpServletResponse res) throws IOException
    {
        int result = (int)req.getAttribute("result");
        
        PrintWriter out = res.getWriter();
        out.println("result is " + result);
    }
}
