using System.Collections.Generic;
using System.Web.Http;
using WebApiGNB.Services.TransSkuService;
using WebApiGNB.DomainAPI.Dtos;
using WebApiGNB.InfrastructureAPI.UnitOfWork.Implementation;

namespace WebApiGNB.Controllers
{
    public class TransSkuController : ApiController
    {
        private TransSkuService transskuservice = new TransSkuService(new UnitOfWork());         

        public IEnumerable<TransSkuDTO> Get()
        {
            return transskuservice.GetAll();
        }

        public IEnumerable<TransSkuDTO> Get(string sku)
        {
            return transskuservice.GetBySku(sku);
        }

      
    }
}
