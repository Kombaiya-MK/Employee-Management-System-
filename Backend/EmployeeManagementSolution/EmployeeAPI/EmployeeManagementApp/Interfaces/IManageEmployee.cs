namespace EmployeeManagementApp.Interfaces
{
<<<<<<< HEAD
    public interface IManageEmployee<T,K,S>
    {
        Task<ICollection<T>> GetAllEmployees(S item);
        Task<T> UpdateEmployeeStatus(K item);
=======
    public interface IManageEmployee<T,K>: IChangeStatus
    {
        Task<ICollection<T>> GetEmployees(K item);
       
>>>>>>> 2370cd7fd354a340397ff66160b8f2854b5b13cd
        Task<T> UpdateEmployeeDetails(K item);
        Task<T> AddEmployee(K item);
    }
}
