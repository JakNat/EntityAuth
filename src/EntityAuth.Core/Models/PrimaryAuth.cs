using System;

namespace EntityAuth.Core
{
    /// <summary>
    /// Marker for resources.
    /// Suported identifier types:
    /// <see cref="int"/>
    /// ,<see cref="long"/>
    /// ,<see cref="Guid"/>
    /// </summary>
    public interface IResourceId<T>
    {
        public T Id { get; set; }
    }
}
