using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiGNB.Models;

namespace WebApiGNB.Models
{
    public class ConvertedReposirtoy : IConverted
    {
        private List<Converted> lstConverted = new List<Converted>();

        public ConvertedReposirtoy()
        {
                  
        }

        public IEnumerable<Converted> FindALL()
        {
            return lstConverted;
        }

        public IEnumerable<Converted> FindBySku(string sku)
        {
            return lstConverted.Where(p => p.sku.Equals(sku));
        }
   }
}