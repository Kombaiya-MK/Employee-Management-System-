namespace EmployeeManagementApp.Interfaces
{
    public interface IManageEmployee<T,K,S>
    {
        Task<ICollection<T>> GetEmployees(K item);
        Task<T> UpdateEmployeeStatus(K item);
        Task<T> UpdateEmployeeDetails(K item);
        Task<T> AddEmployee(K item);
    }
}
