using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.BL;
using MyportFolio1.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MyportFolio1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        IIslider contx;
        public SliderController(IIslider sov)
        {
            contx= sov;
        }
        public IActionResult MySlider()
        {
            
            return View(contx.Getall());
        }
        public IActionResult Edite(int? Id)
        {
            if (Id != null)
            {
                
                return View(contx.getallbyid(Convert.ToInt32(Id)));
            }
            else
            {
                return View();
            }

            
        }
        [HttpPost]
        public async Task<IActionResult>  Save(Tbslider sllid,List<IFormFile>Files)
        {
           
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Img = Guid.NewGuid().ToString() + ".jpg";
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", Img);
                        using (var stream = System.IO.File.Create(FilePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        sllid.Img = Img;
                    }
                }
                
                if (sllid.Id == 0 || sllid.Id == null)
                {
                    contx.Add(sllid);
                    return RedirectToAction("MySlider");
                }
                else
                {
                    contx.Edite(sllid);
                       return RedirectToAction("MySlider");

                }
                
            }
            else
            {
                return View("MySlider");
            }

           
        }
        public IActionResult Delete(int Id)
        {

            contx.Delete(Id);
            return RedirectToAction("MySlider");
        }
    }
    
}
