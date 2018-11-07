package com.colin;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletConfig;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class MyServlet extends HttpServlet // ServletConfig & Servlet Context
{
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        PrintWriter out = response.getWriter();
        
        ServletConfig cg = getServletConfig();
        String name = cg.getInitParameter("name");
        
        out.print("Hi " + name);
    }
        
    protected void doGet2(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        PrintWriter out = response.getWriter();
        
        ServletContext ctx = getServletContext();
        String name = ctx.getInitParameter("name");
        out.println("Your name is " + name + "</br>");
        
        String phone = ctx.getInitParameter("phone");
        out.print("Your phone is a " + phone + "</br>");      
    }
}
