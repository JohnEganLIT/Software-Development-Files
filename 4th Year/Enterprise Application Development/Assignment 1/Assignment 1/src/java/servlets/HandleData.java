package servlets;

import entities.Airport;
import java.io.IOException;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import src.AirportsDB;

@WebServlet("/handle")
public class HandleData extends HttpServlet
{   
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException
    {
        List<Airport> allAirportsList = AirportsDB.getAllAirports();

        request.setAttribute("airports", allAirportsList);
    }    
}
