namespace WarehouseAssistant.WebApi.ViewModels
{
    public class GetTransactionsViewModel
    {
        public Guid Guid { get; set; }
        public DateTime DateTime { get; set; }
        public int ItemsCount { get; set; }
        public string StorageFromName { get; set; }
        public string StorageInName { get; set; }
        public string ItemName { get; set; }
    }
}
