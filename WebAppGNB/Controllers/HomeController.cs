using System.Web.Mvc;
using WebApiGNB.Models;
using WebApiGNB.Helpers;
using WebAppGNB.Helpers;

namespace GloiathNationalBank.Controllers
{
    public class HomeController : Controller
    {

        IOFileClass fr = new IOFileClass();      
        TotalconvertModel _totalData = new TotalconvertModel();
        PaintTableClass ptc = new PaintTableClass();

        private string _pathroot { get; set; }       


        public ActionResult Index(TotalconvertModel totalData)
        {
             if (string.IsNullOrWhiteSpace(_pathroot)) _pathroot = CrtRootDirectory();

            // se borra y luego se vuelve a crear direcotorio temporal de trabajo 
            if (fr.ExistsDir(_pathroot)) fr.Deletefiles(_pathroot);
            fr.CreateDir(_pathroot);

            if (totalData.Findfields == 1)
            {
               //calcular Tip de la cuenta enviada 
               return View(_totalData);
            }
            else
            {
              return View(_totalData);
            }
         
        }

        public ActionResult PaintTableRate()
        {
            if (string.IsNullOrWhiteSpace(_pathroot)) _pathroot = CrtRootDirectory();

            _totalData = ptc.PaintTables("Conversion", _pathroot, _totalData);
            return View("Index", _totalData);
        }

        public ActionResult PaintTableSku()
        {
            if (string.IsNullOrWhiteSpace(_pathroot)) _pathroot = CrtRootDirectory();

            _totalData = ptc.PaintTables( "Tsku", _pathroot, _totalData);
            return View("Index", _totalData);
        }

        public ActionResult PaintTableConversions(string SkuAndCurr)
        {
            if (string.IsNullOrWhiteSpace(_pathroot)) _pathroot = CrtRootDirectory();

            if (SkuAndCurr != string.Empty)
            {
                _totalData.Sku = SkuAndCurr.Split('-')[0];
                _totalData.Currency = SkuAndCurr.Split('-')[1];
            }
            _totalData = ptc.PaintTables("Converted", _pathroot, _totalData);
            return View("Index", _totalData);
        }
              
        private string CrtRootDirectory()
        {
            return HttpContext.Server.MapPath("~/App_Data/_temporal");
        }
    }
}