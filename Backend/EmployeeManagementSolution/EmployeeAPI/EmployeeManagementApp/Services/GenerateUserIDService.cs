using EmployeeManagementApp.Interfaces;

namespace EmployeeManagementApp.Services
{
    public class GenerateUserIDService : IGenerateUserID
    {
        public async Task<string> GenerateUserId(int count)
        {
            string userID = "KB0";
            if (count<10 &&  count>=0)
                userID += "0" + (++count);
            else 
                userID += (++count);
            return  userID;
        }
    }
}
