namespace LeaveAPI.Models.DTO
{
    public class Error
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public Error(int id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
