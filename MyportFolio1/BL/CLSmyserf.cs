using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.Models;
using Domain;

namespace MyportFolio1.BL
{
    public interface IISerf
    {
        List<Tbmyserf> getall();
        bool Add(Tbmyserf Vsarv);
        Tbmyserf getallbyid(int Id);
        bool Edite(Tbmyserf xsarv);
        bool Delete(int Id);
    }
    public class CLSmyserf : IISerf
    {
        MyportfolioDBContext xcon;
        public CLSmyserf(MyportfolioDBContext mcon)
        {
            xcon = mcon;
        }
        public List<Tbmyserf> getall()
        {
            List<Tbmyserf> serv = xcon.Tbmyserves.OrderBy(a => a.Id).ToList();
            return serv;
        }
        public bool Add(Tbmyserf Vsarv)
        {
            try
            {
                xcon.Add<Tbmyserf>(Vsarv);
                xcon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Tbmyserf getallbyid(int Id)
        {
            Tbmyserf asarv = xcon.Tbmyserves.FirstOrDefault(a => a.Id == Id);
            return asarv;
        }
        public bool Edite(Tbmyserf xsarv)
        {
            try
            {
                xcon.Entry(xsarv).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                xcon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(int Id)
        {
            try
            {

                Tbmyserf xsarv = xcon.Tbmyserves.Where(a => a.Id == Id).FirstOrDefault();
                xcon.Remove(xsarv);
                xcon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
