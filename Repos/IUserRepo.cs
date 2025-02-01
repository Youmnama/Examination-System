namespace Examination_System.Repos
{
    public interface IUserRepo
    {
        public Task<bool> IsUserCredentialsValid(string username, string password); //check if the user credentials are valid
    }
}
