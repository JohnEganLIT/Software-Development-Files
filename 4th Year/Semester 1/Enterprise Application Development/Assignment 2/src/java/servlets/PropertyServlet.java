package servlets;

import db.Property;
import db.PropertyDB;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@WebServlet(name = "PropertyServlet", urlPatterns = {"/PropertyServlet"})
public class PropertyServlet extends HttpServlet
{
    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException 
    {      
        String requestType = "";
        
        // Gets request type. 
        if(request.getAttribute("requestType") != null)
            requestType = (String) request.getAttribute("requestType");
        

        else if(request.getParameter("requestType") != null)
            requestType = (String) request.getParameter("requestType");
                 
        
        switch (requestType) 
        {
            case "property":
            {   
                int id = Integer.parseInt(request.getParameter("id"));
                Property property = PropertyDB.getPropertyById(id);
                request.setAttribute("property", property);
                
                int imageCount; 
                int pics = 1; 
                
                if(property.getPhoto().equals("0"))
                {
                    imageCount = 0;
                    pics = 0;
                }         
                else 
                {
                    // Gets number of images in folder.
                    String path = this.getServletContext().getRealPath("/images/properties/large/" + property.getPhoto());    
                    File directory = new File(path);
                    imageCount = directory.list().length;
                }
       
                request.setAttribute("pics", pics);
                request.setAttribute("imageCount", imageCount);
                
                RequestDispatcher rd = request.getRequestDispatcher("property.jsp");               
                rd.forward(request, response);
                break;
            }
            
            case "allProperties":
            {
                List<Property> properties = PropertyDB.getAllProperties();
                request.setAttribute("properties", properties);
                RequestDispatcher rd = request.getRequestDispatcher("home.jsp");
                rd.forward(request, response);    
                break;
            }
            
            case "archivedProperties":
            {
                List<Property> properties = PropertyDB.getAllArchivedProperties();
                request.setAttribute("properties", properties);
                RequestDispatcher rd = request.getRequestDispatcher("archivedProperties.jsp");
                rd.forward(request, response);    
                break;
            }
            
            case "add":
            {                                               
                Property property = new Property();
                property.setStreet(request.getParameter("street"));
                property.setCity(request.getParameter("city"));
                property.setListingNum(Integer.parseInt(request.getParameter("listingNum")));
                property.setStyleId(Integer.parseInt(request.getParameter("style")));
                property.setTypeId(Integer.parseInt(request.getParameter("type")));
                property.setBedrooms(Integer.parseInt(request.getParameter("bedrooms")));
                property.setBathrooms(Float.parseFloat(request.getParameter("bathrooms")));
                property.setSquareFeet(Integer.parseInt(request.getParameter("squareFeet")));
                property.setBerRating(request.getParameter("berRating"));
                property.setDescription(request.getParameter("description"));
                property.setLotSize(request.getParameter("lotSize"));
                property.setGarageSize(Integer.parseInt(request.getParameter("garageSize")));
                property.setGarageId(Integer.parseInt(request.getParameter("garage")));
                property.setAgent(request.getParameter("agent"));
                property.setPrice(Float.valueOf(request.getParameter("price")));
                property.setPhoto("0");
                property.setDateAdded("2018-11-27");
                
                PropertyDB.addProperty(property);
                
                RequestDispatcher rd = request.getRequestDispatcher("index.jsp");
                rd.forward(request, response);   
                break;
            }
            
            case "archive":
            {
                int id = Integer.parseInt(request.getParameter("id"));
                Property property = PropertyDB.getPropertyById(id);
                              
                PropertyDB.archiveProperty(property);
                
                RequestDispatcher rd = request.getRequestDispatcher("index.jsp");
                rd.forward(request, response);
                break;
            }
            
            case "unarchive":
            {
                int id = Integer.parseInt(request.getParameter("id"));
                Property property = PropertyDB.getPropertyById(id);
                              
                PropertyDB.unarchiveProperty(property);
                
                RequestDispatcher rd = request.getRequestDispatcher("/PropertyServlet");
                request.setAttribute("requestType", "archivedProperties");
                rd.forward(request, response);
                break;
            }
            
            case "edit":
            {
                int id = Integer.parseInt(request.getParameter("id"));
                Property property = PropertyDB.getPropertyById(id);
                
                request.setAttribute("property", property);
                RequestDispatcher rd = request.getRequestDispatcher("edit.jsp");
                rd.forward(request, response);  
                break;   
            }
            
            case "search":
            {                
                float minPrice = Float.valueOf(request.getParameter("minPrice"));  
                float maxPrice = Float.valueOf(request.getParameter("maxPrice"));
                String city = request.getParameter("city");
                            
                List<Property> properties = PropertyDB.searchProperty(minPrice, maxPrice, city);
                request.setAttribute("properties", properties);
                RequestDispatcher rd = request.getRequestDispatcher("home.jsp");
                rd.forward(request, response);  
                break;
            }
            
            case "delete":
            {
                int id = Integer.parseInt(request.getParameter("id"));
                Property property = PropertyDB.getPropertyById(id);
                              
                PropertyDB.removeProperty(property);
                
                RequestDispatcher rd = request.getRequestDispatcher("archivedProperties.jsp");
                rd.forward(request, response);
                break;
            }
            
            case "agentProperties":
            {
                List<Property> properties = PropertyDB.getAgentProperties((String)request.getParameter("username"));
                request.setAttribute("properties", properties);
                RequestDispatcher rd = request.getRequestDispatcher("myProperties.jsp");
                rd.forward(request, response);    
                break;
            }
            
            case "update":
            {
                Property property = PropertyDB.getPropertyById(Integer.parseInt(request.getParameter("id")));
   
                property.setStreet(request.getParameter("street"));
                property.setCity(request.getParameter("city"));
                property.setListingNum(Integer.parseInt(request.getParameter("listingNum")));
                property.setStyleId(Integer.parseInt(request.getParameter("style")));
                property.setTypeId(Integer.parseInt(request.getParameter("type")));
                property.setBedrooms(Integer.parseInt(request.getParameter("bedrooms")));
                property.setBathrooms(Float.parseFloat(request.getParameter("bathrooms")));
                property.setSquareFeet(Integer.parseInt(request.getParameter("squareFeet")));
                property.setBerRating(request.getParameter("berRating"));
                property.setDescription(request.getParameter("description"));
                property.setLotSize(request.getParameter("lotSize"));
                property.setGarageSize(Integer.parseInt(request.getParameter("garageSize")));
                property.setGarageId(Integer.parseInt(request.getParameter("garage")));
                property.setAgent(request.getParameter("agent"));
                property.setPrice(Float.valueOf(request.getParameter("price")));
                property.setDateAdded("2018-12-04");
                
                PropertyDB.updateProperty(property);
                
                RequestDispatcher rd = request.getRequestDispatcher("index.jsp");
                rd.forward(request, response); 
                break;
            }
            case "":
            {
                System.out.print("Empty Request");
                break;
            }
        }
    }
        
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException 
    {
        processRequest(request, response);
    }
    
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException 
    {
        processRequest(request, response);
    }
}
