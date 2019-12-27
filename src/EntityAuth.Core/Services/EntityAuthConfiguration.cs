using System;

namespace EntityAuth.Core.Services
{
    public class EntityAuthConfiguration : IEntityAuthConfiguration
    {
        public Type IdentifierType { get; set; }
    }
}
