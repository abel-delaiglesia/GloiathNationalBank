using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRemo.Models
{
    public interface ITransSku
    {
        IEnumerable<TransSku> GetAll();
        IEnumerable<TransSku> FindBySku(string sku);
    }
}
