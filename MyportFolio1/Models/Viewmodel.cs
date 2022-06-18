using System.Collections.Generic;
using Domain;

namespace MyportFolio1.Models
{
    public class Viewmodel
    {
        public IEnumerable<Tbslider> slideinfo { get; set; }
        public IEnumerable<Tbaboutme> saboutme { get; set; }
        public IEnumerable<Tbmyserf> sservices { get; set; }
        public IEnumerable<Tbmycard> scard { get; set; }
        public IEnumerable<Tbresme> sresa { get; set; }
        public IEnumerable<Tbcontctme> scontac { get; set; }


    }
}
