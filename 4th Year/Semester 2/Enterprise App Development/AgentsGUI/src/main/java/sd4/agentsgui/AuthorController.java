package sd4.agentsgui;

import javax.ws.rs.FormParam;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.ModelAndView;

@Controller
public class AuthorController 
{ 
    AgentService service = new AgentService();
    
    @GetMapping("/agents")
    public ModelAndView getAllAgents()
    {
        return new ModelAndView("/allAgents", "agentList", service.getAllAgents());
    }
    
    @GetMapping("/add")
    public ModelAndView displayAgentAddForm() 
    {
        return new ModelAndView("/addAgent", "agent", "");
    }
        
    @PostMapping("/addAgent")
    public ModelAndView addAnAgent(@FormParam("id") int id, @FormParam("name") String name, @FormParam("phone") String phone, 
            @FormParam("fax") String fax, @FormParam("email") String email, @FormParam("password") String password)
    {
        Agent agent = new Agent(id, name, fax, phone, email, password);
        service.addAnAgent(agent);
        
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
}
