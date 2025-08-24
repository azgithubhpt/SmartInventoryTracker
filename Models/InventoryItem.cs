public class InventoryItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string BlobUrl { get; set; } // https://smartinventorystorage.blob.core.windows.net/inventory-data/sample_inventory.json?se=2025-08-24T00%3A00%3A00Z&sp=r&sv=2022-11-02&sr=b&sig=3VknDTHLc87j1B%2Fjqq08PRCr5EI%2F3kQiqkr%2B4PR9h2E%3D

}
