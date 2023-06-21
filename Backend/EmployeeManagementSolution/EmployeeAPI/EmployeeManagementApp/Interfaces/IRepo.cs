namespace EmployeeManagementApp.Interfaces
{
    public interface IRepo<T,k>
    {
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(k key);
        public Task<T> Get(k key);
        Task<ICollection<T>> GetAll();
    }
}
