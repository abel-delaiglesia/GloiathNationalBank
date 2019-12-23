using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiRemo.Models;

namespace WebApiRemo.Models
{
    public class ConversionReposirtoy : IConversion
    {
        private List<Conversion> listaConversiones = new List<Conversion>();
        public ConversionReposirtoy()
        {

            listaConversiones.Add(new Conversion {From = "EUR" ,To = "USD" ,Rate = "1.359"});
            listaConversiones.Add(new Conversion {From = "CAD" ,To = "EUR" ,Rate = "0.732"});
            listaConversiones.Add(new Conversion {From = "USD" ,To = "EUR" ,Rate = "0.736"});
            listaConversiones.Add(new Conversion {From = "EUR", To = "CAD", Rate = "1.366"});
           
        }

        public IEnumerable<Conversion> FindALL()
        {
            return listaConversiones;
        }


        public IEnumerable<Conversion> FindByfromAndTo(string from,string to)
        {
            List<Conversion> auxlistaConv = new List<Conversion>();
      
            var ItemFromTo = listaConversiones.Where(p => p.From.Equals(from)).Where(p => p.To.Equals(to));
            var itemFrom = listaConversiones.Where(p => p.From.Equals(from)).Where(p => p.To != to);
            var itemTo = listaConversiones.Where(p => p.From == itemFrom.First().To).Where(p => p.To.Equals(to));

            if (ItemFromTo != null)
            {
                auxlistaConv.Add(ItemFromTo.FirstOrDefault());
            }
            else
            {
                auxlistaConv.Add(itemFrom.FirstOrDefault());
                auxlistaConv.Add(itemTo.FirstOrDefault());
            }

            return auxlistaConv;
           
        }
    }
}