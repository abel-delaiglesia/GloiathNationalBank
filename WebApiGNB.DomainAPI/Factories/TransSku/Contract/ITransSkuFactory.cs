using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGNB.DomainAPI.Dtos;
using WebApiGNB.InfrastructureAPI.EntityModel;

namespace WebApiGNB.DomainAPI.Factories.TransSku.Contract
{
    public interface ITransSkuFactory
    {
        TransSkuDTO Create(M_Transactions entity);
        IEnumerable<M_Transactions> ParseList(IEnumerable<TransSkuDTO> modelList);
        IEnumerable<TransSkuDTO> CreateList(IEnumerable<M_Transactions> entities);
        M_Transactions Parse(TransSkuDTO model);
    }
}
