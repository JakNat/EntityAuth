using System;

namespace EntityAuth.Core.Services
{
    public interface IEntityAuthConfiguration
    {
        /// <summary>
        /// Entity identifier type
        /// </summary>
        public Type IdentifierType { get; set; }
    }
}
