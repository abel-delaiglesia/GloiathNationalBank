using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGNB.Models
{
    public interface IConverted
    {
        IEnumerable<Converted> FindALL();
        IEnumerable<Converted> FindBySku(string sku);
    }
}
