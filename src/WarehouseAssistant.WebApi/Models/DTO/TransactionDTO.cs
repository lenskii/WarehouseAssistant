namespace WarehouseAssistant.WebApi.Models.DTO
{
    public class TransactionDTO
    {
        public int ItemId { get; set; }
        public int ItemsCount { get; set; }
        public int StorageFromId { get; set; }
        public int StorageToId { get; set; }
       
    }
}
