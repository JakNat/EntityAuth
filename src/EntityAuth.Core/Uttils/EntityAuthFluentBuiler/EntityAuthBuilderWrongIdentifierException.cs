using System;

namespace EntityAuth.Core.Uttils
{
    public class EntityAuthBuilderWrongIdentifierException : Exception
    {

        public EntityAuthBuilderWrongIdentifierException(string message) : base(message)
        {
        }
    }
}
