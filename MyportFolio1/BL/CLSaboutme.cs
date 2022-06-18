using MyportFolio1.Models;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyportFolio1.BL
{
    public interface IIaboutme
    {
        List<Tbaboutme> getall();
        bool Add(Tbaboutme aboutx);
        Tbaboutme getallbyid(int Id);
        bool Edite(Tbaboutme abbout);
        bool Delete(int Id);


    }
    public class CLSaboutme:IIaboutme
    {
        MyportfolioDBContext conty;
        public CLSaboutme(MyportfolioDBContext contm)
        {
            conty = contm;
        }
        
        public List<Tbaboutme> getall()
        {
            List<Tbaboutme> Aboutinf = conty.Tbaboutmes.OrderByDescending(a => a.Id).ToList();
            return Aboutinf;
        }
        public Tbaboutme getallbyid(int Id)
        {
            Tbaboutme abbout=conty.Tbaboutmes.FirstOrDefault(a => a.Id == Id);
            return abbout;
        }
        public bool Add(Tbaboutme aboutx)
        {
            try
            {
               conty.Add<Tbaboutme>(aboutx);
               conty.SaveChanges();
               return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Edite(Tbaboutme abbout)
        {
            try
            {
                conty.Entry(abbout).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                conty.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int Id)
        {
            try
            {

                Tbaboutme abbout = conty.Tbaboutmes.Where(a => a.Id == Id).FirstOrDefault();
                conty.Remove(abbout);
                conty.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
