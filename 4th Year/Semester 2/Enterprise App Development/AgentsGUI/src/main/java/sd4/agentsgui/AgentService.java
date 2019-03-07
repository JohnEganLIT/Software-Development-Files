/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sd4.agentsgui;

/**
 *
 * @author K00208079
 */
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class AgentService {

    static List<Agent> agentList = new ArrayList();
    
    static {
        agentList.add(new Agent(1, "Sue Robert", "999-555-111", "78-45-56-51", "Sue.Roberts@litrealty.com", "password1"));
        agentList.add(new Agent(2, "Natasha Watkins", "999-555-112", "78-45-56-52", "Natasha.Watkins@litrealty.com", "password2"));
        agentList.add(new Agent(3, "Chris Clarkson", "999-555-113", "78-45-56-53", "Chris.Clarkson@litrealty.com", "password3"));
        agentList.add(new Agent(4, "Laura Blain", "999-555-114", "78-45-56-54", "Laura.Blain@litrealty.com", "password4"));
        agentList.add(new Agent(5, "Dave Lindale", "999-555-115", "78-45-56-55", "Dave.Lindale@litrealty.com", "password5"));   
    }
    
    public List<Agent> getAllAgents() {
       return agentList;
    }//end getAllAgents
    
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
    
    public void addAnAgent(Agent a) {
        agentList.add(a);
    }//end addAnAgent
    
    public void deleteAnAgent(int id) {
        System.out.println("auto wired baby!");
        Iterator<Agent> iterator = agentList.iterator();
        while (iterator.hasNext()) {
            Agent agent = iterator.next();
            if (agent.getId() == id) {
                iterator.remove();
            }
        }
    }//end deleteAnAgent
    
}//end AgentService
