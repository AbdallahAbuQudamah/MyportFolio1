using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.BL;
using MyportFolio1.Models;

namespace MyportFolio1.Controllers
{
    public class HomeController : Controller
    {
        IIslider conty;
        IIaboutme mabout;
        IISerf ssx;
        IICart car;
        IIraseme abc;
        IIcontc wcont;
        public HomeController (IIslider mana,IIaboutme mmab,IISerf mssa,IICart iCart,IIraseme irase,IIcontc icontf)
        {
            conty=mana;
            mabout= mmab;
            ssx = mssa;
            car = iCart;
            abc = irase;
            wcont = icontf;
        }
        public IActionResult Index()
        {
            Viewmodel vmmodel= new Viewmodel();
            vmmodel.slideinfo = conty.Getall();
            vmmodel.slideinfo = vmmodel.slideinfo.Take(1);
            vmmodel.saboutme= mabout.getall();
            vmmodel.saboutme=vmmodel.saboutme.Take(1);
            vmmodel.sservices = ssx.getall();
            vmmodel.scard = car.getall();
            vmmodel.sresa = abc.getall();
            vmmodel.scontac = wcont.getall();
            vmmodel.scontac = vmmodel.scontac.Take(1);
            return View(vmmodel);
        }
    }
}
