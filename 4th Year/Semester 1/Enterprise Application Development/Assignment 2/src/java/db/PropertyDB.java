package db;

import java.util.List;
import java.util.Properties;
import javax.persistence.EntityManager;
import javax.servlet.http.HttpServletRequest;

public class PropertyDB 
{
    public static Property getPropertyById(int id)
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        return em.find(Property.class, id);
    }
    
    public static List<Property> getAllProperties()
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        return em.createNamedQuery("Property.findAll", Property.class).getResultList();
    }
    
    public static List<Property> getAgentProperties(String username)
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        return em.createNamedQuery("Property.findAgentProperties", Property.class)
        .setParameter("username", username).getResultList(); 
    }
    
    public static List<Property> getAllArchivedProperties()
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        return em.createNamedQuery("Property.findAllArchived", Property.class).getResultList();
    }   
    
    public static void removeProperty(Property property)
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        if(!em.contains(property))
        {
            property = em.merge(property);
        }
        
        em.getTransaction().begin();
        em.remove(property);
        em.getTransaction().commit();
    }
    
    public static void addProperty(Property property)
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
       
        em.getTransaction().begin();
        em.persist(property);        
        em.getTransaction().commit();
    }
    
    public static void archiveProperty(Property property)
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        property.setArchived(1);
            
        em.getTransaction().begin();
        em.merge(property);
        em.getTransaction().commit();
    }
    
    public static void unarchiveProperty(Property property)
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        property.setArchived(0);
            
        em.getTransaction().begin();
        em.merge(property);
        em.getTransaction().commit();
    }
    
    public static List<Property> searchProperty(float minPrice, float maxPrice, String city)
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        return em.createNamedQuery("Property.searchByMinMaxCity", Property.class)
        .setParameter("minPrice", minPrice)
        .setParameter("maxPrice", maxPrice)
        .setParameter("city", city).getResultList();     
    }
    
    public static void updateProperty(Property property)
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
                
        em.getTransaction().begin();
        em.merge(property);
        em.getTransaction().commit();
    }
}
