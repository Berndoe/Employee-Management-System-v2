using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public interface IAssetService
    {
        List<Asset> Get();
        Asset Get(int id);
        Asset Create(Asset asset);
        void Update(int id, Asset asset);
        void Remove(int id);
    }
}
