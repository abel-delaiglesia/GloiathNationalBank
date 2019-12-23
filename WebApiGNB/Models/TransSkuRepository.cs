using System.Collections.Generic;
using System.Linq;

namespace WebApiRemo.Models
{
    public class TransSkuRepository : ITransSku
    {

        private List<TransSku> listTransSku = new List<TransSku>();

        public TransSkuRepository()
        {
            listTransSku.Add(new TransSku {TransactionSku="T2006", Amount="10.00", Currency="USD" });
            listTransSku.Add(new TransSku {TransactionSku="M2007" ,Amount="34.57", Currency="CAD" });
            listTransSku.Add(new TransSku {TransactionSku="R2008" ,Amount="17.95", Currency="USD" });
            listTransSku.Add(new TransSku {TransactionSku="T2006" ,Amount="7.63" , Currency="EUR" });
            listTransSku.Add(new TransSku {TransactionSku="B2009" ,Amount="21.23", Currency="USD" });
        }

        public IEnumerable<TransSku> GetAll()
        {
           return listTransSku;
        }

        public IEnumerable<TransSku>  FindBySku(string sku)
        {
           return listTransSku.Where(p => p.TransactionSku.Equals(sku));
        }
    }
}