namespace EntityAuth.Core.Services
{
    /// <summary>
    /// Interface for authorization purpose
    /// </summary>
    /// <typeparam name="T">identifier type</typeparam>
    public interface IAuthorizationService
    {
        string GetCurrentRole();
    }
}