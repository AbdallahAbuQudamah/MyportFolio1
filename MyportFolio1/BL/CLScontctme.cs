using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.Models;
using Domain;

namespace MyportFolio1.BL
{
    public interface IIcontc
    {
        List<Tbcontctme> getall();
        bool Add(Tbcontctme Vcont);
        Tbcontctme getbyid(int Id);
        bool Edite(Tbcontctme tcgg);
        bool Delete(int Id);
    }
    public class CLScontctme:IIcontc
    {
        MyportfolioDBContext say;
        public CLScontctme(MyportfolioDBContext ccr)
        {
            say = ccr;
        }
        public List<Tbcontctme>getall()
        {
            List<Tbcontctme> acont = say.Tbcontctmes.OrderByDescending(a => a.Id).ToList();
            return acont;

        }
        public bool Add(Tbcontctme Vcont)
        {
            try
            {
                say.Add<Tbcontctme>(Vcont);
                say.SaveChanges();
                return true;
            }
           catch(Exception ex)
            {
                return false;
            }
        }
        public Tbcontctme getbyid(int Id)
        {
            Tbcontctme Tconn = say.Tbcontctmes.FirstOrDefault(a => a.Id == Id);
            return Tconn;
        }
        public bool Edite(Tbcontctme tcgg)
        {
            try
            {
                say.Entry(tcgg).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                say.SaveChanges();
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

                Tbcontctme tcgg = say.Tbcontctmes.Where(a => a.Id == Id).FirstOrDefault();
                say.Tbcontctmes.Remove(tcgg);
                say.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
