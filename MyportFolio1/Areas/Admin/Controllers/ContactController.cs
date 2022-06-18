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
    public class ContactController : Controller
    {
        IIcontc gpu;
        public ContactController(IIcontc ixxg)
        {
            gpu = ixxg;
        }
        public IActionResult MyCon()
        {
            return View(gpu.getall());
        }
        public IActionResult Edite(int? Id)
        {
            if (Id != null)
            {
                return View(gpu.getbyid(Convert.ToInt32(Id)));
            }
            else
            {
                return View();
            }
            

        }
        [HttpPost]
        public IActionResult Save(Tbcontctme vcon)
        {
            if (ModelState.IsValid)
            {
                if(vcon.Id==0|| vcon.Id == null)
                {
                    gpu.Add(vcon);
                    return RedirectToAction("MyCon");
                }
                else
                {
                    gpu.Edite(vcon);
                    return RedirectToAction("MyCon");
                }
               
            }
            else
            {
                return View();
            }
            
        }
        public IActionResult Delete(int Id)
        {

            gpu.Delete(Id);
            return RedirectToAction("MyCon");
        }
    }
}
