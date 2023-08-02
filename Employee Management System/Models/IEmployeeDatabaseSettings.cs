namespace EmployeeManagementSystem.Models
{
    public interface IEmployeeDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string EmployeeCollection { get; set; }
        public string AssetCollection { get; set; }
        public string DepartmentCollection { get; set; }
        public string AdminCollection { get; set; }
        public string RoleCollection { get; set; }

    }
}
