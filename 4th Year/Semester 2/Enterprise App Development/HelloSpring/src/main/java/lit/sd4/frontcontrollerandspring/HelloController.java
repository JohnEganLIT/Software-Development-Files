package lit.sd4.frontcontrollerandspring;

import java.util.ArrayList;
import java.util.List;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

@Controller
public class HelloController 
{
    @RequestMapping(value ="/sayHello")
    @ResponseBody
    public String sayHello()
    {
        return "Hello";
    }
    
    @RequestMapping(value = "/sayHello2")
    public String sayHello2(Model model)
    {
        model.addAttribute("name", "Colin Maher");
        return "/hellojsp";
    }
    
    @RequestMapping(value = "/sayHello3")
    public ModelAndView sayHello3()
    {
        return new ModelAndView("/hellojsp", "name", "Colin");
    }
    
    @RequestMapping(value = "/loadGreetings")
    public ModelAndView globalGreetings()
    {
        List<String> messages = new ArrayList();
        messages.add("Dia duit domhan");
        messages.add("Hello world");
        messages.add("Hallo Welt");
        messages.add("Bonjour le monde");
        messages.add("Hola Mundo");
        messages.add("Hej Verden");
        
        return new ModelAndView("/greetings", "hellolist", messages);
    }
}