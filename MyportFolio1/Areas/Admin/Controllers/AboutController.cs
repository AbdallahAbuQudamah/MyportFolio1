using Microsoft.AspNetCore.Mvc;
using MyportFolio1.BL;
using MyportFolio1.Models;
using Domain;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;


namespace MyportFolio1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        IIaboutme aboutf;
        public AboutController(IIaboutme iabout)
        {
            aboutf=iabout;
        }
        public IActionResult Aboutinfo()
        {
            return View(aboutf.getall());
        }
        public IActionResult Edite(int? Id)
        {
            if (Id != null)
            {
               return View(aboutf.getallbyid(Convert.ToInt32(Id)));
            }
            else
            {
                return View();
            }
            

        }
        [HttpPost]
        public async Task<IActionResult>  Save(Tbaboutme aboutx, List<IFormFile> Files)
        {
            if(ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Img = Guid.NewGuid().ToString() + ".jpg";
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\AboutUpload", Img);
                        using (var stream = System.IO.File.Create(FilePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        aboutx.Img = Img;
                    }
                }
                if (aboutx.Id == 0 || aboutx.Id == null)
                {
                    aboutf.Add(aboutx);
                    return RedirectToAction("Aboutinfo");
                }
                else
                {
                    aboutf.Edite(aboutx);
                    return RedirectToAction("Aboutinfo");

                }
                    
            }
            else
            {
                return View(aboutx);
            }
        }
        public IActionResult Delete(int Id)
        {

            aboutf.Delete(Id);
            return RedirectToAction("Aboutinfo");
        }


    }
    }

