using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiGNB.Models;

namespace WebApiGNB.Models
{
    public class TotalconvertModel
    {
        public List<ConversionModel> ConversionModels { get; set; }
        public List<TransSkuModel> Tskus { get; set; }
        public List<ConvertedModel> Convertedlist { get; set; }

        public string Sku { get; set; }
        public string Currency { get; set; }
        public int Findfields { get; set; }
        public string TotalAmount { get; set; }

        public TotalconvertModel()
        {
            ConversionModels = new List<ConversionModel>();
            Tskus = new List<TransSkuModel>();
            Convertedlist = new List<ConvertedModel>();
        }
    }
}