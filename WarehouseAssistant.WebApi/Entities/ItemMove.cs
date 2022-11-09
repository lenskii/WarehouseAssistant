namespace WarehouseAssistant.WebApi.Entities
{
    public class ItemMove
    {
        public Guid Guid { get; set; }
        public int ItemId { get; set; }

        public int ItemsCount { get; set; }
        
        public int StorageId { get; set; }
    }
}
