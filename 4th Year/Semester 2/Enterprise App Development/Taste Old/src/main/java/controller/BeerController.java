package controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;
import service.BeerService;

public class BeerController 
{
    BeerService service = new BeerService();
    
    @RequestMapping("beer")
    public ModelAndView getAllAgents()
    {     
        return new ModelAndView("/allBeers", "beerList", service.getAllBeers());
    }
}
