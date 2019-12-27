using System;
using System.Collections.Generic;
using System.Text;

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
