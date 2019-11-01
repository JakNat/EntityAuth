namespace EntityAuth.Core
{
    /// <summary>
    /// Adding AclId which we need for filter purpose
    /// </summary>
    public interface IPrimaryAuth
    {
        public int AclId { get; set; }
    }
}
