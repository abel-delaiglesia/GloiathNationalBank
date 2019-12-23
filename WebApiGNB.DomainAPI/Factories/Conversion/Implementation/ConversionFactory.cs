using System.Collections.Generic;
using System.Linq;
using WebApiGNB.DomainAPI.Dtos;
 using WebApiGNB.DomainAPI.Factories.Conversion.Contract;
using WebApiGNB.InfrastructureAPI.EntityModel;

namespace WebApiGNB.DomainAPI.Factories.Conversion.Implementation
{
    public class ConversionFactory : IConversionFactory
    {
        ConversionDTO IConversionFactory.Create(M_Conversion entity)
        {
            return new ConversionDTO(entity);
        }

        M_Conversion IConversionFactory.Parse(ConversionDTO model)
        {
            return new M_Conversion
            {
                Id = model.Id,
                from = model.from,
                to = model.to,
                Rate = model.Rate

            };
        }

        IEnumerable<ConversionDTO> IConversionFactory.CreateList(IEnumerable<M_Conversion> entities)
        {
            return entities.Select(model => new ConversionDTO(model));
        }

        IEnumerable<M_Conversion> IConversionFactory.ParseList(IEnumerable<ConversionDTO> modelList)
        {
            return modelList.Select(model => new M_Conversion
            {
                Id = model.Id,
                from = model.from,
                to = model.to,
                Rate = model.Rate
            });
        }
    }

}

