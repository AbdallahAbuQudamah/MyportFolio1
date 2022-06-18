using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.Models;

namespace MyportFolio1.BL
{
    public interface IIslider
    {
        List<Tbslider> Getall();
        Tbslider getallbyid(int Id);
        bool Add(Tbslider sllid);
        bool Edite(Tbslider sslid);
        bool Delete(int Id);
    }
    public class CLSslider:IIslider
    {
        MyportfolioDBContext ctts;
        public CLSslider(MyportfolioDBContext ocx)
        {
            ctts = ocx;
        }
        public List<Tbslider> Getall()
        {
           
            List<Tbslider> MySlider = ctts.Tbsliders.OrderByDescending(a => a.Id).ToList();
            return MySlider; 
        }

        public Tbslider getallbyid(int Id)
        {
            
            Tbslider sslid = ctts.Tbsliders.FirstOrDefault(a => a.Id == Id);
            return sslid;
        }
          public bool Add(Tbslider sllid)
        {
            try
            {

                ctts.Add<Tbslider>(sllid);
                ctts.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Edite (Tbslider sslid)
        {
            try
            {

                ctts.Entry(sslid).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctts.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete (int Id)
        {
            try 
            {
               
                Tbslider oslider = ctts.Tbsliders.Where(a => a.Id == Id).FirstOrDefault();
                ctts.Tbsliders.Remove(oslider);
                ctts.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }
    }
}
