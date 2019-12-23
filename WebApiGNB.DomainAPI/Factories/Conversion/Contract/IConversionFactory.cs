using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGNB.DomainAPI.Dtos;
using WebApiGNB.InfrastructureAPI.EntityModel;

namespace WebApiGNB.DomainAPI.Factories.Conversion.Contract
{
    public interface IConversionFactory
    {
        ConversionDTO Create(M_Conversion entity);
        IEnumerable<M_Conversion> ParseList(IEnumerable<ConversionDTO> modelList);
        IEnumerable<ConversionDTO> CreateList(IEnumerable<M_Conversion> entities);
        M_Conversion Parse(ConversionDTO model);
    }
}
