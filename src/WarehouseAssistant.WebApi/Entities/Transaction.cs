namespace WarehouseAssistant.WebApi.Entities
{
    public class Transaction
    {
        public Guid Guid { get; set; }
        public DateTime DateTime { get; set; }
        public Guid ItemMoveFromGuid { get; set; }
        public Guid ItemMoveToGuid { get; set; }

    }
}
