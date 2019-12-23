using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGNB.InfrastructureAPI.EntityModel;

namespace WebApiGNB.DomainAPI.Dtos
{
    public class ConversionDTO
    {

        public ConversionDTO(M_Conversion entity)
        {
            if (entity == null) return;
            Id = entity.Id;
            from = entity.from;
            to = entity.to
;           Rate = entity.Rate;

        }
        public ConversionDTO()
        {
        }
        public int Id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string Rate { get; set; }
    }

   
}



