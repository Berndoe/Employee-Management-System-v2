namespace EmployeeManagementSystem.Models
{
    // this is to help read and store database configuration details
    public class EmployeeDatabaseSettings: IEmployeeDatabaseSettings 
    {
        public string DatabaseName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string EmployeeCollection { get; set; } = String.Empty;
        public string AssetCollection { get; set; } = String.Empty;
        public string DepartmentCollection { get; set; } = String.Empty;
        public string AdminCollection { get; set; } = String.Empty;
        public string RoleCollection { get; set; } = String.Empty;

    }
}
