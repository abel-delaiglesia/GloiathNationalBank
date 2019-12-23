using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebApiGNB.Models;

namespace WebApiGNB.Helpers
{
    public class WebApiConnector
    {
        public List<ConversionModel> getRatetable()
        {
            var listconversion = new List<ConversionModel>();
            HttpClient client = new HttpClient();
            var getAllTbl = client.GetAsync("http://localhost:7806/api/Conversion")
               .ContinueWith(response =>
               {
                   var res = response.Result;
                   if (res.StatusCode == HttpStatusCode.OK)
                   {
                       var readResult = res.Content.ReadAsAsync<List<ConversionModel>>();
                       readResult.Wait();
                       listconversion = readResult.Result;

                   }
               });
            getAllTbl.Wait();

            return listconversion.ToList();
        }

        public List<ConversionModel> getRateConversors(string from, string to)
        {
            var listconversion = new List<ConversionModel>();

            HttpClient client = new HttpClient();
            var getAllTbl = client.GetAsync(string.Concat("http://localhost:7806/api/Conversion?from=", from, "&to=", to))
               .ContinueWith(response =>
               {
                   var res = response.Result;
                   if (res.StatusCode == HttpStatusCode.OK)
                   {
                       var readResult = res.Content.ReadAsAsync<List<ConversionModel>>();
                       readResult.Wait();
                       listconversion = readResult.Result;

                   }
               });
            getAllTbl.Wait();

            return listconversion.ToList();
        }

        public List<TransSkuModel> getTranstable()
        {
            var listsku = new List<TransSkuModel>();
            HttpClient client = new HttpClient();
            var getAllTbl = client.GetAsync("http://localhost:7806/api/TransSku")
               .ContinueWith(response =>
               {
                   var res = response.Result;
                   if (res.StatusCode == HttpStatusCode.OK)
                   {
                       var readResult = res.Content.ReadAsAsync<List<TransSkuModel>>();
                       readResult.Wait();
                       listsku = readResult.Result;

                   }
               });
            getAllTbl.Wait();

            return listsku.ToList();
        }

        public List<TransSkuModel> getConvtable(TotalconvertModel _totalData)
        {
            var listConverted = new List<TransSkuModel>();
            HttpClient client = new HttpClient();
            var getAllTbl = client.GetAsync(string.Concat("http://localhost:7806/api/TransSku?sku=",_totalData.Sku))
               .ContinueWith(response =>
               {
                   var res = response.Result;
                   if (res.StatusCode == HttpStatusCode.OK)
                   {
                       var readResult = res.Content.ReadAsAsync<List<TransSkuModel>>();
                       readResult.Wait();
                       listConverted = readResult.Result;

                   }
               });
            getAllTbl.Wait();

            return listConverted.ToList();
        }

    }
}