using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiGNB.DomainAPI.Dtos;
using WebApiGNB.InfrastructureAPI.UnitOfWork.Contract;

namespace WebApiGNB.Services.TransSkuService 
{
    public class TransSkuService  
    {
        private readonly IUnitOfWork _unitoofwork;

        public TransSkuService(IUnitOfWork unitoofwork)
        {
            _unitoofwork = unitoofwork;

        }

        public IEnumerable<TransSkuDTO> GetAll()
        {
            var res =   from tsku in _unitoofwork
                                       .M_TransactionsRepository
                                       .GetAll()
                                       .AsEnumerable()
                        select new TransSkuDTO(tsku);
            return res;
        }

        public IEnumerable<TransSkuDTO> GetBySku(string sku)
        {
            var res = from tsku in _unitoofwork
                                      .M_TransactionsRepository
                                      .FindBy(r => r.TransactionSku == sku)
                                      .AsEnumerable()                   
                         select new TransSkuDTO(tsku);

            return res; 
        }


    }
}