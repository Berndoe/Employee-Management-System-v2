using EmployeeManagementSystem.Models;
using MongoDB.Driver;

namespace EmployeeManagementSystem.Services
{
    public class AssetService: IAssetService
    {
        private readonly IMongoCollection<Asset> assets;

        public AssetService(IEmployeeDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            assets = database.GetCollection<Asset>(settings.AssetCollection);
        }

        public Asset Create(Asset asset)
        {
            assets.InsertOne(asset);
            return asset;
        }

        public List<Asset> Get()
        {
            return assets.Find(asset => true).ToList();
        }

        public Asset Get(int id)
        {
            return assets.Find(asset => asset.assetId == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            assets.DeleteOne(asset => asset.assetId == id);
        }

        public void Update(int id, Asset asset)
        {
            var filter = Builders<Asset>.Filter.Eq(a => a.assetId, id);

            var update = Builders<Asset>.Update
                .Set(a => a.assetName, asset.assetName);

            assets.UpdateOne(filter, update);
        }
    }
}
