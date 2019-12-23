using WebApiGNB.InfrastructureAPI.EntityModel;

namespace WebApiGNB.DomainAPI.Dtos
{
    public class TransSkuDTO
    {
        public TransSkuDTO(M_Transactions entity)
        {
            if (entity == null) return;
            Id = entity.Id;
            TransactionSku = entity.TransactionSku;
            Amount = entity.Amount;
            Currency = entity.Currency;
        }
        public TransSkuDTO()
        {
        }
        public int Id { get; set; }
        public string TransactionSku { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
    }
}
