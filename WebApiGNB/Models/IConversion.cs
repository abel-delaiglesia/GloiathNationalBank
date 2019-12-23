using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRemo.Models
{
    public interface IConversion
    {
        IEnumerable<Conversion> FindALL();
        IEnumerable<Conversion> FindByfromAndTo(string from, string to);

    }
}
