/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sd4.agentsgui;

import javax.ws.rs.FormParam;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.ModelAndView;

/**
 *
 * @author K00208079
 */
@Controller
public class AuthorController {
    
    AgentService service = new AgentService();
    
    @GetMapping("/agents")
    public ModelAndView getAllAgents(){
        return new ModelAndView("/allAgents", "agentList", service.getAllAgents());
    }
    
    @GetMapping("/add")
    public ModelAndView displayAgentAddForm() {
        return new ModelAndView("/addAgent", "agent", "");
    }
    
    
     //@RequestMapping(value = "/addAgent", method = RequestMethod.POST)
    @PostMapping("/addAgent")
    public ModelAndView addAnAgent(@FormParam("id") int id,
                                      @FormParam("name") String name,   
                                      @FormParam("phone") String phone,  
                                      @FormParam("fax") String fax,  
                                      @FormParam("email") String email,
                                      @FormParam("password") String password){
        Agent agent = new Agent(id, name, fax, phone, email, password);
        service.addAnAgent(agent);
        
           //create the agent object
           //add the object to the list
           //route the user to the next page
        return new ModelAndView("/displayAgent", "agent", agent);
   }
    
    @PostMapping("/login")
    public ModelAndView loginAgent(@FormParam("id") int id, @FormParam("password") String password) 
    {        
        if(service.authenticate(id, password))
        {
            return new ModelAndView("/allAgents");
        }
        
        else
        {
            return new ModelAndView("/loginFailed");
        }
   }
    
    //@RequestMapping(value = "/delete", method = RequestMethod.GET)
  
}
