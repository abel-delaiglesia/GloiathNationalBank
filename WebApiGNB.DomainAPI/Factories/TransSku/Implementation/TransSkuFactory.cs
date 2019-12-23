using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGNB.DomainAPI.Dtos;
using WebApiGNB.DomainAPI.Factories.TransSku.Contract;
using WebApiGNB.InfrastructureAPI.EntityModel;

namespace WebApiGNB.DomainAPI.Factories.TransSku.Implementation
{
    public class TransSkuFactory : ITransSkuFactory
    {
        TransSkuDTO ITransSkuFactory.Create(M_Transactions entity)
        {
            return new TransSkuDTO(entity);
        }

        M_Transactions ITransSkuFactory.Parse(TransSkuDTO model)
        {
            return new M_Transactions
            {
                Id = model.Id,
                Amount = model.Amount,
                Currency = model.Currency,
                TransactionSku = model.TransactionSku
            };
        }

        IEnumerable<TransSkuDTO> ITransSkuFactory.CreateList(IEnumerable<M_Transactions> entities)
        {
            return entities.Select(model => new TransSkuDTO(model));
        }

        IEnumerable<M_Transactions> ITransSkuFactory.ParseList(IEnumerable<TransSkuDTO> modelList)
        {
            return modelList.Select(model => new M_Transactions
            {
                Id = model.Id,
                Amount = model.Amount,
                Currency = model.Currency,
                TransactionSku = model.TransactionSku
            });
        }
    }
}

