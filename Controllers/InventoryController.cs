using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly BlobService _blobService;
    private static List<InventoryItem> _inventory = new();

    public InventoryController(BlobService blobService)
    {
        _blobService = blobService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is empty");

        var blobUrl = await _blobService.UploadBlobAsync(file.FileName, file.OpenReadStream());
        return Ok(new { Url = blobUrl });
    }

    [HttpPost("add")]
    public IActionResult AddItem([FromBody] InventoryItem item)
    {
        item.Id = Guid.NewGuid().ToString();
        _inventory.Add(item);
        return Ok(item);
    }

    [HttpGet("all")]
    public IActionResult GetAllItems()
    {
        return Ok(_inventory);
    }
}
