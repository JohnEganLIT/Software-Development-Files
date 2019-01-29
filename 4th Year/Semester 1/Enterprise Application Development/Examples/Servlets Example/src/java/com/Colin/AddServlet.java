package com.Colin;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class AddServlet extends HttpServlet
{   
    // Cookies
    public void doGet(HttpServletRequest req, HttpServletResponse res) throws IOException, ServletException
    {
        int num1 = Integer.parseInt(req.getParameter("num1"));
        int num2 = Integer.parseInt(req.getParameter("num2"));
        
        int result = num1 + num2;
        
        Cookie cookie = new Cookie("result", Integer.toString(result));
        res.addCookie(cookie);
        
        res.sendRedirect("sq");
    }
    
    // Sessions
    public void doGet2(HttpServletRequest req, HttpServletResponse res) throws IOException, ServletException
    {
        int num1 = Integer.parseInt(req.getParameter("num1"));
        int num2 = Integer.parseInt(req.getParameter("num2"));
        
        int result = num1 + num2;
                
        HttpSession session = req.getSession();
        session.setAttribute("result", result);
        
        res.sendRedirect("sq");
    }
    
    public void doGet3(HttpServletRequest req, HttpServletResponse res) throws IOException, ServletException
    {
        int num1 = Integer.parseInt(req.getParameter("num1"));
        int num2 = Integer.parseInt(req.getParameter("num2"));
        
        int result = num1 + num2;
                
        res.sendRedirect("sq?result="+result); // Url rewriting        
    }
    
    public void doGet4(HttpServletRequest req, HttpServletResponse res) throws IOException, ServletException
    {
        int num1 = Integer.parseInt(req.getParameter("num1"));
        int num2 = Integer.parseInt(req.getParameter("num2"));
        
        int result = num1 + num2;
        
        PrintWriter out = res.getWriter();
        out.println(num1 + " + " + num2 + " = " + result);
        
        req.setAttribute("result", result);

        RequestDispatcher rd = req.getRequestDispatcher("sq");
        rd.forward(req, res);        
    }
    
    public void doPost(HttpServletRequest req, HttpServletResponse res) throws IOException
    {
        int num1 = Integer.parseInt(req.getParameter("num1"));
        int num2 = Integer.parseInt(req.getParameter("num2"));
        
        int result = num1 + num2;
        
        PrintWriter out = res.getWriter();
        out.println(num1 + " + " + num2 + " = " + result);
    }
}
