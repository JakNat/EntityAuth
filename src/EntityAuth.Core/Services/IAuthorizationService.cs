namespace EntityAuth.Core.Services
{
    public interface IAuthorizationService
    {
        int GetCurrentUserId();
        void SetCurrentUser(int id);
    }
}