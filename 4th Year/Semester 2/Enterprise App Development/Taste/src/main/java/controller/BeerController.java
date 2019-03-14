package controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;
import service.BeerService;

@Controller
public class BeerController 
{
    BeerService service = new BeerService();
    
    @RequestMapping("beer")
    public ModelAndView getAllBeers()
    {     
        return new ModelAndView("/allBeers", "beerList", service.getAllBeers());
    }
}
