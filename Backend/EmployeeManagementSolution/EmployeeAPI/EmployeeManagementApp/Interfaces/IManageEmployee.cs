namespace EmployeeManagementApp.Interfaces
{
    public interface IManageEmployee<T,K>: IChangeStatus
    {
        Task<ICollection<T>> GetEmployees(K item);
       
        Task<T> UpdateEmployeeDetails(K item);
        Task<T> AddEmployee(K item);
    }
}
