using System.Collections.Generic;
using System.Linq;
using WebApiGNB.InfrastructureAPI.EntityModel;
using WebApiGNB.InfrastructureAPI.UnitOfWork.Contract;
using WebApiGNB.DomainAPI.Dtos;

namespace WebApiGNB.Services.ConversionService 
{
    public class ConversionService  
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConversionService(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
           
        }


        public IEnumerable<ConversionDTO> GetConversions()
        {
            var res = from l in _unitOfWork.M_ConversionRepository.GetAll().AsEnumerable()
                      select new ConversionDTO(l);
            return res;
        }


        public IEnumerable<ConversionDTO> FindByfromAndTo(string from, string to)
        {
            var listConversions = GetConversions().ToList();
            List<ConversionDTO> auxlistaConv = new List<ConversionDTO>();
            ConversionDTO ItemFromTo, itemFrom, itemTo = new ConversionDTO();

            //conversión directa en la tabla
            ItemFromTo = GetConversions().Where(p => p.from.Equals(from)).Where(p => p.to.Equals(to)).FirstOrDefault();
          
        
            if (ItemFromTo != null)
            {
                auxlistaConv.Add(ItemFromTo);
            }
            else
            {

                    itemFrom = GetConversions().Where(p => p.from.Equals(from)).FirstOrDefault();

                    if (itemFrom.to != to)
                        itemTo = GetConversions().Where(p => p.to.Equals(to)).FirstOrDefault();

                    if (itemFrom.to == itemTo.from && itemTo.to == to)
                    {
                        auxlistaConv.Add(itemFrom);
                        auxlistaConv.Add(itemTo);
                    }
  

            }

            return auxlistaConv;

        }


        public void InsertConversion(M_Conversion entity)
        {
            _unitOfWork.M_ConversionRepository.Add(entity);
            _unitOfWork.M_ConversionRepository.Save();

        }

        public void Delete(int ConversionId)
        {
            var LineToDelete = _unitOfWork.M_ConversionRepository.FindBy(m => m.Id == ConversionId).ToList();
            _unitOfWork.M_ConversionRepository.DeleteList(LineToDelete);
            //process
            _unitOfWork.M_ConversionRepository.Save();
        }

     
    }
}
