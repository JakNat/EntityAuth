namespace EntityAuth.Core.Services
{
    /// <summary>
    /// Interface for authorization purpose
    /// </summary>
    /// <typeparam name="T">indentyfier type</typeparam>
    public interface IAuthorizationService<T>
    {
        T GetCurrentUserId();
    }
}