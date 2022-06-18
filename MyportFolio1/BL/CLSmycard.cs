using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyportFolio1.Models;
using Domain;

namespace MyportFolio1.BL
{
    public interface IICart
    {
        IList<Tbmycard> getall();
        bool Add(Tbmycard bcard);
        Tbmycard getallbyid(int Id);
        bool Edite(Tbmycard Cardd);
        bool Delete(int Id);
    }
    public class CLSmycard:IICart
    {
        MyportfolioDBContext conex;
        public CLSmycard(MyportfolioDBContext tnb)
        {
            conex = tnb;
        }
        public IList<Tbmycard> getall()
        {
            List<Tbmycard> Cart = conex.Tbmycards.OrderByDescending(a => a.Id).ToList();
            return Cart;
        }
        public bool Add(Tbmycard bcard)
        {
            try
            {
                conex.Add<Tbmycard> (bcard);
                conex.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public Tbmycard getallbyid(int Id)
        {
            Tbmycard Cardd = conex.Tbmycards.FirstOrDefault(a => a.Id==Id);
            return Cardd;
        }
        public bool Edite(Tbmycard Cardd)
        {
            try
            {
                conex.Entry(Cardd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                conex.SaveChanges();
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

                Tbmycard ocard = conex.Tbmycards.Where(a => a.Id == Id).FirstOrDefault();
                conex.Remove(ocard);
                conex.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
