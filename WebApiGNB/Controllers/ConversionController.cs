using System.Collections.Generic;
using System.Web.Http;
using WebApiGNB.Services.ConversionService;
using WebApiGNB.DomainAPI.Dtos;
using WebApiGNB.InfrastructureAPI.UnitOfWork.Implementation;


namespace WebApiGNB.Controllers
{
    public class ConversionController : ApiController
    {
        private ConversionService _conversionService = new ConversionService(new UnitOfWork());

        public IEnumerable<ConversionDTO> Get()
        {
            return _conversionService.GetConversions();
        }

        public IEnumerable<ConversionDTO> Get(string from, string to)
        {
            return _conversionService.FindByfromAndTo(from,to);
        }

    }
}
