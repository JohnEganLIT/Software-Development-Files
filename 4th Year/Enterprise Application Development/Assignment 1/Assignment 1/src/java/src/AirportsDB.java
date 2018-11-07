package src;

import entities.Airport;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.TypedQuery;

public class AirportsDB 
{        
    public static List<Airport> getAllAirports()
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        String q = "SELECT * FROM airports";
        
        TypedQuery<Airport> tq = em.createQuery(q, Airport.class);
          
        List<Airport> list;
        
        try
        {
            list = tq.getResultList();
            
            if(list == null || list.isEmpty())
            {
                list = null;
            }
        }
        finally
        {
            em.close();
        }
        return list;
    }
}
