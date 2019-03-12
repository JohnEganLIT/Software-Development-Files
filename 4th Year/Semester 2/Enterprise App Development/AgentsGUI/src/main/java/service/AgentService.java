package service;

import db.DBUtil;
import model.Agents;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import javax.persistence.EntityManager;

public class AgentService 
{
    List<Agents> agentList = new ArrayList();
    
    public List<Agents> getAllAgents() 
    {
        EntityManager em = DBUtil.getEmf().createEntityManager();
        
        return em.createNamedQuery("Agents.findAll", Agents.class).getResultList();
    }
    
    /*
    public Boolean authenticate(int id, String password)
    {
        Iterator<Agent> iterator = agentList.iterator();
        while (iterator.hasNext()) 
        {
            Agent agent = iterator.next();
            if (agent.getId() == id & agent.getPassword() == password) 
            {
                return true;
            }
        }
        
        return false;
    }
    
    public void addAnAgent(Agent a) 
    {
        agentList.add(a);
    }
    
    public void deleteAnAgent(int id) 
    {
        System.out.println("auto wired baby!");
        Iterator<Agent> iterator = agentList.iterator();
        while (iterator.hasNext()) 
        {
            Agent agent = iterator.next();
            if (agent.getId() == id) 
            {
                iterator.remove();
            }
        }
    }
*/
}
