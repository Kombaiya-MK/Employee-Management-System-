namespace EmployeeManagementApp.Interfaces
{
    public interface IMapper<T,K>
    {
        Task<T> MapEmployee(K item);
    }
}
