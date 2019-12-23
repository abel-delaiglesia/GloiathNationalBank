using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiGNB.DomainAPI.Dtos;
using WebApiGNB.Models;

namespace WebApiGNB.Models
{
    public class TotalconvertModel
    {
        public List<ConversionDTO> Conversions { get; set; }
        public List<TransSkuDTO> Tskus { get; set; }
        public List<Converted> Convertedlist { get; set; }
        public string Sku { get; set; }
        public string Currency { get; set; }
        public int Findfields { get; set; }
        public TotalconvertModel()
        {
            Conversions = new List<ConversionDTO>();
            Tskus = new List<TransSkuDTO>();
            Convertedlist = new List<Converted>();
        }
    }
}