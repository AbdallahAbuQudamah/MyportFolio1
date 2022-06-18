using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.Models;
using Domain;

namespace MyportFolio1.BL
{
    public interface IIraseme
    {
        List<Tbresme> getall();
        bool Add(Tbresme vrase);
        Tbresme getbyid(int Id);
        bool Edite(Tbresme tresa);
        bool Delete(int Id);
    }
    public class CLSresme:IIraseme
    {
        MyportfolioDBContext conrase;
        public CLSresme(MyportfolioDBContext bbr)
        {
            conrase = bbr;
        }
        public List<Tbresme> getall()
        {
            List<Tbresme> ares = conrase.Tbresmes.OrderByDescending(a => a.Id).ToList();
            return ares; 
        }
        public bool Add(Tbresme vrase)
        {
            try
            {
                conrase.Add<Tbresme>(vrase);
                conrase.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
          
        }
        public Tbresme getbyid(int Id)
        {
            Tbresme trase = conrase.Tbresmes.FirstOrDefault(a => a.Id == Id);
            return trase;
        }
        public bool Edite(Tbresme tresa)
        {
            try
            {
                conrase.Entry(tresa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                conrase.SaveChanges();
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

                Tbresme trase = conrase.Tbresmes.Where(a => a.Id == Id).FirstOrDefault();
                conrase.Tbresmes.Remove(trase);
                conrase.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
