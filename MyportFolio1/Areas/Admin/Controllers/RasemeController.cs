using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.BL;
using MyportFolio1.Models;

namespace MyportFolio1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RasemeController : Controller
    {
        IIraseme ixresa;
        public RasemeController(IIraseme ixxc)
        {
            ixresa = ixxc;
        }
        public IActionResult MyRaseme()
        {
            return View(ixresa.getall());
        }
        public IActionResult Edite(int? Id)
        {
            if (Id != null)
            {
                return View(ixresa.getbyid(Convert.ToInt32(Id)));
            }
            else
            {
                return View();
            }
          

        }
        public IActionResult Save(Tbresme vrase)
        {
            if (ModelState.IsValid)
            {
                if(vrase.Id==0|| vrase.Id == null)
                {
                    ixresa.Add(vrase);
                    return RedirectToAction("MyRaseme");
                }
                else
                {
                    ixresa.Edite(vrase);
                    return RedirectToAction("MyRaseme");
                }
               
            }
            else
            {
                return View(vrase);
            }
         
        }
        public IActionResult Delete(int Id)
        {

            ixresa.Delete(Id);
            return RedirectToAction("MyRaseme");
        }
    }
}
