package db;

import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class DBUtil 
{
    private static final EntityManagerFactory emf = Persistence.createEntityManagerFactory("tastePU");
    
    // @return the emf
    public static EntityManagerFactory getEmf() 
    {
        return emf;
    }
}
