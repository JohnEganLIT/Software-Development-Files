package service;

import db.DBUtil;
import java.util.List;
import javax.persistence.EntityManager;
import model.Beer;

public class BeerService 
{
    public List<Beer> getAllBeers() 
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        return em.createNamedQuery("Beer.findAll", Beer.class).getResultList();
    }
}
