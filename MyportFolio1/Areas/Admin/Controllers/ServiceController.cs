using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.BL;
using MyportFolio1.Models;
using Domain;

namespace MyportFolio1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        IISerf xserv;
        public ServiceController(IISerf oserv)
        {
            xserv = oserv;
        }
        public IActionResult MyServices()
        {
            return View(xserv.getall());
        }
        public IActionResult Edite(int? Id)
        {
            if (Id != null)
            {
                return View(xserv.getallbyid(Convert.ToInt32(Id)));
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult Save(Tbmyserf Vsarv)
        {
            if (ModelState.IsValid)
            {
                if (Vsarv.Id == 0 || Vsarv.Id == null)
                {
                    xserv.Add(Vsarv);
                    return RedirectToAction("MyServices");
                }
                else {
                    xserv.Edite(Vsarv);
                    return RedirectToAction("MyServices");
                }
               
            }
            else
            {
                return View(Vsarv);
            }
           
        }
        public IActionResult Delete(int Id)
        {

            xserv.Delete(Id);
            return RedirectToAction("MyServices");
        }
    }
}
