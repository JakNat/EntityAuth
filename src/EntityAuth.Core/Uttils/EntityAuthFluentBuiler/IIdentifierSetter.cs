using System;

namespace EntityAuth.Core.Uttils
{
    public interface IIdentifierSetter
    {
        /// <summary>
        /// Set resorce identifiers type. 
        /// <para> Supported types: 
        /// <see cref="int"/>, <see cref="long"/>, <see cref="Guid"/></para>
        /// </summary>
        public IAuthFilterScope SetIdentifierType<TIdentifier>();
    }
}
