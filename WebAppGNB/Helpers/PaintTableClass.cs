using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using WebApiGNB.Helpers;
using WebApiGNB.Models;

namespace WebAppGNB.Helpers
{
    public class PaintTableClass
    {
        private readonly IOFileClass fr = new IOFileClass();
        private string _ext = ".json";

        public TotalconvertModel PaintTables(string table, string _pathroot, TotalconvertModel _totalData)
        {
            bool rate = false;
            bool tsku = false;

            string result = string.Empty;
            string itemjson = string.Empty;
            var listitems = new List<string>();
            var wacon = new WebApiConnector();          
            decimal _auxTotalAmount = 0;


            if (fr.Existfile(_pathroot, string.Concat("Conversion", _ext))) rate = true;
            if (fr.Existfile(_pathroot, string.Concat("Tsku", _ext))) tsku = true;


            if (rate || table == "Conversion")
            {
                _totalData.ConversionModels = wacon.getRatetable();
                foreach (var item in _totalData.ConversionModels)
                {
                    itemjson = JsonConvert.SerializeObject(item);
                    listitems.Add(itemjson);
                }
            }
            if (tsku || table == "Tsku")
            {
                _totalData.Tskus = wacon.getTranstable();
                foreach (var item in _totalData.Tskus)
                {
                    itemjson = JsonConvert.SerializeObject(item);
                    listitems.Add(itemjson);
                }
            }

            if ((table == "Converted") && tsku && rate)
            {
                var listTransSku = wacon.getConvtable(_totalData);
                var to = _totalData.Currency;


                foreach (var itm in listTransSku)
                {
                    decimal auxAmount = 0;



                    foreach (var aux in wacon.getRateConversors(itm.Currency, to))
                    {
                        if (itm.Currency != to)
                        {
                            auxAmount = Math.Round(decimal.Parse(aux.Rate.Replace(".", ",")) * decimal.Parse(itm.Amount.Replace(".", ",")), 2);
                        }
                        else
                        {
                            auxAmount = 0;
                        }

                    }

                    ConvertedModel auxconv = new ConvertedModel()
                    {
                        sku = itm.TransactionSku,
                        amount = itm.Amount,
                        amountCurrency = itm.Currency,
                        change = auxAmount == 0 ? itm.Amount.ToString() : decimal.Round(auxAmount, 2).ToString(),
                        currency = _totalData.Currency
                    };

                    _totalData.Convertedlist.Add(auxconv);
                }

            }

            foreach (var item in _totalData.Convertedlist)
            {
                _auxTotalAmount = decimal.Parse(item.change.Replace(".", ",")) + _auxTotalAmount;
                itemjson = JsonConvert.SerializeObject(item);
                listitems.Add(itemjson);
            }

            _totalData.TotalAmount = _auxTotalAmount.ToString();

            if (!fr.Existfile(_pathroot, string.Concat(table, _ext)))
            {
                fr.Createfile(_pathroot, string.Concat(table, _ext));
                fr.WritefileData(string.Concat(_pathroot, @"\", table, _ext), listitems);
            }

            return _totalData;
        }
    }
}