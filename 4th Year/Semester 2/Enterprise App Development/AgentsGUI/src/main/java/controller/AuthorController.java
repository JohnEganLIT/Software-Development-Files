package controller;

import service.AgentService;
import model.Agents;
import javax.ws.rs.FormParam;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

@Controller
public class AuthorController 
{ 
    AgentService service = new AgentService();
    
    @RequestMapping("agents")
    public ModelAndView getAllAgents()
    {     
        return new ModelAndView("/allAgents", "agentList", service.getAllAgents());
    }
    
    @RequestMapping(name="delete", method=RequestMethod.GET)
    public ModelAndView deleteAgent(@RequestParam("agentId")int agentId)
    {
        service.deleteAnAgent(agentId);
        return new ModelAndView("/allAgents", "agentList", service.getAllAgents());
    }
    
    /*
    @GetMapping("/add")
    public ModelAndView displayAgentAddForm() 
    {
        return new ModelAndView("/addAgent", "agent", "");
    }
        
    @PostMapping("/addAgent")
    public ModelAndView addAgent(@FormParam("id") int id, @FormParam("name") String name, @FormParam("phone") String phone, @FormParam("fax") String fax, @FormParam("email") String email, @FormParam("password") String password)
    {
        //Agent agent = new Agent(id, name, fax, phone, email, password);
        //service.addAnAgent(agent);
        
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
*/
}
