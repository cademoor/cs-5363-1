namespace Ttu.Domain
{
    public interface IUserService
    {

        void AddUser(IUser user);

        IUser GetUser(string userId);
        IUser GetUser(int recordId);
        IUser[] GetUsers();

        void RemoveUser(int recordId);
        void RemoveUser(IUser user);

    }
}
