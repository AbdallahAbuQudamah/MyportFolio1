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
    public class BlogController : Controller
    {
        IICart xCart;
        public BlogController(IICart Tcart)
        {
            xCart = Tcart;
        }
        public IActionResult MyBlog()
        {
            return View(xCart.getall());
        }
        public IActionResult Edite(int? Id)
        {
            if (Id != null)
            {
                return View(xCart.getallbyid(Convert.ToInt32(Id)));
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Save(Tbmycard bcard, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Img = Guid.NewGuid().ToString() + ".jpg";
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\CardUploads", Img);
                        using (var stream = System.IO.File.Create(FilePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        bcard.Img = Img;
                    }
                }
                if (bcard.Id == 0 || bcard.Id == null)
                {
                    xCart.Add(bcard);
                    return RedirectToAction("MyBlog");
                }
                else
                {
                    xCart.Edite(bcard);
                    return RedirectToAction("MyBlog");
                }

            }
            else
            {
                return View(bcard);
            }

        }
        public IActionResult Delete(int Id)
        {

            xCart.Delete(Id);
            return RedirectToAction("MyBlog");
        }
    }
}
