using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AssetController : ControllerBase
    {
        private readonly IAssetService assetService;

        public AssetController(IAssetService assetService)
        {
            this.assetService = assetService;
        }

        [HttpPost]
        public ActionResult<Asset> Create([FromBody] Asset asset)
        {
            var existingAsset = assetService.Get(asset.assetId);

            if (existingAsset != null)
                return BadRequest($"The asset with ID {asset.assetId} already exists");

            assetService.Create(asset);
            return asset;
             
        }

        [HttpGet("{assetId}")]
        public ActionResult<Asset> Get(int assetId)
        {
            var asset = assetService.Get(assetId);

            if (asset == null)
                return NotFound($"Asset with ID {assetId} not found");
            return asset;
        }

        [HttpGet]
        public ActionResult<List<Asset>> Get()
        {
            return assetService.Get();
        }

        [HttpPut("{assetId}")]
        public ActionResult Put(int assetId, [FromBody] Asset asset)
        {
            var existingAsset = assetService.Get(assetId);

            if (existingAsset == null)
                return NotFound($"Asset with ID {assetId} not found");

            assetService.Update(assetId, asset);
            return Ok($"Asset with ID {assetId} has been updated");

        }

        [HttpDelete("{assetId}")]
        public ActionResult Delete(int assetId)
        {
            var asset = assetService.Get(assetId);

            if (asset == null)
                return NotFound($"Asset with ID {assetId} not found");

            assetService.Remove(asset.assetId);
            return Ok($"Asset with ID {assetId} has been deleted");
        }

    }

}
